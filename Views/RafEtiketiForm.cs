using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ÜrünTakip.Data;
using ÜrünTakip.Models;

namespace ÜrünTakip.Views
{
    /// <summary>
    /// Raf Etiketi Tasarım ve Yazdırma Formu.
    /// İki sekme: Tüm Ürünler (mevcut fiyat) ve Fiyat Değişenler.
    /// </summary>
    public class RafEtiketiForm : Form
    {
        // ── Controls ──
        private DataGridView dgvMain;
        private Button btnTabAll, btnTabChanged;
        private Button btnSelectAll, btnDeselectAll, btnPrintSelected, btnPreview, btnDeletePrinted;
        private ComboBox cmbLabelSize;
        private Label lblCount, lblTitle;
        private Panel pnlToolbar, pnlTabs;
        private CheckBox chkShowOldPrice;
        private NumericUpDown numCopies;
        private TextBox txtSearch;

        // ── State ──
        private bool _isAllProductsMode = true;
        private List<LabelItem> _currentItems = new List<LabelItem>();
        private List<LabelItem> _printItems;
        private int _printIndex, _currentCopy;
        private string _storeName;

        private readonly Dictionary<string, SizeF> _labelSizes = new Dictionary<string, SizeF>
        {
            { "Küçük (50x30 mm)", new SizeF(50f, 30f) },
            { "Orta (60x40 mm)", new SizeF(60f, 40f) },
            { "Büyük (80x50 mm)", new SizeF(80f, 50f) },
            { "Geniş (100x60 mm)", new SizeF(100f, 60f) }
        };

        /// <summary>Yazdırma için ortak veri yapısı</summary>
        private class LabelItem
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string Barcode { get; set; }
            public decimal Price { get; set; }
            public decimal? OldPrice { get; set; }
            public bool IsChangeLog { get; set; }
            public bool LabelPrinted { get; set; }
        }

        public RafEtiketiForm()
        {
            this.Text = "🏷️ Raf Etiketi Yazdırma";
            this.Size = new Size(1100, 700);
            this.MinimumSize = new Size(850, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.BackColor = ThemeManager.ContentBg;
            this.KeyPreview = true;
            this.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) this.Close(); };

            try { _storeName = AyarlarUC.GetStoreName(); } catch { _storeName = "MARKET"; }

