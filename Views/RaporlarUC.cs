using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ÜrünTakip.Data;

namespace ÜrünTakip.Views
{
    public partial class RaporlarUC : UserControl
    {
        private List<int> _dailySaleIds = new List<int>();
        public RaporlarUC()
        {
            InitializeComponent();
            ApplyTheme();
            this.Load += (s, e) => { 
                var today = DateTime.Today;
                dtpReportStartDate.Value = today;
                dtpReportEndDate.Value = today;
                RefreshReport(); 
            };
            btnRefresh.Click += (s, e) => RefreshReport();
            dtpReportStartDate.ValueChanged += (s, e) => {
                if (dtpReportStartDate.Value > dtpReportEndDate.Value)
                {
                    MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpReportStartDate.Value = dtpReportEndDate.Value;
                    return;
                }
                RefreshReport();
            };
            dtpReportEndDate.ValueChanged += (s, e) => {
                if (dtpReportStartDate.Value > dtpReportEndDate.Value)
                {
                    MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpReportEndDate.Value = dtpReportStartDate.Value;
                    return;
                }
                RefreshReport();
            };

            btnMenuSummary.Click += (s, e) => ShowPanel(pnlSummary);
            btnMenuTop.Click += (s, e) => ShowPanel(pnlTopProducts);
            btnMenuLow.Click += (s, e) => ShowPanel(pnlLowStock);
            btnMenuDetail.Click += (s, e) => ShowPanel(pnlDailySalesDetail);
            dgvDailySalesDetail.CellDoubleClick += DgvDailySalesDetail_CellDoubleClick;
            
            btnBack.Click += (s, e) => {
                pnlSummary.Visible = false;
                pnlTopProducts.Visible = false;
                pnlLowStock.Visible = false;
                pnlDailySalesDetail.Visible = false;
                pnlMenu.Visible = true;
                btnBack.Visible = false;
            };
        }

        private void ShowPanel(Panel pnl)
        {
            pnlMenu.Visible = false;
            pnlSummary.Visible = false;
            pnlTopProducts.Visible = false;
            pnlLowStock.Visible = false;
            pnlDailySalesDetail.Visible = false;
            
            pnl.Visible = true;
            btnBack.Visible = true;
        }

        private void RefreshReport()
        {
            using (var db = new AppDbContext())
            {
                var startDate = dtpReportStartDate.Value.Date;
                var endDate = dtpReportEndDate.Value.Date.AddDays(1);

                // Günlük satış özeti
                var dailySales = db.Sales.Where(s => s.SaleDate >= startDate && s.SaleDate < endDate).ToList();
                decimal totalCiro = dailySales.Sum(s => s.TotalAmount);
                decimal totalVat = dailySales.Sum(s => s.VatTotal);
                int saleCount = dailySales.Count;

                lblDailySales.Text = $"Toplam Ciro: {totalCiro:C2}";
                lblDailyVat.Text = $"KDV Toplamı: {totalVat:C2}";
                lblDailyCount.Text = $"Satış Adedi: {saleCount}";

                // Brüt kâr hesabı (satış anındaki maliyet fiyatı üzerinden)
                var saleIds = dailySales.Select(s => s.Id).ToList();
                var saleItems = db.SaleItems.Where(si => saleIds.Contains(si.SaleId)).ToList();
                decimal totalProfit = 0;
                var profitBySaleId = new Dictionary<int, decimal>();
                
                foreach (var si in saleItems)
                {
                    decimal costPrice = si.PurchasePriceAtSale;
                    // Eski satışlar için fallback (migration öncesi kayıtlar)
                    if (costPrice == 0 && si.ProductId != null)
                    {
                        var product = db.Products.Find(si.ProductId);
                        if (product != null) costPrice = product.PurchasePrice;
                    }
                    decimal itemProfit = (si.UnitPrice - costPrice) * si.Quantity;
                    totalProfit += itemProfit;
                    
                    if (profitBySaleId.ContainsKey(si.SaleId))
                        profitBySaleId[si.SaleId] += itemProfit;
                    else
                        profitBySaleId[si.SaleId] = itemProfit;
                }
                lblDailyProfit.Text = $"Brüt Kâr: {totalProfit:C2}";

                // En çok satan 10 ürün (seçilen tarih aralığı)
                var topProducts = saleItems
                    .GroupBy(si => si.ProductName)
                    .Select(g => new { Ürün = g.Key, ToplamSatış = g.Sum(x => x.Quantity) })
                    .OrderByDescending(x => x.ToplamSatış)
                    .Take(10)
                    .ToList();
                dgvTopProducts.DataSource = topProducts;

                // Kritik stok (3 altı)
                var lowStock = db.Products
                    .Where(p => p.IsActive && p.CurrentStock < 3)
                    .Select(p => new { p.Name, Stok = p.CurrentStock, p.Barcode })
                    .OrderBy(p => p.Stok)
                    .ToList();
                dgvLowStock.DataSource = lowStock;

                // Günlük satış detayları tablosu
                var orderedSales = dailySales.OrderByDescending(s => s.SaleDate).ToList();
                _dailySaleIds = orderedSales.Select(s => s.Id).ToList();

                var salesDetail = orderedSales
                    .Select(s => new
                    {
                        Saat = s.SaleDate.ToString("dd.MM.yyyy HH:mm:ss"),
                        Kasiyer = s.CashierName ?? "-",
                        Ödeme = s.PaymentType ?? "-",
                        Ürünler = string.Join(", ", saleItems
                            .Where(si => si.SaleId == s.Id)
                            .Select(si => $"{si.ProductName} x{si.Quantity}")),
                        Kasa = s.RegisterId > 0 ? $"Kasa {s.RegisterId}" : "-",
                        Toplam = s.TotalAmount.ToString("C2"),
                        Kâr = profitBySaleId.ContainsKey(s.Id) ? profitBySaleId[s.Id].ToString("C2") : 0.ToString("C2")
                    })
                    .ToList();
                dgvDailySalesDetail.DataSource = salesDetail;
            }
        }

