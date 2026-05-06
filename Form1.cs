using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ÜrünTakip.Data;
using ÜrünTakip.Models;
using ÜrünTakip.Views;
using ÜrünTakip.Controls;

namespace ÜrünTakip
{
    public partial class Form1 : Form
    {
        // UserControl instances
        private VeresiyeDefterUC veresiyeUC;
        private EFaturaUC efaturaUC;
        private AyarlarUC ayarlarUC;

        // Ayrı pencere olarak açılan formlar
        private Form _stokForm;
        private Form _raporlarForm;

        // Sepet verileri (Kasa ekranı - Çoklu Kasa Desteği)
        private List<List<CartItem>> _carts = new List<List<CartItem>> { new List<CartItem>(), new List<CartItem>() };
        private int _activeKasaIndex = 0; // 0=Kasa 1, 1=Kasa 2
        private decimal _cartTotal { get { return CurrentCart.Sum(x => x.LineTotal); } }
        private List<CartItem> CurrentCart => _carts[_activeKasaIndex];
        private Button btnCloseSearch;
        private ContextMenuStrip _shortcutMenu;
        private string _activeTouchCategory = "GENEL";

        public Form1()
        {
            InitializeComponent();
            ApplyTheme();

            // UserControl'leri oluştur ve dinamik panele ekle (Stok ve Raporlar ayrı pencere açılır)
            veresiyeUC = new VeresiyeDefterUC() { Dock = DockStyle.Fill, Visible = false };
            efaturaUC = new EFaturaUC() { Dock = DockStyle.Fill, Visible = false };
            ayarlarUC = new AyarlarUC() { Dock = DockStyle.Fill, Visible = false };

            pnlDynamicContent.Controls.Add(veresiyeUC);
            pnlDynamicContent.Controls.Add(efaturaUC);
            pnlDynamicContent.Controls.Add(ayarlarUC);

            SetupCustomEvents();
            LoadTouchGridProducts();
            UpdateCartDisplay();

            // Personel listesini yükle
            RefreshPersonnelList();

            // Klavye kısayolları
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            SetupShortcuts();
        }

        private void ApplyTheme()
        {
            // ── Sidebar ──
            pnlSidebar.BackColor = ThemeManager.SidebarBg;
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.ForeColor = ThemeManager.SidebarText;
                    btn.BackColor = Color.Transparent;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(35, 42, 52);
                }
            }
            btnKasa.BackColor = ThemeManager.SidebarBtnActive;
            btnKasa.ForeColor = ThemeManager.SidebarActiveText;
            btnKapat.ForeColor = ThemeManager.SidebarCloseText;

            // ── Header ──
            pnlHeader.BackColor = ThemeManager.HeaderBg;
            lblInfo.ForeColor = ThemeManager.TextSecondary;
            lblTotalTitle.ForeColor = ThemeManager.TextMuted;
            lblTotalValue.ForeColor = ThemeManager.TotalGreen;

            // ── Satış Paneli ──
            pnlSales.BackColor = ThemeManager.ContentBg;

            // ── Banknot Paneli ──
            flpBanknotes.BackColor = ThemeManager.SurfaceBg;
            lblAlinan.ForeColor = ThemeManager.TextPrimary;
            lblParaUstu.ForeColor = ThemeManager.TextPrimary;
            ThemeManager.StyleButton(btn5TL, ThemeManager.Banknote5);
            ThemeManager.StyleButton(btn10TL, ThemeManager.Banknote10);
            ThemeManager.StyleButton(btn20TL, ThemeManager.Banknote20);
            ThemeManager.StyleButton(btn50TL, ThemeManager.Banknote50);
            ThemeManager.StyleButton(btn100TL, ThemeManager.Banknote100);
            ThemeManager.StyleButton(btn200TL, ThemeManager.Banknote200);

            // ── Dokunmatik Panel ──
            pnlTouch.BackColor = ThemeManager.CardBg;
            lblSelectedProduct.BackColor = ThemeManager.FooterBg;
            lblSelectedProduct.ForeColor = Color.White;
            btnCatGenel.BackColor = ThemeManager.TouchCatActive;
            btnCatGenel.ForeColor = Color.White;
            btnCatTekel.BackColor = ThemeManager.TouchCatInactive;
            btnCatTekel.ForeColor = ThemeManager.TextPrimary;
            btnCatManav.BackColor = ThemeManager.TouchCatInactive;
            btnCatManav.ForeColor = ThemeManager.TextPrimary;
            btnTouchSettings.BackColor = ThemeManager.Amber;
            btnTouchSettings.ForeColor = Color.White;

            // ── Footer (Ödeme Butonları) ──
            flpFooter.BackColor = ThemeManager.FooterBg;
            ThemeManager.StyleButton(btnNakit, ThemeManager.Success);
            ThemeManager.StyleButton(btnKrediKarti, ThemeManager.Primary);
            ThemeManager.StyleButton(btnNakitKart, ThemeManager.Warning);
            ThemeManager.StyleButton(btnVeresiye, ThemeManager.Danger);
            ThemeManager.StyleButton(btnDiger, ThemeManager.Neutral);
            ThemeManager.StyleButton(btnYedekle, ThemeManager.Teal);
            chkFisVer.BackColor = ThemeManager.FooterBg;
            chkFisVer.ForeColor = Color.White;
            chkFisVer.FlatStyle = FlatStyle.Flat;
            chkYazarKasa.BackColor = ThemeManager.FooterBg;
            chkYazarKasa.ForeColor = Color.White;
            chkYazarKasa.FlatStyle = FlatStyle.Flat;

            // ── Dynamic Content ──
            pnlDynamicContent.BackColor = ThemeManager.ContentBg;

            // ── DataGridView'ler ──
            ThemeManager.StyleDataGridView(dgvSales);
            ThemeManager.StyleDataGridView(dgvKasaSearch);