            BuildUI();
            SwitchTab(true); // Varsayılan: Tüm Ürünler
        }

        private void BuildUI()
        {
            // ── Başlık ──
            lblTitle = new Label
            {
                Text = "🏷️  RAF ETİKETİ YAZDIRMA",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = ThemeManager.TextPrimary,
                Dock = DockStyle.Top, Height = 50,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(16, 0, 0, 0),
                BackColor = ThemeManager.CardBg
            };
            this.Controls.Add(lblTitle);

            // ── Sekme Butonları ──
            pnlTabs = new Panel { Dock = DockStyle.Top, Height = 44, BackColor = ThemeManager.CardBg };
            btnTabAll = new Button
            {
                Text = "📦 Tüm Ürünler", Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                Size = new Size(180, 38), Location = new Point(16, 3), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand
            };
            btnTabChanged = new Button
            {
                Text = "🔄 Fiyat Değişenler", Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold),
                Size = new Size(200, 38), Location = new Point(200, 3), FlatStyle = FlatStyle.Flat, Cursor = Cursors.Hand
            };
            btnTabAll.FlatAppearance.BorderSize = 0;
            btnTabChanged.FlatAppearance.BorderSize = 0;
            btnTabAll.Click += (s, e) => SwitchTab(true);
            btnTabChanged.Click += (s, e) => SwitchTab(false);
            pnlTabs.Controls.AddRange(new Control[] { btnTabAll, btnTabChanged });
            this.Controls.Add(pnlTabs);

            // ── Araç Çubuğu ──
            pnlToolbar = new Panel { Dock = DockStyle.Top, Height = 52, BackColor = ThemeManager.SurfaceBg, Padding = new Padding(10, 6, 10, 6) };

            txtSearch = new TextBox { Font = new Font("Segoe UI", 10F), Width = 180, Location = new Point(12, 12), Text = "Ürün ara...", ForeColor = Color.Gray };
            txtSearch.GotFocus += (s, e) => { if (txtSearch.Text == "Ürün ara...") { txtSearch.Text = ""; txtSearch.ForeColor = ThemeManager.TextPrimary; } };
            txtSearch.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(txtSearch.Text)) { txtSearch.Text = "Ürün ara..."; txtSearch.ForeColor = Color.Gray; } };
            txtSearch.TextChanged += (s, e) => { if (txtSearch.Text != "Ürün ara...") LoadData(); };
            pnlToolbar.Controls.Add(txtSearch);

            pnlToolbar.Controls.Add(new Label { Text = "Boyut:", Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold), ForeColor = ThemeManager.TextPrimary, AutoSize = true, Location = new Point(205, 15) });
            cmbLabelSize = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9F), Width = 155, Location = new Point(250, 11) };
            foreach (var s in _labelSizes.Keys) cmbLabelSize.Items.Add(s);
            cmbLabelSize.SelectedIndex = 1;
            pnlToolbar.Controls.Add(cmbLabelSize);

            chkShowOldPrice = new CheckBox { Text = "Eski Fiyatı Göster", Font = new Font("Segoe UI", 9F), ForeColor = ThemeManager.TextPrimary, AutoSize = true, Checked = true, Location = new Point(420, 14) };
            pnlToolbar.Controls.Add(chkShowOldPrice);

            pnlToolbar.Controls.Add(new Label { Text = "Kopya:", Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold), ForeColor = ThemeManager.TextPrimary, AutoSize = true, Location = new Point(575, 15) });
            numCopies = new NumericUpDown { Minimum = 1, Maximum = 20, Value = 1, Font = new Font("Segoe UI", 9F), Width = 55, Location = new Point(625, 11) };
            pnlToolbar.Controls.Add(numCopies);

            lblCount = new Label { Text = "", Font = new Font("Segoe UI", 9F), ForeColor = ThemeManager.TextSecondary, AutoSize = true, Location = new Point(700, 15) };
            pnlToolbar.Controls.Add(lblCount);
            this.Controls.Add(pnlToolbar);

            // ── Alt Buton Paneli ──
            var pnlBottom = new FlowLayoutPanel { Dock = DockStyle.Bottom, Height = 54, FlowDirection = FlowDirection.LeftToRight, BackColor = ThemeManager.FooterBg, Padding = new Padding(10, 7, 10, 7), WrapContents = false };
            btnSelectAll = MkBtn("☑ Tümünü Seç", ThemeManager.Primary, 140);
            btnDeselectAll = MkBtn("☐ Seçimi Kaldır", ThemeManager.Neutral, 150);
            btnPreview = MkBtn("👁 Önizleme", ThemeManager.Info, 130);
            btnPrintSelected = MkBtn("🖨 SEÇİLENLERİ YAZDIR", ThemeManager.Success, 220);
            btnDeletePrinted = MkBtn("🗑 Yazdırılanları Temizle", ThemeManager.Danger, 210);
            pnlBottom.Controls.AddRange(new Control[] { btnSelectAll, btnDeselectAll, btnPreview, btnPrintSelected, btnDeletePrinted });
            this.Controls.Add(pnlBottom);

            btnSelectAll.Click += (s, e) => SetAllChecked(true);
            btnDeselectAll.Click += (s, e) => SetAllChecked(false);
            btnPreview.Click += BtnPreview_Click;
            btnPrintSelected.Click += BtnPrintSelected_Click;
            btnDeletePrinted.Click += BtnDeletePrinted_Click;

            // ── DataGridView ──
            dgvMain = new DataGridView
            {
                Dock = DockStyle.Fill, AllowUserToAddRows = false, AllowUserToDeleteRows = false,
                ReadOnly = false, SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = true, AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false, ColumnHeadersHeight = 38
            };
            ThemeManager.StyleDataGridView(dgvMain);
            dgvMain.CellFormatting += DgvMain_CellFormatting;
            this.Controls.Add(dgvMain);
        }

        private Button MkBtn(string text, Color bg, int w)
        {
            var b = new Button { Text = text, Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold), Size = new Size(w, 36), Margin = new Padding(4, 0, 4, 0), Cursor = Cursors.Hand };
            ThemeManager.StyleButton(b, bg);
            return b;
        }

        // ———————— SEKME GEÇİŞİ ————————

        private void SwitchTab(bool allProducts)
        {
            _isAllProductsMode = allProducts;
            btnTabAll.BackColor = allProducts ? ThemeManager.Primary : ThemeManager.SurfaceBg;
            btnTabAll.ForeColor = allProducts ? Color.White : ThemeManager.TextPrimary;
            btnTabChanged.BackColor = !allProducts ? ThemeManager.Primary : ThemeManager.SurfaceBg;
            btnTabChanged.ForeColor = !allProducts ? Color.White : ThemeManager.TextPrimary;

            // Fiyat Değişenler sekmesine özel buton görünürlüğü
            btnDeletePrinted.Visible = !allProducts;
            chkShowOldPrice.Visible = !allProducts;

            SetupColumns();
            LoadData();
        }

        private void SetupColumns()
        {
            dgvMain.Columns.Clear();
            dgvMain.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Seç", HeaderText = "Seç", Width = 40, FillWeight = 30, AutoSizeMode = DataGridViewAutoSizeColumnMode.None });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "Barkod", HeaderText = "Barkod", FillWeight = 80 });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "Ürün", HeaderText = "Ürün Adı", FillWeight = 150 });
            dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fiyat", HeaderText = "Satış Fiyatı", FillWeight = 80 });

            if (!_isAllProductsMode)
            {
                dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "EskiFiyat", HeaderText = "Eski Fiyat", FillWeight = 70 });
                dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fark", HeaderText = "Fark", FillWeight = 60 });
                dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tarih", HeaderText = "Tarih", FillWeight = 90 });
                dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "Durum", HeaderText = "Etiket", FillWeight = 55 });
            }
            else
            {
                dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "Kategori", HeaderText = "Kategori", FillWeight = 80 });
                dgvMain.Columns.Add(new DataGridViewTextBoxColumn { Name = "Stok", HeaderText = "Stok", FillWeight = 50 });
            }

            for (int i = 1; i < dgvMain.Columns.Count; i++)
                dgvMain.Columns[i].ReadOnly = true;
        }

        // ———————— VERİ YÜKLEME ————————

        private void LoadData()
        {
            _currentItems.Clear();
            dgvMain.Rows.Clear();
            string search = (txtSearch.Text == "Ürün ara..." ? "" : txtSearch.Text?.Trim()) ?? "";

            try
            {
                using (var db = new AppDbContext())
                {
                    if (_isAllProductsMode)
                    {
                        var products = db.Products.Include(p => p.Category).Where(p => p.IsActive).ToList();
                        if (!string.IsNullOrEmpty(search))
                            products = products.Where(p =>
                                (p.Name != null && p.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                (p.Barcode != null && p.Barcode.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                            ).ToList();

                        foreach (var p in products.OrderBy(p => p.Name))
                        {
                            var item = new LabelItem { Id = p.Id, ProductName = p.Name, Barcode = p.Barcode, Price = p.SalePrice, OldPrice = null, IsChangeLog = false };
                            _currentItems.Add(item);
                            dgvMain.Rows.Add(false, p.Id, p.Barcode, p.Name,
                                p.SalePrice.ToString("N2") + " ₺",
                                p.Category?.Name ?? "-",
                                p.CurrentStock.ToString("N0"));
                        }
                        lblCount.Text = $"Toplam: {_currentItems.Count} ürün";
                    }
                    else
                    {
                        var logs = db.PriceChangeLogs.Include(l => l.Product).OrderByDescending(l => l.ChangeDate).ToList();
                        if (!string.IsNullOrEmpty(search))
                            logs = logs.Where(l =>
                                (l.ProductName != null && l.ProductName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) ||
                                (l.Barcode != null && l.Barcode.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                            ).ToList();

                        foreach (var log in logs)
                        {
                            var item = new LabelItem { Id = log.Id, ProductName = log.ProductName, Barcode = log.Barcode, Price = log.NewPrice, OldPrice = log.OldPrice, IsChangeLog = true, LabelPrinted = log.LabelPrinted };
                            _currentItems.Add(item);
                            decimal diff = log.NewPrice - log.OldPrice;
                            dgvMain.Rows.Add(!log.LabelPrinted, log.Id, log.Barcode, log.ProductName,
                                log.NewPrice.ToString("N2") + " ₺",
                                log.OldPrice.ToString("N2") + " ₺",
                                (diff >= 0 ? "+" : "") + diff.ToString("N2") + " ₺",
                                log.ChangeDate.ToLocalTime().ToString("dd.MM.yyyy HH:mm"),
                                log.LabelPrinted ? "✅ Basıldı" : "⏳ Bekliyor");
                        }
                        int pending = logs.Count(x => !x.LabelPrinted);
                        lblCount.Text = $"Toplam: {logs.Count} değişiklik ({pending} bekleyen)";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken hata:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ———————— RENKLENDİRME ————————

        private void DgvMain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _currentItems.Count) return;
            var item = _currentItems[e.RowIndex];

            if (!_isAllProductsMode && dgvMain.Columns[e.ColumnIndex].Name == "Fark" && item.OldPrice.HasValue)
            {
                decimal diff = item.Price - item.OldPrice.Value;
                e.CellStyle.ForeColor = diff > 0 ? ThemeManager.Danger : ThemeManager.Success;
                e.CellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }

            if (item.IsChangeLog && item.LabelPrinted && dgvMain.Columns[e.ColumnIndex].Name != "Seç")
                e.CellStyle.ForeColor = ThemeManager.TextMuted;

            if (dgvMain.Columns[e.ColumnIndex].Name == "Fiyat")
                e.CellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        // ———————— SEÇİM ————————

        private void SetAllChecked(bool check)
        {
            foreach (DataGridViewRow row in dgvMain.Rows)
                row.Cells["Seç"].Value = check;
            dgvMain.RefreshEdit();
        }

        private List<LabelItem> GetSelectedItems()
        {
            dgvMain.EndEdit();
            var selected = new List<LabelItem>();
            for (int i = 0; i < dgvMain.Rows.Count && i < _currentItems.Count; i++)
            {
                bool isChecked = dgvMain.Rows[i].Cells["Seç"].Value != null && (bool)dgvMain.Rows[i].Cells["Seç"].Value;
                if (isChecked) selected.Add(_currentItems[i]);
            }
            return selected;
        }

        // ———————— YAZDIRMA ————————

        private PrintDocument CreatePrintDoc()
        {
            var doc = new PrintDocument { DocumentName = "Raf Etiketi" };
            doc.PrintPage += PrintPage_Handler;
            var sz = GetSelectedLabelSizeMM();
            doc.DefaultPageSettings.PaperSize = new PaperSize("RafEtiketi", (int)(sz.Width / 25.4f * 100f), (int)(sz.Height / 25.4f * 100f));
            doc.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
            return doc;
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            _printItems = GetSelectedItems();
            if (_printItems.Count == 0) { MessageBox.Show("Lütfen en az bir ürün seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            _printIndex = 0; _currentCopy = 0;
            var preview = new PrintPreviewDialog { Document = CreatePrintDoc(), Width = 800, Height = 600, StartPosition = FormStartPosition.CenterParent };
            preview.ShowDialog(this);
        }

        private void BtnPrintSelected_Click(object sender, EventArgs e)
        {
            _printItems = GetSelectedItems();
            if (_printItems.Count == 0) { MessageBox.Show("Lütfen en az bir ürün seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (MessageBox.Show($"{_printItems.Count} ürün için raf etiketi yazdırılacak.\nDevam?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            _printIndex = 0; _currentCopy = 0;
            var doc = CreatePrintDoc();
            try
            {
                var dlg = new PrintDialog { Document = doc, UseEXDialog = true };
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    doc.Print();
                    // Fiyat değişikliği loglarını basıldı işaretle
                    var changeLogs = _printItems.Where(x => x.IsChangeLog).ToList();
                    if (changeLogs.Count > 0) MarkAsPrinted(changeLogs);
                    LoadData();
                    MessageBox.Show("Etiketler başarıyla yazdırıldı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show("Yazdırma hatası:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void PrintPage_Handler(object sender, PrintPageEventArgs e)
        {
            if (_printIndex >= _printItems.Count) { e.HasMorePages = false; return; }
            var item = _printItems[_printIndex];
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            DrawLabel(g, e.MarginBounds, item);

            _currentCopy++;
            if (_currentCopy >= (int)numCopies.Value) { _currentCopy = 0; _printIndex++; }
            e.HasMorePages = _printIndex < _printItems.Count;
        }

        private void DrawLabel(Graphics g, Rectangle bounds, LabelItem item)
        {
            int pad = 4, x = bounds.X + pad, y = bounds.Y + pad;
            int w = bounds.Width - pad * 2, h = bounds.Height - pad * 2;

            using (var pen = new Pen(Color.FromArgb(30, 41, 59), 2f)) g.DrawRectangle(pen, x, y, w, h);

            // Mağaza adı bandı
            int hdrH = h / 6;
            using (var br = new SolidBrush(Color.FromArgb(30, 41, 59))) g.FillRectangle(br, x, y, w, hdrH);
            using (var f = new Font("Segoe UI", Math.Max(6f, w / 20f), FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString(_storeName, f, Brushes.White, new RectangleF(x, y, w, hdrH), sf);

            // Ürün adı
            int nameY = y + hdrH + 2, nameH = h / 5;
            using (var f = new Font("Segoe UI Semibold", Math.Max(6f, w / 18f), FontStyle.Bold))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center, Trimming = StringTrimming.EllipsisCharacter })
                g.DrawString(item.ProductName, f, Brushes.Black, new RectangleF(x, nameY, w, nameH), sf);

            // Eski fiyat (sadece fiyat değişikliği varsa ve checkbox işaretliyse)
            int priceY = nameY + nameH;
            bool showOld = chkShowOldPrice.Checked && item.OldPrice.HasValue && item.OldPrice.Value != item.Price;
            if (showOld)
            {
                int oldH = h / 8;
                using (var f = new Font("Segoe UI", Math.Max(5f, w / 25f), FontStyle.Strikeout))
                using (var br = new SolidBrush(Color.FromArgb(148, 163, 184)))
                using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                    g.DrawString(item.OldPrice.Value.ToString("N2") + " ₺", f, br, new RectangleF(x, priceY, w, oldH), sf);
                priceY += oldH;
            }

            // Fiyat (büyük)
            int priceH = (int)(h * 0.32f);
            using (var f = new Font("Segoe UI", Math.Max(10f, w / 8f), FontStyle.Bold))
            using (var br = new SolidBrush(Color.FromArgb(220, 38, 38)))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString(item.Price.ToString("N2") + " ₺", f, br, new RectangleF(x, priceY, w, priceH), sf);

            // Barkod
            int bcY = y + h - (h / 7), bcH = h / 7;
            using (var f = new Font("Consolas", Math.Max(5f, w / 28f)))
            using (var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                g.DrawString(item.Barcode, f, Brushes.DarkSlateGray, new RectangleF(x, bcY, w, bcH), sf);
        }

        private SizeF GetSelectedLabelSizeMM()
        {
            if (cmbLabelSize.SelectedItem != null && _labelSizes.ContainsKey(cmbLabelSize.SelectedItem.ToString()))
                return _labelSizes[cmbLabelSize.SelectedItem.ToString()];
            return new SizeF(60f, 40f);
        }

        // ———————— DB İŞLEMLERİ ————————

        private void MarkAsPrinted(List<LabelItem> items)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    foreach (var it in items)
                    {
                        var log = db.PriceChangeLogs.Find(it.Id);
                        if (log != null) log.LabelPrinted = true;
                    }
                    db.SaveChanges();
                }
            }
            catch { }
        }

        private void BtnDeletePrinted_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yazdırılmış tüm etiket kayıtları silinecek.\nDevam?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                using (var db = new AppDbContext())
                {
                    var printed = db.PriceChangeLogs.Where(l => l.LabelPrinted).ToList();
                    db.PriceChangeLogs.RemoveRange(printed);
                    db.SaveChanges();
                }
                LoadData();
                MessageBox.Show("Yazdırılmış kayıtlar temizlendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("Hata:\n" + ex.Message); }
        }

        // ———————— DIŞARIDAN ÇAĞRILAN YARDIMCI ————————

        /// <summary>Fiyat değişikliğini PriceChangeLog tablosuna kaydeder.</summary>
        public static void LogPriceChange(int productId, string productName, string barcode, decimal oldPrice, decimal newPrice)
        {
            if (oldPrice == newPrice) return;
            try
            {
                using (var db = new AppDbContext())
                {
                    db.PriceChangeLogs.Add(new PriceChangeLog
                    {
                        ProductId = productId, ProductName = productName, Barcode = barcode,
                        OldPrice = oldPrice, NewPrice = newPrice, ChangeDate = DateTime.Now, LabelPrinted = false
                    });
                    db.SaveChanges();
                }
            }
            catch { }
        }
    }
}
