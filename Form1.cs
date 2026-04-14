using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ÜrünTakip.Data;
using ÜrünTakip.Models;
using ÜrünTakip.Views;

namespace ÜrünTakip
{
    public partial class Form1 : Form
    {
        // UserControl instances
        private StokIslemleriUC stokUC;
        private VeresiyeDefterUC veresiyeUC;
        private EFaturaUC efaturaUC;
        private RaporlarUC raporlarUC;
        private AyarlarUC ayarlarUC;

        // Sepet verileri (Kasa ekranı)
        private List<CartItem> _cart = new List<CartItem>();
        private decimal _cartTotal = 0;

        public Form1()
        {
            InitializeComponent();

            // UserControl'leri oluştur ve dinamik panele ekle
            stokUC = new StokIslemleriUC() { Dock = DockStyle.Fill, Visible = false };
            veresiyeUC = new VeresiyeDefterUC() { Dock = DockStyle.Fill, Visible = false };
            efaturaUC = new EFaturaUC() { Dock = DockStyle.Fill, Visible = false };
            raporlarUC = new RaporlarUC() { Dock = DockStyle.Fill, Visible = false };
            ayarlarUC = new AyarlarUC() { Dock = DockStyle.Fill, Visible = false };

            pnlDynamicContent.Controls.Add(stokUC);
            pnlDynamicContent.Controls.Add(veresiyeUC);
            pnlDynamicContent.Controls.Add(efaturaUC);
            pnlDynamicContent.Controls.Add(raporlarUC);
            pnlDynamicContent.Controls.Add(ayarlarUC);

            SetupCustomEvents();
            LoadTouchGridProducts();
            UpdateCartDisplay();

            // Personel listesini yükle
            RefreshPersonnelList();

            // Klavye kısayolları
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void RefreshPersonnelList()
        {
            string currentSelection = cmbPersonnel.SelectedItem?.ToString();
            cmbPersonnel.Items.Clear();
            foreach (var p in AyarlarUC.GetPersonnelList())
                if (!string.IsNullOrWhiteSpace(p)) cmbPersonnel.Items.Add(p.Trim());
            if (!string.IsNullOrEmpty(currentSelection) && cmbPersonnel.Items.Contains(currentSelection))
                cmbPersonnel.SelectedItem = currentSelection;
            else if (cmbPersonnel.Items.Count > 0)
                cmbPersonnel.SelectedIndex = 0;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F11: CompleteSale("Nakit"); e.Handled = true; break;
                case Keys.F12: CompleteSale("Kart"); e.Handled = true; break;
                case Keys.F10: CompleteSaleNakitKart(); e.Handled = true; break;
                case Keys.F8: CompleteSaleVeresiye(); e.Handled = true; break;
                case Keys.F5: CompleteSale("Diğer"); e.Handled = true; break;
            }
        }

        private void SetupCustomEvents()
        {
            // Kapat
            btnKapat.Click += (s, e) =>
            {
                if (MessageBox.Show("Uygulamayı kapatmak istiyor musunuz?", "Çıkış", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    Application.Exit();
            };

            // Sidebar tab geçişleri
            btnKasa.Click += delegate { SayfaDegistir("Kasa"); };
            btnStok.Click += delegate { SayfaDegistir("Stok İşlemleri"); };
            btnVeresiyeDefteri.Click += delegate { SayfaDegistir("Veresiye Defteri"); };
            btnEFatura.Click += delegate { SayfaDegistir("e-Fatura"); };
            btnRaporlar.Click += delegate { SayfaDegistir("Raporlar"); };
            btnAyarlar.Click += delegate { SayfaDegistir("Ayarlar"); };

            // Barkod ile ürün ekleme (Enter tuşu)
            txtBarcode.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    AddProductByBarcode(txtBarcode.Text.Trim());
                    txtBarcode.Clear();
                }
            };
            // Barkod alanına tıklayınca default yazıyı temizle
            txtBarcode.GotFocus += (s, e) => { if (txtBarcode.Text == "Barkod Okutunuz...") txtBarcode.Clear(); };
            txtBarcode.LostFocus += (s, e) => { if (string.IsNullOrWhiteSpace(txtBarcode.Text)) txtBarcode.Text = "Barkod Okutunuz..."; };

            // DataGrid satır silme butonu
            dgvSales.CellClick += DgvSales_CellClick;

            // Banknot tuşları - Alınan paraya ekle
            btn5TL.Click += (s, e) => AddBanknote(5);
            btn10TL.Click += (s, e) => AddBanknote(10);
            btn20TL.Click += (s, e) => AddBanknote(20);
            btn50TL.Click += (s, e) => AddBanknote(50);
            btn100TL.Click += (s, e) => AddBanknote(100);
            btn200TL.Click += (s, e) => AddBanknote(200);

            // Alınan para elle yazıldığında para üstü hesapla
            txtAlinan.TextChanged += AlinanTextChanged;
            btnClearAlinan.Click += (s, e) => {
                txtAlinan.TextChanged -= AlinanTextChanged;
                txtAlinan.Text = "0,00";
                txtParaUstu.Text = "0,00";
                txtParaUstu.ForeColor = Color.Red;
                txtAlinan.TextChanged += AlinanTextChanged;
            };

            // Satış butonları
            btnNakit.Click += (s, e) => CompleteSale("Nakit");
            btnKrediKarti.Click += (s, e) => CompleteSale("Kart");
            btnNakitKart.Click += (s, e) => CompleteSaleNakitKart();
            btnVeresiye.Click += (s, e) => CompleteSaleVeresiye();
            btnDiger.Click += (s, e) => CompleteSale("Diğer");
        }