        private void DgvDailySalesDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _dailySaleIds.Count) return;

            int saleId = _dailySaleIds[e.RowIndex];

            using (var db = new AppDbContext())
            {
                var sale = db.Sales.FirstOrDefault(s => s.Id == saleId);
                if (sale == null) return;

                var items = db.SaleItems
                    .Where(si => si.SaleId == saleId)
                    .ToList()
                    .Select(si => new
                    {
                        Ürün = si.ProductName,
                        Adet = si.Quantity,
                        BirimFiyat = si.UnitPrice.ToString("C2"),
                        KDV = si.VatRate + "%",
                        SatırToplam = si.LineTotal.ToString("C2"),
                        Maliyet = si.PurchasePriceAtSale.ToString("C2")
                    })
                    .ToList();

                // ─── Popup Formu oluştur ───
                var popup = new Form();
                popup.Text = $"Satış Detayı — #{saleId}";
                popup.StartPosition = FormStartPosition.CenterScreen;
                popup.Size = new Size(950, 650);
                popup.MinimumSize = new Size(700, 400);
                popup.BackColor = Color.FromArgb(22, 27, 34);
                popup.ForeColor = Color.White;
                popup.FormBorderStyle = FormBorderStyle.Sizable;
                popup.MaximizeBox = true;
                popup.MinimizeBox = false;
                popup.ShowInTaskbar = false;
                popup.KeyPreview = true;
                popup.KeyDown += (s2, e2) => { if (e2.KeyCode == Keys.Escape) popup.Close(); };

                // Başlık paneli
                var pnlTitle = new Panel();
                pnlTitle.Dock = DockStyle.Top;
                pnlTitle.Height = 110;
                pnlTitle.BackColor = Color.FromArgb(30, 41, 59);
                pnlTitle.Padding = new Padding(25, 15, 25, 10);

                var lblTitle = new Label();
                lblTitle.Text = $"🧾  Satış #{saleId} — Ürün Detayları";
                lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
                lblTitle.ForeColor = Color.FromArgb(147, 197, 253);
                lblTitle.Dock = DockStyle.Top;
                lblTitle.Height = 45;

                var lblInfo = new Label();
                lblInfo.Text = $"📅 {sale.SaleDate:dd.MM.yyyy}   🕐 {sale.SaleDate:HH:mm:ss}   👤 {sale.CashierName ?? "-"}   💳 {sale.PaymentType ?? "-"}   💰 Toplam: {sale.TotalAmount:C2}";
                lblInfo.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                lblInfo.ForeColor = Color.FromArgb(200, 200, 220);
                lblInfo.Dock = DockStyle.Bottom;
                lblInfo.Height = 35;

                pnlTitle.Controls.Add(lblInfo);
                pnlTitle.Controls.Add(lblTitle);

                // DataGridView
                var dgv = new DataGridView();
                dgv.Dock = DockStyle.Fill;
                dgv.DataSource = items;
                dgv.AllowUserToAddRows = false;
                dgv.ReadOnly = true;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.BackgroundColor = Color.FromArgb(30, 41, 59);
                dgv.GridColor = Color.FromArgb(51, 65, 85);
                dgv.BorderStyle = BorderStyle.None;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.RowHeadersVisible = false;
                dgv.EnableHeadersVisualStyles = false;

                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 65, 85);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(147, 197, 253);
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.ColumnHeadersHeight = 50;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                dgv.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(37, 99, 235);
                dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                dgv.DefaultCellStyle.Font = new Font("Segoe UI", 13F);
                dgv.DefaultCellStyle.Padding = new Padding(8, 5, 8, 5);
                dgv.RowTemplate.Height = 48;

                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(36, 48, 67);