            // ── Kasa Tab Butonları ──
            btnTabKasa1.FlatStyle = FlatStyle.Flat;
            btnTabKasa1.FlatAppearance.BorderColor = ThemeManager.Border;
            btnTabKasa1.FlatAppearance.BorderSize = 1;
            btnTabKasa2.FlatStyle = FlatStyle.Flat;
            btnTabKasa2.FlatAppearance.BorderColor = ThemeManager.Border;
            btnTabKasa2.FlatAppearance.BorderSize = 1;
        }

        private void SetupShortcuts()
        {
            _shortcutMenu = new ContextMenuStrip();
            _shortcutMenu.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            _shortcutMenu.Items.Add("💳 Kasa (F1)", null, (s, e) => SayfaDegistir("Kasa"));
            _shortcutMenu.Items.Add("📦 Stok İşlemleri (F2)", null, (s, e) => SayfaDegistir("Stok İşlemleri"));
            _shortcutMenu.Items.Add("👥 Veresiye Defteri (F3)", null, (s, e) => SayfaDegistir("Veresiye Defteri"));
            _shortcutMenu.Items.Add("📄 e-Fatura / Geçmiş (F4)", null, (s, e) => SayfaDegistir("e-Fatura / Geçmiş"));
            _shortcutMenu.Items.Add("📊 Raporlar (F5)", null, (s, e) => SayfaDegistir("Raporlar"));
            _shortcutMenu.Items.Add("⚙️ Ayarlar (F6)", null, (s, e) => SayfaDegistir("Ayarlar"));
            _shortcutMenu.Items.Add(new ToolStripSeparator());
            _shortcutMenu.Items.Add("❌ Kapat (Alt+F4)", null, (s, e) => Application.Exit());

            this.ContextMenuStrip = _shortcutMenu;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F1: SayfaDegistir("Kasa"); return true;
                case Keys.F2: SayfaDegistir("Stok İşlemleri"); return true;
                case Keys.F3: SayfaDegistir("Veresiye Defteri"); return true;
                case Keys.F4: SayfaDegistir("e-Fatura / Geçmiş"); return true;
                case Keys.F5: SayfaDegistir("Raporlar"); return true;
                case Keys.F6: SayfaDegistir("Ayarlar"); return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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
            // Arama kapatma butonu oluştur
            btnCloseSearch = new Button();
            btnCloseSearch.Text = "❌ Kapat";
            btnCloseSearch.BackColor = ThemeManager.Danger;
            btnCloseSearch.ForeColor = Color.White;
            btnCloseSearch.FlatStyle = FlatStyle.Flat;
            btnCloseSearch.FlatAppearance.BorderSize = 0;
            btnCloseSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCloseSearch.Size = new Size(110, 40);
            btnCloseSearch.Visible = false;
            this.Controls.Add(btnCloseSearch);

            btnCloseSearch.Click += (s, e) => {
                dgvKasaSearch.Visible = false;
                btnCloseSearch.Visible = false;
                txtKasaSearch.Focus();
                txtKasaSearch.Clear();
            };

            // Dış alana tıklayınca kapatma (Global Form tıklamaları)
            EventHandler closeGridClick = (s, e) => {
                if (dgvKasaSearch.Visible && !dgvKasaSearch.Bounds.Contains(this.PointToClient(Cursor.Position)))
                {
                    dgvKasaSearch.Visible = false;
                    btnCloseSearch.Visible = false;
                }
            };
            this.Click += closeGridClick;
            pnlSidebar.Click += closeGridClick;
            tlpMain.Click += closeGridClick;
            tlpContent.Click += closeGridClick;
            pnlHeader.Click += closeGridClick;
            tlpMiddle.Click += closeGridClick;
            pnlSales.Click += closeGridClick;
            dgvSales.Click += closeGridClick;
            pnlTouch.Click += closeGridClick;

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

            // Kasa (Tab) Geçişleri
            btnTabKasa1.Click += (s, e) => SwitchKasa(0);
            btnTabKasa2.Click += (s, e) => SwitchKasa(1);
            SwitchKasa(0); // Başlangıçta Kasa 1 aktif

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

            // Kasa arama kutucuğu
            txtKasaSearch.GotFocus += (s, e) => { if (txtKasaSearch.Text == "Ürün Ara...") txtKasaSearch.Clear(); };
            txtKasaSearch.LostFocus += (s, e) => { 
                if (string.IsNullOrWhiteSpace(txtKasaSearch.Text)) { 
                    txtKasaSearch.Text = "Ürün Ara..."; 
                    dgvKasaSearch.Visible = false;
                    if (btnCloseSearch != null) btnCloseSearch.Visible = false;
                }
            };

            txtKasaSearch.TextChanged += (s, e) => {
                string searchTxt = txtKasaSearch.Text;
                if (searchTxt == "Ürün Ara..." || string.IsNullOrWhiteSpace(searchTxt))
                {
                    dgvKasaSearch.Visible = false;
                    if (btnCloseSearch != null) btnCloseSearch.Visible = false;
                    return;
                }
                
                using (var db = new AppDbContext())
                {
                    var allProducts = db.Products.Where(p => p.IsActive).ToList();
                    var results = allProducts
                        .Where(p => 
                            (p.Name != null && p.Name.IndexOf(searchTxt, StringComparison.OrdinalIgnoreCase) >= 0) || 
                            (p.Barcode != null && p.Barcode.IndexOf(searchTxt, StringComparison.OrdinalIgnoreCase) >= 0))
                        .Take(15)
                        .Select(p => new {
                            Id = p.Id,
                            Barkod = p.Barcode,
                            Ürün = p.Name,
                            TopStok = p.CurrentStock,
                            Stok_1 = p.Stock1,
                            Alış_1 = p.PurchasePrice.ToString("N2") + " ₺",
                            Stok_2 = p.Stock2,
                            Alış_2 = p.PurchasePrice2.ToString("N2") + " ₺",
                            Satış_Fiyatı = p.SalePrice.ToString("N2") + " ₺"
                        })
                        .ToList();
                        
                    if (results.Count > 0)
                    {
                        dgvKasaSearch.Parent = this; // Panel kısıtlamasından kurtulmak için en dışa al
                        dgvKasaSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left; 
                        Point pt = txtKasaSearch.PointToScreen(Point.Empty);
                        Point formPt = this.PointToClient(pt);
                        dgvKasaSearch.Location = new Point(formPt.X, formPt.Y + txtKasaSearch.Height + 15);
                        dgvKasaSearch.Width = 980; // Yatayda devasa boyut
                        dgvKasaSearch.Height = 450;
                        
                        dgvKasaSearch.DataSource = null; // Kolon çakışmalarını sıfırla
                        dgvKasaSearch.DataSource = results;
                        if (dgvKasaSearch.Columns.Contains("Id")) dgvKasaSearch.Columns["Id"].Visible = false;
                        if (dgvKasaSearch.Columns.Contains("Ürün")) dgvKasaSearch.Columns["Ürün"].FillWeight = 250;
                        
                        dgvKasaSearch.ClearSelection();
                        dgvKasaSearch.Visible = true;
                        dgvKasaSearch.BringToFront();

                        btnCloseSearch.Parent = this;
                        btnCloseSearch.Location = new Point(dgvKasaSearch.Right - btnCloseSearch.Width, dgvKasaSearch.Top - btnCloseSearch.Height);
                        btnCloseSearch.BringToFront();
                        btnCloseSearch.Visible = true;
                    }
                    else
                    {
                        dgvKasaSearch.Visible = false;
                        if (btnCloseSearch != null) btnCloseSearch.Visible = false;
                    }
                }
            };

            txtKasaSearch.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Down && dgvKasaSearch.Visible && dgvKasaSearch.Rows.Count > 0)
                {
                    dgvKasaSearch.Focus();
                    dgvKasaSearch.Rows[0].Selected = true;
                }
            };

            dgvKasaSearch.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    if (dgvKasaSearch.SelectedRows.Count > 0)
                    {
                        int id = (int)dgvKasaSearch.SelectedRows[0].Cells["Id"].Value;
                        AddProductById(id);
                        txtKasaSearch.Clear();
                        dgvKasaSearch.Visible = false;
                        if (btnCloseSearch != null) btnCloseSearch.Visible = false;
                        txtBarcode.Focus();
                    }
                }
            };

            dgvKasaSearch.CellClick += (s, e) => {
                if (e.RowIndex >= 0)
                {
                    int id = (int)dgvKasaSearch.Rows[e.RowIndex].Cells["Id"].Value;
                    AddProductById(id);
                    txtKasaSearch.Clear();
                    dgvKasaSearch.Visible = false;
                    if (btnCloseSearch != null) btnCloseSearch.Visible = false;
                    txtBarcode.Focus();
                }
            };

            txtKasaSearch.Text = "Ürün Ara...";

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
            btnNakitKart.Text = "[F10] \n Nakit/Kart";
            btnVeresiye.Click += (s, e) => CompleteSaleVeresiye();
            btnDiger.Click += (s, e) => CompleteSale("Diğer");

            // Dokunmatik Kategori Butonları
            btnCatGenel.Click += (s, e) => SetTouchCategory("GENEL", btnCatGenel);
            btnCatTekel.Click += (s, e) => SetTouchCategory("TEKEL", btnCatTekel);
            btnCatManav.Click += (s, e) => SetTouchCategory("MANAV", btnCatManav);
            
            // Kısayol Ayarları
            if (btnTouchSettings != null)
            {
                btnTouchSettings.Click += (s, e) => {
                    var frm = new KisayolAyarlariForm();
                    frm.ShowDialog();
                    LoadTouchGridProducts(); // Ayarlar bitince yenile
                };
            }

            // Yedekleme butonu
            btnYedekle.Click += (s, e) => BackupDatabase();
        }

        private void SetTouchCategory(string category, Button activeBtn)
        {
            _activeTouchCategory = category;
            
            // Renkleri sıfırla
            btnCatGenel.BackColor = ThemeManager.TouchCatInactive;
            btnCatTekel.BackColor = ThemeManager.TouchCatInactive;
            btnCatManav.BackColor = ThemeManager.TouchCatInactive;
            btnCatGenel.ForeColor = ThemeManager.TextPrimary;
            btnCatTekel.ForeColor = ThemeManager.TextPrimary;
            btnCatManav.ForeColor = ThemeManager.TextPrimary;

            // Aktif butonu vurgula
            activeBtn.BackColor = ThemeManager.TouchCatActive;
            activeBtn.ForeColor = Color.White;

            LoadTouchGridProducts();
        }

        private void AlinanTextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        // ————————————————— SAYFA GEÇİŞLERİ —————————————————

        private void HideAllUC()
        {
            veresiyeUC.Visible = false;
            efaturaUC.Visible = false;
            ayarlarUC.Visible = false;
            lblDynamicContentTitle.Visible = false;
        }

        /// <summary>Stok veya Raporlar için ayrı modeless pencere açar. Zaten açıksa öne getirir.</summary>
        private void OpenAsWindow(string title, Func<UserControl> createUC, ref Form formField)
        {
            // Eğer pencere zaten açıksa öne getir
            if (formField != null && !formField.IsDisposed)
            {
                formField.WindowState = FormWindowState.Normal;
                formField.BringToFront();
                formField.Activate();
                return;
            }

            var uc = createUC();
            uc.Dock = DockStyle.Fill;

            var frm = new Form();
            frm.Text = title;
            frm.Size = new Size(1300, 850);
            frm.MinimumSize = new Size(900, 600);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Icon = this.Icon;
            frm.BackColor = ThemeManager.ContentBg;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.MaximizeBox = true;
            frm.MinimizeBox = true;
            frm.ShowInTaskbar = true;
            frm.KeyPreview = true;
            frm.KeyDown += (s, e) => { if (e.KeyCode == Keys.Escape) frm.Close(); };

            frm.Controls.Add(uc);

            // Pencere kapandığında referansı temizle
            Form localRef = frm; // closure için
            frm.FormClosed += (s, e) =>
            {
                if (_stokForm == localRef) _stokForm = null;
                if (_raporlarForm == localRef) _raporlarForm = null;
            };

            formField = frm;
            frm.Show(); // Modeless — ana uygulama ile aynı anda kullanılabilir
        }

        private void SayfaDegistir(string sayfaAdi)
        {
            // Stok ve Raporlar ayrı pencere olarak açılır
            if (sayfaAdi == "Stok İşlemleri")
            {
                OpenAsWindow("📦 Stok İşlemleri", () => {
                    var uc = new StokIslemleriUC();
                    return uc;
                }, ref _stokForm);
                return;
            }
            if (sayfaAdi == "Raporlar")
            {
                OpenAsWindow("📊 Raporlar", () => new RaporlarUC(), ref _raporlarForm);
                return;
            }

            if (sayfaAdi == "Kasa")
            {
                pnlDynamicContent.Visible = false;
                tlpMiddle.Visible = true;
                flpFooter.Visible = true;
                lblTotalTitle.Visible = true;
                lblTotalValue.Visible = true;
                lblTotalTitle.Text = "KASA TOPLAM:";
                UpdateCartDisplay();
                lblTotalValue.ForeColor = ThemeManager.TotalGreen;
                RefreshPersonnelList();
                LoadTouchGridProducts();
            }
            else
            {
                tlpMiddle.Visible = false;
                flpFooter.Visible = false;
                pnlDynamicContent.Visible = true;
                lblTotalTitle.Visible = false;
                lblTotalValue.Visible = false;
                HideAllUC();

                switch (sayfaAdi)
                {
                    case "Veresiye Defteri": veresiyeUC.Visible = true; break;
                    case "e-Fatura": efaturaUC.Visible = true; break;
                    case "Ayarlar": 
                        ayarlarUC.LoadCategories();
                        ayarlarUC.Visible = true; 
                        break;
                }
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
                    // Seçili kategoriye ve pozisyona göre ürünleri getir (sadece 20 pozisyon)
                    var products = db.Products
                                     .Where(p => p.IsActive && p.PosCategory == _activeTouchCategory && p.PosPosition != null)
                                     .ToList();

                    // 20 pozisyonluk dizi oluştur
                    Product[] gridProducts = new Product[20];
                    foreach(var p in products)
                    {
                        if (p.PosPosition >= 1 && p.PosPosition <= 20)
                        {
                            // Aynı pozisyonda birden fazla ürün varsa ilkini alır
                            if (gridProducts[p.PosPosition.Value - 1] == null)
                                gridProducts[p.PosPosition.Value - 1] = p;
                        }
                    }

                    for (int i = 0; i < 20; i++)
                    {
                        var prod = gridProducts[i];
                        Button btn = new Button();
                        btn.Dock = DockStyle.Fill;
                        btn.FlatStyle = FlatStyle.Flat;

                        if (prod != null)
                        {
                            btn.Text = prod.Name + "\n" + prod.SalePrice.ToString("N2") + " ₺";
                            btn.BackColor = ThemeManager.TouchBtnBg;
                            btn.FlatAppearance.BorderColor = ThemeManager.TouchBtnBorder;
                            btn.FlatAppearance.BorderSize = 1;
                            btn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            btn.ForeColor = ThemeManager.TextPrimary;
                            btn.Tag = prod.Id;
                            btn.Cursor = Cursors.Hand;
                            btn.Click += TouchProductBtn_Click;
                        }
                        else
                        {
                            btn.Text = "";
                            btn.BackColor = ThemeManager.SurfaceBg;
                            btn.FlatAppearance.BorderColor = ThemeManager.BorderLight;
                            btn.Enabled = false;
                        }

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
                    btn.BackColor = ThemeManager.SurfaceBg;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = ThemeManager.BorderLight;
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
            var existing = CurrentCart.FirstOrDefault(c => c.ProductId == product.Id);
            if (existing != null)
            {
                existing.Quantity++;
                existing.LineTotal = existing.Quantity * existing.UnitPrice;
            }
            else
            {
                CurrentCart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = 1,
                    UnitPrice = product.SalePrice,
                    VatRate = product.VatRate,
                    LineTotal = product.SalePrice
                });
            }
            decimal currentCartQty = 0;
            var addedItem = CurrentCart.FirstOrDefault(c => c.ProductId == product.Id);
            if (addedItem != null) currentCartQty = addedItem.Quantity;
            
            decimal totalStock = product.Stock1 + product.Stock2 - currentCartQty;
            decimal remainingStok1 = product.Stock1 - currentCartQty;
            if (remainingStok1 < 0) remainingStok1 = 0; // Görsel olarak o anki sepet düşümü
            
            lblSelectedProduct.Text = $"  Seçili: {product.Name} | Kalan Stok: {totalStock:N0} (Stok1: {remainingStok1:N0} , {product.PurchasePrice:N2}₺)";
            
            if (product.CriticalStock > 0 && totalStock <= product.CriticalStock)
            {
                MessageBox.Show($"DİKKAT: {product.Name} ürünü kritik stok seviyesine ulaştı!\nKalan Stok: {totalStock:N0}\nKritik Seviye: {product.CriticalStock:N0}", "Kritik Stok Uyarısı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            RefreshCartGrid();
        }

        private void RefreshCartGrid()
        {
            dgvSales.Rows.Clear();
            foreach (var item in CurrentCart)
            {
                dgvSales.Rows.Add(item.ProductName, item.Quantity.ToString("N0"), item.UnitPrice.ToString("N2"), item.LineTotal.ToString("N2"), $"%{item.VatRate}", "✖");
            }
            UpdateCartDisplay();
            CalculateChange();
        }

        private void UpdateCartDisplay()
        {
            lblTotalValue.Text = _cartTotal.ToString("N2") + " ₺";
        }

        // ————————————————— STOK DETAY PANELİ —————————————————

        private void ShowStockDetailPanel(CartItem cartItem, int cartRowIndex)
        {
            Product product;
            using (var db = new AppDbContext())
            {
                product = db.Products.Find(cartItem.ProductId);
                if (product == null) return;
            }

            decimal cartQty = cartItem.Quantity;
            decimal totalStock = product.Stock1 + product.Stock2;
            decimal remaining = totalStock - cartQty;

            Form frmStock = new Form();
            frmStock.Text = "📦 Stok Detayı";
            frmStock.Size = new Size(460, 620);
            frmStock.StartPosition = FormStartPosition.CenterParent;
            frmStock.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmStock.MaximizeBox = false;
            frmStock.MinimizeBox = false;
            frmStock.BackColor = ThemeManager.CardBg;

            // Başlık Panel
            Panel pnlTitle = new Panel();
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Height = 60;
            pnlTitle.BackColor = ThemeManager.Primary;
            frmStock.Controls.Add(pnlTitle);

            Label lblTitle = new Label();
            lblTitle.Text = $"  📦  {product.Name}";
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            pnlTitle.Controls.Add(lblTitle);

            int y = 80;
            int leftCol = 25;
            int rightCol = 240;

            // ── Stok 1 Satırı ──
            Label lblS1Header = new Label();
            lblS1Header.Text = "STOK 1";
            lblS1Header.Location = new Point(leftCol, y);
            lblS1Header.Size = new Size(200, 22);
            lblS1Header.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblS1Header.ForeColor = ThemeManager.TextMuted;
            frmStock.Controls.Add(lblS1Header);
            y += 24;

            Label lblS1Value = new Label();
            lblS1Value.Text = $"{product.Stock1:N0} adet";
            lblS1Value.Location = new Point(leftCol, y);
            lblS1Value.Size = new Size(200, 32);
            lblS1Value.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblS1Value.ForeColor = product.Stock1 > 0 ? ThemeManager.Success : ThemeManager.Danger;
            frmStock.Controls.Add(lblS1Value);

            Label lblS1Price = new Label();
            lblS1Price.Text = $"Alış: {product.PurchasePrice:N2} ₺";
            lblS1Price.Location = new Point(rightCol, y);
            lblS1Price.Size = new Size(190, 32);
            lblS1Price.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            lblS1Price.ForeColor = ThemeManager.TextSecondary;
            lblS1Price.TextAlign = ContentAlignment.MiddleRight;
            frmStock.Controls.Add(lblS1Price);
            y += 40;

            // Ayırıcı çizgi
            Panel sep1 = new Panel();
            sep1.Location = new Point(leftCol, y);
            sep1.Size = new Size(400, 1);
            sep1.BackColor = ThemeManager.Border;
            frmStock.Controls.Add(sep1);
            y += 12;

            // ── Stok 2 Satırı ──
            Label lblS2Header = new Label();
            lblS2Header.Text = "STOK 2";
            lblS2Header.Location = new Point(leftCol, y);
            lblS2Header.Size = new Size(200, 22);
            lblS2Header.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblS2Header.ForeColor = ThemeManager.TextMuted;
            frmStock.Controls.Add(lblS2Header);
            y += 24;

            Label lblS2Value = new Label();
            lblS2Value.Text = $"{product.Stock2:N0} adet";
            lblS2Value.Location = new Point(leftCol, y);
            lblS2Value.Size = new Size(200, 32);
            lblS2Value.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblS2Value.ForeColor = product.Stock2 > 0 ? ThemeManager.Info : ThemeManager.TextMuted;
            frmStock.Controls.Add(lblS2Value);

            Label lblS2Price = new Label();
            lblS2Price.Text = $"Alış: {product.PurchasePrice2:N2} ₺";
            lblS2Price.Location = new Point(rightCol, y);
            lblS2Price.Size = new Size(190, 32);
            lblS2Price.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            lblS2Price.ForeColor = ThemeManager.TextSecondary;
            lblS2Price.TextAlign = ContentAlignment.MiddleRight;
            frmStock.Controls.Add(lblS2Price);
            y += 40;

            // Ayırıcı çizgi
            Panel sep2 = new Panel();
            sep2.Location = new Point(leftCol, y);
            sep2.Size = new Size(400, 1);
            sep2.BackColor = ThemeManager.Border;
            frmStock.Controls.Add(sep2);
            y += 18;

            // ── Toplam Stok ──
            Label lblTotalHeader = new Label();
            lblTotalHeader.Text = "TOPLAM STOK";
            lblTotalHeader.Location = new Point(leftCol, y);
            lblTotalHeader.Size = new Size(200, 22);
            lblTotalHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalHeader.ForeColor = ThemeManager.TextMuted;
            frmStock.Controls.Add(lblTotalHeader);
            y += 24;

            Label lblTotalValue = new Label();
            lblTotalValue.Text = $"{totalStock:N0} adet";
            lblTotalValue.Location = new Point(leftCol, y);
            lblTotalValue.Size = new Size(200, 36);
            lblTotalValue.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalValue.ForeColor = ThemeManager.TotalGreen;
            frmStock.Controls.Add(lblTotalValue);

            // Satış fiyatı sağ tarafta
            Label lblSalePrice = new Label();
            lblSalePrice.Text = $"Satış: {product.SalePrice:N2} ₺";
            lblSalePrice.Location = new Point(rightCol, y);
            lblSalePrice.Size = new Size(190, 36);
            lblSalePrice.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSalePrice.ForeColor = ThemeManager.Primary;
            lblSalePrice.TextAlign = ContentAlignment.MiddleRight;
            frmStock.Controls.Add(lblSalePrice);
            y += 44;

            // ── Sepetteki Miktar ve Kalan ──
            Panel pnlCart = new Panel();
            pnlCart.Location = new Point(leftCol, y);
            pnlCart.Size = new Size(400, 50);
            pnlCart.BackColor = ThemeManager.SurfaceBg;
            frmStock.Controls.Add(pnlCart);

            Label lblCartInfo = new Label();
            lblCartInfo.Text = $"🛒 Sepette: {cartQty:N0}     |     📦 Kalan: {remaining:N0}";
            lblCartInfo.Dock = DockStyle.Fill;
            lblCartInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCartInfo.ForeColor = remaining > 0 ? ThemeManager.TextPrimary : ThemeManager.Danger;
            lblCartInfo.TextAlign = ContentAlignment.MiddleCenter;
            pnlCart.Controls.Add(lblCartInfo);
            y += 60;

            // ── Kritik Stok Uyarısı ──
            if (product.CriticalStock > 0)
            {
                Color critColor = remaining <= product.CriticalStock ? ThemeManager.Danger : ThemeManager.Success;
                string critIcon = remaining <= product.CriticalStock ? "⚠️" : "✅";

                Label lblCritical = new Label();
                lblCritical.Text = $"{critIcon}  Kritik Seviye: {product.CriticalStock:N0}  —  {(remaining <= product.CriticalStock ? "KRİTİK SEVİYEDE!" : "Stok yeterli")}";
                lblCritical.Location = new Point(leftCol, y);
                lblCritical.Size = new Size(400, 30);
                lblCritical.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                lblCritical.ForeColor = critColor;
                lblCritical.TextAlign = ContentAlignment.MiddleCenter;
                frmStock.Controls.Add(lblCritical);
                y += 35;
            }

            // ── Ayırıcı çizgi (Miktar bölümü öncesi) ──
            Panel sep3 = new Panel();
            sep3.Location = new Point(leftCol, y);
            sep3.Size = new Size(400, 2);
            sep3.BackColor = ThemeManager.Primary;
            frmStock.Controls.Add(sep3);
            y += 14;

            // ── MİKTAR DEĞİŞTİRME PANELİ ──
            Label lblAmountHeader = new Label();
            lblAmountHeader.Text = "MİKTAR GÜNCELLE";
            lblAmountHeader.Location = new Point(leftCol, y);
            lblAmountHeader.Size = new Size(400, 22);
            lblAmountHeader.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAmountHeader.ForeColor = ThemeManager.TextMuted;
            lblAmountHeader.TextAlign = ContentAlignment.MiddleCenter;
            frmStock.Controls.Add(lblAmountHeader);
            y += 28;

            // [-] Miktar [+] satırı
            int controlsCenter = 210; // form genişliğinin ortası

            Button btnMinus = new Button();
            btnMinus.Text = "−";
            btnMinus.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnMinus.Size = new Size(55, 50);
            btnMinus.Location = new Point(controlsCenter - 100, y);
            btnMinus.BackColor = ThemeManager.Danger;
            btnMinus.ForeColor = Color.White;
            btnMinus.FlatStyle = FlatStyle.Flat;
            btnMinus.FlatAppearance.BorderSize = 0;
            btnMinus.Cursor = Cursors.Hand;
            frmStock.Controls.Add(btnMinus);

            TextBox txtAmount = new TextBox();
            txtAmount.Text = cartItem.Quantity.ToString("G");
            txtAmount.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            txtAmount.Size = new Size(90, 50);
            txtAmount.Location = new Point(controlsCenter - 40, y + 3);
            txtAmount.TextAlign = HorizontalAlignment.Center;
            frmStock.Controls.Add(txtAmount);

            Button btnPlus = new Button();
            btnPlus.Text = "+";
            btnPlus.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            btnPlus.Size = new Size(55, 50);
            btnPlus.Location = new Point(controlsCenter + 55, y);
            btnPlus.BackColor = ThemeManager.Success;
            btnPlus.ForeColor = Color.White;
            btnPlus.FlatStyle = FlatStyle.Flat;
            btnPlus.FlatAppearance.BorderSize = 0;
            btnPlus.Cursor = Cursors.Hand;
            frmStock.Controls.Add(btnPlus);

            y += 60;

            // GÜNCELLE ve DİREKT SİL butonları
            Button btnOk = new Button();
            btnOk.Text = "✅  GÜNCELLE";
            btnOk.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOk.Size = new Size(195, 48);
            btnOk.Location = new Point(leftCol, y);
            btnOk.BackColor = ThemeManager.Primary;
            btnOk.ForeColor = Color.White;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.Cursor = Cursors.Hand;
            frmStock.Controls.Add(btnOk);

            Button btnDelete = new Button();
            btnDelete.Text = "🗑️  DİREKT SİL";
            btnDelete.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDelete.Size = new Size(195, 48);
            btnDelete.Location = new Point(leftCol + 205, y);
            btnDelete.BackColor = ThemeManager.Danger;
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Cursor = Cursors.Hand;
            frmStock.Controls.Add(btnDelete);

            // ── Event Handler'lar ──
            btnMinus.Click += (s, ev) => {
                if (decimal.TryParse(txtAmount.Text, out decimal val) && val > 0)
                    txtAmount.Text = (val - 1).ToString("G");
            };

            btnPlus.Click += (s, ev) => {
                if (decimal.TryParse(txtAmount.Text, out decimal val))
                    txtAmount.Text = (val + 1).ToString("G");
            };

            txtAmount.KeyPress += (s, ev) => {
                if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar) && ev.KeyChar != ',')
                    ev.Handled = true;
                if (ev.KeyChar == ',' && txtAmount.Text.Contains(","))
                    ev.Handled = true;
            };

            btnDelete.Click += (s, ev) => {
                txtAmount.Text = "0";
                frmStock.DialogResult = DialogResult.OK;
            };

            btnOk.Click += (s, ev) => {
                frmStock.DialogResult = DialogResult.OK;
            };

            frmStock.AcceptButton = btnOk;

            if (frmStock.ShowDialog() == DialogResult.OK)
            {
                if (decimal.TryParse(txtAmount.Text, out decimal newQty))
                {
                    if (newQty <= 0)
                    {
                        CurrentCart.RemoveAt(cartRowIndex);
                    }
                    else
                    {
                        cartItem.Quantity = newQty;
                        cartItem.LineTotal = cartItem.Quantity * cartItem.UnitPrice;
                    }
                    RefreshCartGrid();
                }
            }
        }

        // ————————————————— GRID SİLME —————————————————

        private void DgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.RowIndex < CurrentCart.Count)
            {
                var cartItem = CurrentCart[e.RowIndex];
                ShowStockDetailPanel(cartItem, e.RowIndex);
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
            txtParaUstu.ForeColor = change >= 0 ? ThemeManager.TotalGreen : ThemeManager.Danger;
        }

        // ————————————————— SATIŞ TAMAMLAMA —————————————————

        /// <summary>FIFO stok düşme: Önce Stock1, sonra Stock2 kullanılır</summary>
        private decimal DeductStockFIFO(Product product, decimal quantity)
        {
            decimal remaining = quantity;
            decimal totalCost = 0;

            // Önce Stock1'den düş
            if (product.Stock1 > 0 && remaining > 0)
            {
                decimal fromStock1 = Math.Min(remaining, product.Stock1);
                product.Stock1 -= fromStock1;
                totalCost += fromStock1 * product.PurchasePrice;
                remaining -= fromStock1;
            }

            // Stock1 yetmediyse Stock2'den düş
            if (remaining > 0 && product.Stock2 > 0)
            {
                decimal fromStock2 = Math.Min(remaining, product.Stock2);
                product.Stock2 -= fromStock2;
                totalCost += fromStock2 * product.PurchasePrice2;
                remaining -= fromStock2;
            }

            // Her iki stok da yeterli değilse kalan negatife düşsün (Stock1'de)
            if (remaining > 0)
            {
                product.Stock1 -= remaining;
                totalCost += remaining * product.PurchasePrice;
            }

            // Müşteri Talebi: Alış fiyatı 1'in stoğu sıfırlandığında,
            // alış fiyatı 2'nin fiyatı ve stoğu birinciye geçsin, ikincisi boşalsın.
            if (product.Stock1 <= 0 && product.Stock2 > 0)
            {
                product.Stock1 += product.Stock2;
                product.PurchasePrice = product.PurchasePrice2;
                
                // İkinci alış fiyatını ve stoğunu sıfırla
                product.Stock2 = 0;
                product.PurchasePrice2 = 0;
            }

            // Toplam stoku güncelle
            product.CurrentStock = product.Stock1 + product.Stock2;

            // Ağırlıklı ortalama maliyet fiyatı
            return quantity > 0 ? totalCost / quantity : 0;
        }

        private void CompleteSale(string paymentType)
        {
            if (CurrentCart.Count == 0) { MessageBox.Show("Sepet boş! Önce ürün ekleyin."); return; }

            try
            {
                using (var db = new AppDbContext())
                {
                    // KDV toplamı hesapla
                    decimal vatTotal = 0;
                    foreach (var item in CurrentCart)
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
                        CashierName = cmbPersonnel.SelectedItem?.ToString() ?? "Bilinmiyor",
                        RegisterId = _activeKasaIndex + 1
                    };
                    db.Sales.Add(sale);
                    db.SaveChanges();

                    // Satış detay satırlarını kaydet ve stok düş (FIFO)
                    foreach (var item in CurrentCart)
                    {
                        var product = db.Products.Find(item.ProductId);
                        decimal purchasePriceAtSale = 0;
                        if (product != null)
                        {
                            purchasePriceAtSale = DeductStockFIFO(product, item.Quantity);
                        }

                        db.SaleItems.Add(new SaleItem
                        {
                            SaleId = sale.Id,
                            ProductId = item.ProductId,
                            ProductName = item.ProductName,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice,
                            VatRate = item.VatRate,
                            LineTotal = item.LineTotal,
                            PurchasePriceAtSale = purchasePriceAtSale
                        });
                    }
                    db.SaveChanges();

                    // Fiş göster
                    if (chkFisVer.Checked)
                    {
                        ShowReceipt(sale, CurrentCart);
                    }

                    MessageBox.Show($"Satış tamamlandı!\nToplam: {_cartTotal:C2}\nÖdeme: {paymentType}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Sepeti temizle
                ClearCart();
                LoadTouchGridProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış hatası: " + ex.Message);
            }
        }

        private void CompleteSaleVeresiye()
        {
            if (CurrentCart.Count == 0) { MessageBox.Show("Sepet boş!"); return; }

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
                        foreach (var item in CurrentCart)
                            vatTotal += item.LineTotal * (item.VatRate / 100m);

                        var sale = new Sale
                        {
                            SaleDate = DateTime.Now,
                            TotalAmount = _cartTotal,
                            VatTotal = vatTotal,
                            PaymentType = "Veresiye",
                            CustomerId = customerId,
                            CashierName = cmbPersonnel.SelectedItem?.ToString() ?? "Bilinmiyor",
                            RegisterId = _activeKasaIndex + 1
                        };
                        db.Sales.Add(sale);
                        db.SaveChanges();

                        foreach (var item in CurrentCart)
                        {
                            var product = db.Products.Find(item.ProductId);
                            decimal purchasePriceAtSale = 0;
                            if (product != null)
                            {
                                purchasePriceAtSale = DeductStockFIFO(product, item.Quantity);
                            }

                            db.SaleItems.Add(new SaleItem
                            {
                                SaleId = sale.Id,
                                ProductId = item.ProductId,
                                ProductName = item.ProductName,
                                Quantity = item.Quantity,
                                UnitPrice = item.UnitPrice,
                                VatRate = item.VatRate,
                                LineTotal = item.LineTotal,
                                PurchasePriceAtSale = purchasePriceAtSale
                            });
                        }

                        // Müşteri borcunu güncelle
                        var customer = db.Customers.Find(customerId);
                        if (customer != null) customer.TotalDebt += _cartTotal;

                        db.SaveChanges();
                    }
                    MessageBox.Show($"Veresiye satış tamamlandı!\nToplam: {_cartTotal:C2}", "Başarılı");
                    ClearCart();
                    LoadTouchGridProducts();
                }
                catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
            }
        }

        private void ClearCart()
        {
            CurrentCart.Clear();
            RefreshCartGrid();
            // TextChanged event'ini geçici olarak devre dışı bırak, yoksa sıfırlamada kendini tekrar hesaplar
            txtAlinan.TextChanged -= AlinanTextChanged;
            txtAlinan.Text = "0,00";
            txtParaUstu.Text = "0,00";
            txtParaUstu.ForeColor = ThemeManager.Danger;
            txtAlinan.TextChanged += AlinanTextChanged;
            lblSelectedProduct.Text = "  Seçili Ürün: - | Stok: -";
        }

        private void CompleteSaleNakitKart()
        {
            if (CurrentCart.Count == 0) { MessageBox.Show("Sepet boş!"); return; }

            Form splitForm = new Form()
            {
                Width = 420, Height = 250, Text = "Nakit & Kart Ödeme Bölüştürme",
                StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog
            };
            Label lblTotal = new Label() { Text = $"Toplam Tutar: {_cartTotal:C2}", Left = 20, Top = 15, Width = 360, Height = 30, Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold) };
            Label lblNakit = new Label() { Text = "Nakit (₺):", Left = 20, Top = 60, Width = 100, Height = 25, Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold) };
            NoSpinnerNumeric numNakit = new NoSpinnerNumeric() { Left = 130, Top = 58, Width = 150, DecimalPlaces = 2, Maximum = 999999, Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold) };
            Label lblKart = new Label() { Text = "Kart (₺):", Left = 20, Top = 100, Width = 100, Height = 25, Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold) };
            NoSpinnerNumeric numKart = new NoSpinnerNumeric() { Left = 130, Top = 98, Width = 150, DecimalPlaces = 2, Maximum = 999999, Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold) };
            Label lblWarning = new Label() { Text = "", Left = 20, Top = 140, Width = 360, Height = 20, ForeColor = Color.Red, Font = new Font("Segoe UI", 9F) };
            Button ok = new Button() { Text = "ÖDEMEYİ TAMAMLA", Left = 130, Top = 165, Width = 250, Height = 40, BackColor = Color.DarkOrange, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold) };

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
        private void SwitchKasa(int index)
        {
            _activeKasaIndex = index;
            
            // Buton görsellerini güncelle
            btnTabKasa1.BackColor = (_activeKasaIndex == 0) ? ThemeManager.Primary : ThemeManager.SurfaceBg;
            btnTabKasa1.ForeColor = (_activeKasaIndex == 0) ? Color.White : ThemeManager.TextPrimary;
            btnTabKasa1.Font = new Font("Segoe UI", 12F, (_activeKasaIndex == 0) ? FontStyle.Bold : FontStyle.Regular);

            btnTabKasa2.BackColor = (_activeKasaIndex == 1) ? ThemeManager.Primary : ThemeManager.SurfaceBg;
            btnTabKasa2.ForeColor = (_activeKasaIndex == 1) ? Color.White : ThemeManager.TextPrimary;
            btnTabKasa2.Font = new Font("Segoe UI", 12F, (_activeKasaIndex == 1) ? FontStyle.Bold : FontStyle.Regular);

            RefreshCartGrid();
            txtBarcode.Focus();
        }

        // ——————————————————— VERİTABANI YEDEKLEME ———————————————————

        /// <summary>PostgreSQL kurulum dizinlerinden pg_dump.exe yolunu otomatik bulur</summary>
        private string FindPgDump()
        {
            // Bilinen PostgreSQL kurulum dizinlerini tara
            string[] searchRoots = new string[]
            {
                @"C:\Program Files\PostgreSQL",
                @"C:\Program Files (x86)\PostgreSQL"
            };

            foreach (string root in searchRoots)
            {
                if (Directory.Exists(root))
                {
                    // Versiyon klasörlerini büyükten küçüğe sırala (en yeni versiyon önce)
                    var versionDirs = Directory.GetDirectories(root)
                        .OrderByDescending(d => d)
                        .ToArray();

                    foreach (var dir in versionDirs)
                    {
                        string pgDumpPath = Path.Combine(dir, "bin", "pg_dump.exe");
                        if (File.Exists(pgDumpPath))
                            return pgDumpPath;
                    }
                }
            }

            // Bulunamazsa PATH'teki pg_dump'ı dene
            return "pg_dump";
        }

        private void BackupDatabase()
        {
            try
            {
                string backupFolder = AyarlarUC.GetBackupPath();

                // Klasör yoksa oluştur
                if (!Directory.Exists(backupFolder))
                    Directory.CreateDirectory(backupFolder);

                string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".backup";
                string fullPath = Path.Combine(backupFolder, fileName);

                // Aynı isimde dosya varsa zaman ekle
                if (File.Exists(fullPath))
                {
                    fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".backup";
                    fullPath = Path.Combine(backupFolder, fileName);
                }

                string pgDumpExe = FindPgDump();

                // pg_dump ile yedekleme
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = pgDumpExe;
                psi.Arguments = $"-h localhost -p 5432 -U postgres -F c -b -v -f \"{fullPath}\" UrunTakipDB";
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;
                psi.EnvironmentVariables["PGPASSWORD"] = "123456";

                using (Process process = Process.Start(psi))
                {
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        MessageBox.Show($"Veritabanı yedeği başarıyla alındı!\n\nDosya: {fullPath}", "Yedekleme Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Yedekleme sırasında hata oluştu:\n{error}", "Yedekleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Yedekleme başlatılamadı:\n{ex.Message}\n\npg_dump bulunamadı. PostgreSQL kurulu olduğundan emin olun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