        private void AlinanTextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        // ————————————————— SAYFA GEÇİŞLERİ —————————————————

        private void HideAllUC()
        {
            stokUC.Visible = false;
            veresiyeUC.Visible = false;
            efaturaUC.Visible = false;
            raporlarUC.Visible = false;
            ayarlarUC.Visible = false;
            lblDynamicContentTitle.Visible = false;
        }

        private void SayfaDegistir(string sayfaAdi)
        {
            if (sayfaAdi == "Kasa")
            {
                pnlDynamicContent.Visible = false;
                tlpMiddle.Visible = true;
                flpFooter.Visible = true;
                lblTotalTitle.Text = "KASA TOPLAM:";
                UpdateCartDisplay();
                lblTotalValue.ForeColor = Color.ForestGreen;
                RefreshPersonnelList();
                LoadTouchGridProducts();
            }
            else
            {
                tlpMiddle.Visible = false;
                flpFooter.Visible = false;
                pnlDynamicContent.Visible = true;
                HideAllUC();

                switch (sayfaAdi)
                {
                    case "Stok İşlemleri": stokUC.Visible = true; break;
                    case "Veresiye Defteri": veresiyeUC.Visible = true; break;
                    case "e-Fatura": efaturaUC.Visible = true; break;
                    case "Raporlar": raporlarUC.Visible = true; break;
                    case "Ayarlar": ayarlarUC.Visible = true; break;
                }

                lblTotalTitle.Text = "BÖLÜM:";
                lblTotalValue.Text = sayfaAdi;
                lblTotalValue.ForeColor = Color.SteelBlue;
            }
        }

        // ————————————————— DOKUNMATİK ÜRÜN GRID —————————————————

        private void LoadTouchGridProducts()
        {
            tlpTouchGrid.Controls.Clear();
            try
            {
                using (var db = new AppDbContext())
                {
                    var products = db.Products.Where(p => p.IsActive).Take(20).ToList();
                    foreach (var prod in products)
                    {
                        Button btn = new Button();
                        btn.Dock = DockStyle.Fill;
                        btn.Text = prod.Name + "\n" + prod.SalePrice.ToString("N2") + " ₺";
                        btn.BackColor = Color.WhiteSmoke;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.Tag = prod.Id;
                        btn.Click += TouchProductBtn_Click;
                        tlpTouchGrid.Controls.Add(btn);
                    }
                    // Kalan boş alan doldur
                    for (int i = products.Count; i < 20; i++)
                    {
                        Button btn = new Button();
                        btn.Dock = DockStyle.Fill;
                        btn.Text = "";
                        btn.BackColor = Color.WhiteSmoke;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.Enabled = false;
                        tlpTouchGrid.Controls.Add(btn);
                    }
                }
            }
            catch
            {
                for (int i = 0; i < 20; i++)
                {
                    Button btn = new Button();
                    btn.Dock = DockStyle.Fill;
                    btn.Text = "Ürün " + (i + 1);
                    btn.BackColor = Color.WhiteSmoke;
                    btn.FlatStyle = FlatStyle.Flat;
                    tlpTouchGrid.Controls.Add(btn);
                }
            }
        }