                // Alt bilgi paneli
                var pnlBottom = new Panel();
                pnlBottom.Dock = DockStyle.Bottom;
                pnlBottom.Height = 65;
                pnlBottom.BackColor = Color.FromArgb(30, 41, 59);
                pnlBottom.Padding = new Padding(20, 10, 20, 10);

                var lblItemCount = new Label();
                lblItemCount.Text = $"Toplam {items.Count} kalem ürün";
                lblItemCount.Font = new Font("Segoe UI", 12F, FontStyle.Italic);
                lblItemCount.ForeColor = Color.FromArgb(160, 170, 200);
                lblItemCount.Dock = DockStyle.Left;
                lblItemCount.AutoSize = true;
                lblItemCount.Padding = new Padding(0, 8, 0, 0);

                var btnClose = new Button();
                btnClose.Text = "✖  KAPAT";
                btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                btnClose.Size = new Size(150, 42);
                btnClose.Dock = DockStyle.Right;
                btnClose.FlatStyle = FlatStyle.Flat;
                btnClose.BackColor = ThemeManager.Danger;
                btnClose.ForeColor = Color.White;
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Cursor = Cursors.Hand;
                btnClose.Click += (s3, e3) => popup.Close();

                pnlBottom.Controls.Add(lblItemCount);
                pnlBottom.Controls.Add(btnClose);

                popup.Controls.Add(dgv);
                popup.Controls.Add(pnlTitle);
                popup.Controls.Add(pnlBottom);

                popup.ShowDialog();
            }
        }

        private void ApplyTheme()
        {
            // Header
            pnlHeader.BackColor = ThemeManager.SurfaceBg;
            ThemeManager.StyleButton(btnRefresh, ThemeManager.Primary);
            btnBack.BackColor = ThemeManager.Danger;
            btnBack.ForeColor = Color.White;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;

            // Menü kartları
            ThemeManager.StyleButton(btnMenuSummary, ThemeManager.ReportGreen);
            ThemeManager.StyleButton(btnMenuTop, ThemeManager.ReportGold);
            ThemeManager.StyleButton(btnMenuLow, ThemeManager.Danger);
            ThemeManager.StyleButton(btnMenuDetail, ThemeManager.ReportSlate);

            // Özet etiketleri
            lblDailySales.ForeColor = ThemeManager.TotalGreen;
            lblDailyProfit.ForeColor = ThemeManager.Primary;

            // Alt başlıklar
            lblTopTitle.BackColor = Color.FromArgb(254, 249, 195);
            lblLowStockTitle.BackColor = Color.FromArgb(254, 226, 226);
            lblDailySalesDetailTitle.BackColor = Color.FromArgb(219, 234, 254);

            // DataGridView'ler
            ThemeManager.StyleDataGridView(dgvTopProducts);
            ThemeManager.StyleDataGridView(dgvLowStock);
            ThemeManager.StyleDataGridView(dgvDailySalesDetail);
        }
    }
}