        private void TouchProductBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag == null) return;
            int productId = (int)btn.Tag;
            AddProductById(productId);
        }

        // ————————————————— SEPETE ÜRÜN EKLEME —————————————————

        private void AddProductByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode)) return;
            using (var db = new AppDbContext())
            {
                var product = db.Products.FirstOrDefault(p => p.Barcode == barcode && p.IsActive);
                if (product == null)
                {
                    MessageBox.Show("Bu barkoda ait ürün bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                AddToCart(product);
            }
        }

        private void AddProductById(int productId)
        {
            using (var db = new AppDbContext())
            {
                var product = db.Products.Find(productId);
                if (product == null || !product.IsActive) return;
                AddToCart(product);
            }
        }

        private void AddToCart(Product product)
        {
            // Eğer aynı ürün zaten sepette varsa miktarını artır
            var existing = _cart.FirstOrDefault(c => c.ProductId == product.Id);
            if (existing != null)
            {
                existing.Quantity++;
                existing.LineTotal = existing.Quantity * existing.UnitPrice;
            }
            else
            {
                _cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = 1,
                    UnitPrice = product.SalePrice,
                    VatRate = product.VatRate,
                    LineTotal = product.SalePrice
                });
            }
            lblSelectedProduct.Text = $"  Seçili Ürün: {product.Name} | Stok: {product.CurrentStock}";
            RefreshCartGrid();
        }

        private void RefreshCartGrid()
        {
            dgvSales.Rows.Clear();
            _cartTotal = 0;
            foreach (var item in _cart)
            {
                dgvSales.Rows.Add(item.ProductName, item.Quantity.ToString("N0"), item.UnitPrice.ToString("N2"), item.LineTotal.ToString("N2"), $"%{item.VatRate}", "✖");
                _cartTotal += item.LineTotal;
            }
            UpdateCartDisplay();
            CalculateChange();
        }

        private void UpdateCartDisplay()
        {
            lblTotalValue.Text = _cartTotal.ToString("N2") + " ₺";
        }

        // ————————————————— GRID SİLME —————————————————

        private void DgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            // SİL sütunu (son sütun)
            if (e.ColumnIndex == dgvSales.Columns.Count - 1)
            {
                if (e.RowIndex < _cart.Count)
                {
                    _cart.RemoveAt(e.RowIndex);
                    RefreshCartGrid();
                }
            }
        }

        // ————————————————— BANKNOT & PARA ÜSTÜ —————————————————

        private void AddBanknote(int amount)
        {
            decimal current = 0;
            decimal.TryParse(txtAlinan.Text.Replace("₺", "").Trim(), out current);
            current += amount;
            txtAlinan.Text = current.ToString("N2");
        }

        private void CalculateChange()
        {
            decimal paid = 0;
            decimal.TryParse(txtAlinan.Text.Replace("₺", "").Trim(), out paid);
            decimal change = paid - _cartTotal;
            txtParaUstu.Text = change >= 0 ? change.ToString("N2") : "0,00";
            txtParaUstu.ForeColor = change >= 0 ? Color.ForestGreen : Color.Red;
        }

        // ————————————————— SATIŞ TAMAMLAMA —————————————————

        private void CompleteSale(string paymentType)
        {
            if (_cart.Count == 0) { MessageBox.Show("Sepet boş! Önce ürün ekleyin."); return; }

            try
            {
                using (var db = new AppDbContext())
                {
                    // KDV toplamı hesapla
                    decimal vatTotal = 0;
                    foreach (var item in _cart)
                    {
                        vatTotal += item.LineTotal * (item.VatRate / 100m);
                    }

                    // Satış kaydı oluştur
                    var sale = new Sale
                    {
                        SaleDate = DateTime.Now,
                        TotalAmount = _cartTotal,
                        VatTotal = vatTotal,
                        PaymentType = paymentType,
                        CashierName = cmbPersonnel.SelectedItem?.ToString() ?? "Bilinmiyor"
                    };
                    db.Sales.Add(sale);
                    db.SaveChanges();

                    // Satış detay satırlarını kaydet ve stok düş
                    foreach (var item in _cart)
                    {
                        db.SaleItems.Add(new SaleItem
                        {
                            SaleId = sale.Id,
                            ProductId = item.ProductId,
                            ProductName = item.ProductName,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice,
                            VatRate = item.VatRate,
                            LineTotal = item.LineTotal
                        });

                        // Stok düşür
                        var product = db.Products.Find(item.ProductId);
                        if (product != null)
                        {
                            product.CurrentStock -= item.Quantity;
                        }
                    }
                    db.SaveChanges();

                    // Fiş göster
                    if (chkFisVer.Checked)
                    {
                        ShowReceipt(sale, _cart);
                    }

                    MessageBox.Show($"Satış tamamlandı!\nToplam: {_cartTotal:C2}\nÖdeme: {paymentType}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Sepeti temizle
                ClearCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış hatası: " + ex.Message);
            }
        }

        private void CompleteSaleVeresiye()
        {
            if (_cart.Count == 0) { MessageBox.Show("Sepet boş!"); return; }

            // Müşteri seçtir
            Form selectForm = new Form() { Width = 400, Height = 350, Text = "Müşteri Seçin", StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog };
            ListBox lb = new ListBox() { Left = 10, Top = 10, Width = 365, Height = 240, Font = new Font("Segoe UI", 12F) };
            Button ok = new Button() { Text = "SEÇ", Left = 250, Top = 260, Width = 125, Height = 40, DialogResult = DialogResult.OK, BackColor = Color.MediumSeaGreen, ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            selectForm.Controls.Add(lb); selectForm.Controls.Add(ok);
            selectForm.AcceptButton = ok;

            using (var db = new AppDbContext())
            {
                var customers = db.Customers.Where(c => c.IsActive).ToList();
                foreach (var c in customers)
                    lb.Items.Add($"{c.Id} - {c.FullName} (Borç: {c.TotalDebt:C2})");
            }

            if (lb.Items.Count == 0) { MessageBox.Show("Kayıtlı müşteri yok! Önce Veresiye Defterinden müşteri ekleyin."); return; }

            if (selectForm.ShowDialog() == DialogResult.OK && lb.SelectedItem != null)
            {
                string selected = lb.SelectedItem.ToString();
                int customerId = int.Parse(selected.Split('-')[0].Trim());

                try
                {
                    using (var db = new AppDbContext())
                    {
                        decimal vatTotal = 0;
                        foreach (var item in _cart)
                            vatTotal += item.LineTotal * (item.VatRate / 100m);

                        var sale = new Sale
                        {
                            SaleDate = DateTime.Now,
                            TotalAmount = _cartTotal,
                            VatTotal = vatTotal,
                            PaymentType = "Veresiye",
                            CustomerId = customerId,
                            CashierName = cmbPersonnel.SelectedItem?.ToString() ?? "Bilinmiyor"
                        };
                        db.Sales.Add(sale);
                        db.SaveChanges();

                        foreach (var item in _cart)
                        {
                            db.SaleItems.Add(new SaleItem
                            {
                                SaleId = sale.Id,
                                ProductId = item.ProductId,
                                ProductName = item.ProductName,
                                Quantity = item.Quantity,
                                UnitPrice = item.UnitPrice,
                                VatRate = item.VatRate,
                                LineTotal = item.LineTotal
                            });
                            var product = db.Products.Find(item.ProductId);
                            if (product != null) product.CurrentStock -= item.Quantity;
                        }

                        // Müşteri borcunu güncelle
                        var customer = db.Customers.Find(customerId);
                        if (customer != null) customer.TotalDebt += _cartTotal;

                        db.SaveChanges();
                    }
                    MessageBox.Show($"Veresiye satış tamamlandı!\nToplam: {_cartTotal:C2}", "Başarılı");
                    ClearCart();
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }

        private void ClearCart()
        {
            _cart.Clear();
            _cartTotal = 0;
            RefreshCartGrid();
            // TextChanged event'ini geçici olarak devre dışı bırak, yoksa sıfırlamada kendini tekrar hesaplar
            txtAlinan.TextChanged -= AlinanTextChanged;
            txtAlinan.Text = "0,00";
            txtParaUstu.Text = "0,00";
            txtParaUstu.ForeColor = Color.Red;
            txtAlinan.TextChanged += AlinanTextChanged;
            lblSelectedProduct.Text = "  Seçili Ürün: - | Stok: -";
        }

        private void CompleteSaleNakitKart()
        {
            if (_cart.Count == 0) { MessageBox.Show("Sepet boş!"); return; }

            Form splitForm = new Form()
            {
                Width = 420, Height = 250, Text = "Nakit & Kart Ödeme Bölüştürme",
                StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog
            };
            Label lblTotal = new Label() { Text = $"Toplam Tutar: {_cartTotal:C2}", Left = 20, Top = 15, Width = 360, Height = 30, Font = new Font("Segoe UI", 14F, FontStyle.Bold) };
            Label lblNakit = new Label() { Text = "Nakit (₺):", Left = 20, Top = 60, Width = 100, Height = 25, Font = new Font("Segoe UI", 11F) };
            NumericUpDown numNakit = new NumericUpDown() { Left = 130, Top = 58, Width = 150, DecimalPlaces = 2, Maximum = 999999, Font = new Font("Segoe UI", 14F) };
            Label lblKart = new Label() { Text = "Kart (₺):", Left = 20, Top = 100, Width = 100, Height = 25, Font = new Font("Segoe UI", 11F) };
            NumericUpDown numKart = new NumericUpDown() { Left = 130, Top = 98, Width = 150, DecimalPlaces = 2, Maximum = 999999, Font = new Font("Segoe UI", 14F) };
            Label lblWarning = new Label() { Text = "", Left = 20, Top = 140, Width = 360, Height = 20, ForeColor = Color.Red, Font = new Font("Segoe UI", 9F) };
            Button ok = new Button() { Text = "ÖDEMEYİ TAMAMLA", Left = 130, Top = 165, Width = 250, Height = 40, BackColor = Color.DarkOrange, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };

            numNakit.ValueChanged += (s2, e2) => {
                numKart.Value = Math.Max(0, _cartTotal - numNakit.Value);
                decimal total = numNakit.Value + numKart.Value;
                lblWarning.Text = total != _cartTotal ? $"Ödeme toplamı tutarla eşleşmiyor! (Fark: {_cartTotal - total:C2})" : "";
            };
            numKart.ValueChanged += (s2, e2) => {
                decimal total = numNakit.Value + numKart.Value;
                lblWarning.Text = total != _cartTotal ? $"Ödeme toplamı tutarla eşleşmiyor! (Fark: {_cartTotal - total:C2})" : "";
            };

            ok.Click += (s2, e2) => {
                if (numNakit.Value + numKart.Value >= _cartTotal)
                    splitForm.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Ödeme toplamı tutarı karşılamalıdır!");
            };

            splitForm.Controls.AddRange(new Control[] { lblTotal, lblNakit, numNakit, lblKart, numKart, lblWarning, ok });

            if (splitForm.ShowDialog() == DialogResult.OK)
            {
                string payDetail = $"Nakit&Kart (Nakit:{numNakit.Value:N2} + Kart:{numKart.Value:N2})";
                CompleteSale(payDetail);
            }
        }

        private void ShowReceipt(Sale sale, List<CartItem> items)
        {
            string storeName = AyarlarUC.GetStoreName();
            string receipt = "═══════════════════════════\n";
            receipt += $"      {storeName}\n";
            receipt += "═══════════════════════════\n";
            receipt += $"Fiş No : {sale.Id}\n";
            receipt += $"Tarih  : {sale.SaleDate.ToLocalTime():dd.MM.yyyy HH:mm}\n";
            receipt += $"Kasiyer: {sale.CashierName}\n";
            receipt += "───────────────────────────\n";
            foreach (var item in items)
            {
                receipt += $"{item.ProductName}\n";
                receipt += $"  {item.Quantity} x {item.UnitPrice:N2} = {item.LineTotal:N2} ₺\n";
            }
            receipt += "───────────────────────────\n";
            receipt += $"KDV Toplam : {sale.VatTotal:N2} ₺\n";
            receipt += $"GENEL TOPLAM: {_cartTotal:N2} ₺\n";
            receipt += $"Ödeme: {sale.PaymentType}\n";
            receipt += "═══════════════════════════\n";
            receipt += "   Bizi tercih ettiğiniz\n     için teşekkürler!\n";
            MessageBox.Show(receipt, "Satış Fişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    /// <summary>Sepetteki bir ürün satırını temsil eder (geçici, DB'ye yazılmadan önce)</summary>
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int VatRate { get; set; }
        public decimal LineTotal { get; set; }
    }
}
