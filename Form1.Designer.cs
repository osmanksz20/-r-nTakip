namespace ÜrünTakip
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle cellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStok = new System.Windows.Forms.Button();
            this.btnKasa = new System.Windows.Forms.Button();
            this.btnVeresiyeDefteri = new System.Windows.Forms.Button();
            this.btnEFatura = new System.Windows.Forms.Button();
            this.btnRaporlar = new System.Windows.Forms.Button();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            
            this.tlpMiddle = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSales = new System.Windows.Forms.Panel();
            this.flpTabs = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTabKasa1 = new System.Windows.Forms.Button();
            this.btnTabKasa2 = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.cmbPersonnel = new System.Windows.Forms.ComboBox();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.colTanim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKdv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSil = new System.Windows.Forms.DataGridViewButtonColumn();
            
            this.flpBanknotes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAlinan = new System.Windows.Forms.Label();
            this.txtAlinan = new System.Windows.Forms.TextBox();
            this.lblParaUstu = new System.Windows.Forms.Label();
            this.txtParaUstu = new System.Windows.Forms.TextBox();
            this.btn5TL = new System.Windows.Forms.Button();
            this.btn10TL = new System.Windows.Forms.Button();
            this.btn20TL = new System.Windows.Forms.Button();
            this.btn50TL = new System.Windows.Forms.Button();
            this.btn100TL = new System.Windows.Forms.Button();
            this.btn200TL = new System.Windows.Forms.Button();
            
            this.pnlTouch = new System.Windows.Forms.Panel();
            this.flpTouchCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCatGenel = new System.Windows.Forms.Button();
            this.btnCatTekel = new System.Windows.Forms.Button();
            this.btnCatManav = new System.Windows.Forms.Button();
            this.tlpTouchGrid = new System.Windows.Forms.TableLayoutPanel();
            this.lblSelectedProduct = new System.Windows.Forms.Label();
            
            this.flpFooter = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNakit = new System.Windows.Forms.Button();
            this.btnKrediKarti = new System.Windows.Forms.Button();
            this.btnNakitKart = new System.Windows.Forms.Button();
            this.btnVeresiye = new System.Windows.Forms.Button();
            this.btnDiger = new System.Windows.Forms.Button();
            this.chkFisVer = new System.Windows.Forms.CheckBox();
            this.chkYazarKasa = new System.Windows.Forms.CheckBox();

            this.tlpMain.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpMiddle.SuspendLayout();
            this.pnlSales.SuspendLayout();
            this.flpTabs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            this.flpBanknotes.SuspendLayout();
            this.pnlTouch.SuspendLayout();
            this.flpTouchCategories.SuspendLayout();
            this.flpFooter.SuspendLayout();
            this.SuspendLayout();
            
            // tlpMain
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlSidebar, 0, 0);
            this.tlpMain.Controls.Add(this.tlpContent, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            
            // pnlSidebar
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(52)))), ((int)(((byte)(54)))));
            this.pnlSidebar.Controls.Add(this.btnStok);
            this.pnlSidebar.Controls.Add(this.btnKasa);
            this.pnlSidebar.Controls.Add(this.btnVeresiyeDefteri);
            this.pnlSidebar.Controls.Add(this.btnEFatura);
            this.pnlSidebar.Controls.Add(this.btnRaporlar);
            this.pnlSidebar.Controls.Add(this.btnAyarlar);
            this.pnlSidebar.Controls.Add(this.btnKapat);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSidebar.Name = "pnlSidebar";
            
            // Sidebar Buttons Configuration Helper
            System.Drawing.Font sidebarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            System.Drawing.Size sidebarBtnSize = new System.Drawing.Size(200, 70);
            System.Windows.Forms.Padding sidebarMargin = new System.Windows.Forms.Padding(0, 0, 0, 2);

            this.btnStok.Font = sidebarFont; this.btnStok.ForeColor = System.Drawing.Color.White; this.btnStok.Size = sidebarBtnSize; this.btnStok.Margin = sidebarMargin; this.btnStok.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnStok.FlatAppearance.BorderSize = 0; this.btnStok.Text = "📦 Stok İşlemleri";
            this.btnKasa.Font = sidebarFont; this.btnKasa.ForeColor = System.Drawing.Color.White; this.btnKasa.Size = sidebarBtnSize; this.btnKasa.Margin = sidebarMargin; this.btnKasa.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnKasa.FlatAppearance.BorderSize = 0; this.btnKasa.Text = "💳 Kasa";
            this.btnVeresiyeDefteri.Font = sidebarFont; this.btnVeresiyeDefteri.ForeColor = System.Drawing.Color.White; this.btnVeresiyeDefteri.Size = sidebarBtnSize; this.btnVeresiyeDefteri.Margin = sidebarMargin; this.btnVeresiyeDefteri.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnVeresiyeDefteri.FlatAppearance.BorderSize = 0; this.btnVeresiyeDefteri.Text = "📖 Veresiye Defteri";
            this.btnEFatura.Font = sidebarFont; this.btnEFatura.ForeColor = System.Drawing.Color.White; this.btnEFatura.Size = sidebarBtnSize; this.btnEFatura.Margin = sidebarMargin; this.btnEFatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnEFatura.FlatAppearance.BorderSize = 0; this.btnEFatura.Text = "🧾 e-Fatura";
            this.btnRaporlar.Font = sidebarFont; this.btnRaporlar.ForeColor = System.Drawing.Color.White; this.btnRaporlar.Size = sidebarBtnSize; this.btnRaporlar.Margin = sidebarMargin; this.btnRaporlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnRaporlar.FlatAppearance.BorderSize = 0; this.btnRaporlar.Text = "📊 Raporlar";
            this.btnAyarlar.Font = sidebarFont; this.btnAyarlar.ForeColor = System.Drawing.Color.White; this.btnAyarlar.Size = sidebarBtnSize; this.btnAyarlar.Margin = sidebarMargin; this.btnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnAyarlar.FlatAppearance.BorderSize = 0; this.btnAyarlar.Text = "⚙️ Ayarlar";
            this.btnKapat.Font = sidebarFont; this.btnKapat.ForeColor = System.Drawing.Color.IndianRed; this.btnKapat.Size = sidebarBtnSize; this.btnKapat.Margin = new System.Windows.Forms.Padding(0, 50, 0, 0); this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnKapat.FlatAppearance.BorderSize = 0; this.btnKapat.Text = "❌ Kapat";

            // tlpContent
            this.tlpContent.ColumnCount = 1;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpContent.Controls.Add(this.tlpMiddle, 0, 1);
            this.tlpContent.Controls.Add(this.flpFooter, 0, 2);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(200, 0);
            this.tlpContent.Margin = new System.Windows.Forms.Padding(0);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 3;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));

            // pnlHeader
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblInfo);
            this.pnlHeader.Controls.Add(this.lblTotalValue);
            this.pnlHeader.Controls.Add(this.lblTotalTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);

            // lblInfo
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular);
            this.lblInfo.Location = new System.Drawing.Point(20, 25);
            this.lblInfo.Text = "Destek: 0850 123 45 67 | www.ornekpos.com";

            // lblTotalValue
            this.lblTotalValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalValue.Width = 350;
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalValue.Text = "594,00 ₺";

            // lblTotalTitle
            this.lblTotalTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalTitle.Width = 150;
            this.lblTotalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotalTitle.Text = "KASA TOPLAM:";

            // tlpMiddle
            this.tlpMiddle.ColumnCount = 3;
            this.tlpMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMiddle.Controls.Add(this.pnlSales, 0, 0);
            this.tlpMiddle.Controls.Add(this.flpBanknotes, 1, 0);
            this.tlpMiddle.Controls.Add(this.pnlTouch, 2, 0);
            this.tlpMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMiddle.RowCount = 1;
            this.tlpMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            // pnlSales
            this.pnlSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlSales.Controls.Add(this.dgvSales);
            this.pnlSales.Controls.Add(this.txtBarcode);
            this.pnlSales.Controls.Add(this.cmbPersonnel);
            this.pnlSales.Controls.Add(this.flpTabs);
            this.pnlSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSales.Margin = new System.Windows.Forms.Padding(10);
            this.pnlSales.Padding = new System.Windows.Forms.Padding(10);

            // flpTabs
            this.flpTabs.Controls.Add(this.btnTabKasa1);
            this.flpTabs.Controls.Add(this.btnTabKasa2);
            this.flpTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTabs.Height = 40;

            this.btnTabKasa1.Text = "SATIŞ KASA 1"; this.btnTabKasa1.BackColor = System.Drawing.Color.White; this.btnTabKasa1.Size = new System.Drawing.Size(120, 30);
            this.btnTabKasa2.Text = "SATIŞ KASA 2"; this.btnTabKasa2.Size = new System.Drawing.Size(120, 30);

            // txtBarcode
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtBarcode.Location = new System.Drawing.Point(10, 50);
            this.txtBarcode.Width = 250;
            this.txtBarcode.Text = "Barkod Okutunuz...";

            // cmbPersonnel
            this.cmbPersonnel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbPersonnel.Location = new System.Drawing.Point(270, 50);
            this.cmbPersonnel.Width = 150;
            this.cmbPersonnel.Items.Add("Ahmet Yılmaz");
            this.cmbPersonnel.SelectedIndex = 0;

            // dgvSales
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTanim, this.colMiktar, this.colFiyat, this.colTutar, this.colKdv, this.colSil});
            this.dgvSales.Location = new System.Drawing.Point(10, 90);
            this.dgvSales.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSales.RowTemplate.Height = 35;
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            
            this.colTanim.HeaderText = "ÜRÜN TANIMI";
            this.colMiktar.HeaderText = "MİKTAR";
            this.colFiyat.HeaderText = "FİYAT";
            this.colTutar.HeaderText = "TUTAR";
            this.colKdv.HeaderText = "KDV";
            this.colSil.HeaderText = "SİL"; this.colSil.Text = "✖"; this.colSil.UseColumnTextForButtonValue = true; cellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter; cellStyle1.ForeColor = System.Drawing.Color.Red; this.colSil.DefaultCellStyle = cellStyle1;

            // flpBanknotes (Orta Panel)
            this.flpBanknotes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpBanknotes.Controls.Add(this.lblAlinan);
            this.flpBanknotes.Controls.Add(this.txtAlinan);
            this.flpBanknotes.Controls.Add(this.lblParaUstu);
            this.flpBanknotes.Controls.Add(this.txtParaUstu);
            this.flpBanknotes.Controls.Add(this.btn5TL);
            this.flpBanknotes.Controls.Add(this.btn10TL);
            this.flpBanknotes.Controls.Add(this.btn20TL);
            this.flpBanknotes.Controls.Add(this.btn50TL);
            this.flpBanknotes.Controls.Add(this.btn100TL);
            this.flpBanknotes.Controls.Add(this.btn200TL);
            this.flpBanknotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBanknotes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpBanknotes.Padding = new System.Windows.Forms.Padding(10);
            
            this.lblAlinan.Text = "ALINAN PARA"; this.lblAlinan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtAlinan.Text = "0,00"; this.txtAlinan.Font = new System.Drawing.Font("Segoe UI", 16F); this.txtAlinan.Width = 130;
            this.lblParaUstu.Text = "PARA ÜSTÜ"; this.lblParaUstu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.lblParaUstu.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.txtParaUstu.Text = "0,00"; this.txtParaUstu.Font = new System.Drawing.Font("Segoe UI", 16F); this.txtParaUstu.Width = 130; this.txtParaUstu.ForeColor = System.Drawing.Color.Red;

            System.Drawing.Font bnFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            System.Drawing.Size bnSize = new System.Drawing.Size(130, 50);
            this.btn5TL.Text = "5 TL"; this.btn5TL.Size = bnSize; this.btn5TL.Font = bnFont; this.btn5TL.BackColor = System.Drawing.Color.LightGoldenrodYellow; this.btn5TL.Margin = new System.Windows.Forms.Padding(0, 15, 0, 5);
            this.btn10TL.Text = "10 TL"; this.btn10TL.Size = bnSize; this.btn10TL.Font = bnFont; this.btn10TL.BackColor = System.Drawing.Color.LightPink;
            this.btn20TL.Text = "20 TL"; this.btn20TL.Size = bnSize; this.btn20TL.Font = bnFont; this.btn20TL.BackColor = System.Drawing.Color.LightGreen;
            this.btn50TL.Text = "50 TL"; this.btn50TL.Size = bnSize; this.btn50TL.Font = bnFont; this.btn50TL.BackColor = System.Drawing.Color.LightSalmon;
            this.btn100TL.Text = "100 TL"; this.btn100TL.Size = bnSize; this.btn100TL.Font = bnFont; this.btn100TL.BackColor = System.Drawing.Color.LightBlue;
            this.btn200TL.Text = "200 TL"; this.btn200TL.Size = bnSize; this.btn200TL.Font = bnFont; this.btn200TL.BackColor = System.Drawing.Color.Plum;

            // pnlTouch (Sağ Panel)
            this.pnlTouch.BackColor = System.Drawing.Color.White;
            this.pnlTouch.Controls.Add(this.tlpTouchGrid);
            this.pnlTouch.Controls.Add(this.flpTouchCategories);
            this.pnlTouch.Controls.Add(this.lblSelectedProduct);
            this.pnlTouch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTouch.Margin = new System.Windows.Forms.Padding(10);

            // flpTouchCategories
            this.flpTouchCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTouchCategories.Height = 40;
            this.flpTouchCategories.Controls.Add(this.btnCatGenel);
            this.flpTouchCategories.Controls.Add(this.btnCatTekel);
            this.flpTouchCategories.Controls.Add(this.btnCatManav);
            
            this.btnCatGenel.Text = "GENEL"; this.btnCatGenel.Size = new System.Drawing.Size(100, 35); this.btnCatGenel.BackColor = System.Drawing.Color.SteelBlue; this.btnCatGenel.ForeColor = System.Drawing.Color.White;
            this.btnCatTekel.Text = "TEKEL"; this.btnCatTekel.Size = new System.Drawing.Size(100, 35); this.btnCatTekel.BackColor = System.Drawing.Color.LightGray;
            this.btnCatManav.Text = "MANAV"; this.btnCatManav.Size = new System.Drawing.Size(100, 35); this.btnCatManav.BackColor = System.Drawing.Color.LightGray;

            // tlpTouchGrid
            this.tlpTouchGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTouchGrid.ColumnCount = 4;
            this.tlpTouchGrid.RowCount = 5;
            for(int i=0; i<4; i++) this.tlpTouchGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            for(int i=0; i<5; i++) this.tlpTouchGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            // Add 20 placeholder products programmatically
            for(int i=1; i<=20; i++) {
                System.Windows.Forms.Button prodBtn = new System.Windows.Forms.Button();
                prodBtn.Dock = System.Windows.Forms.DockStyle.Fill;
                prodBtn.Text = "Ürün " + i;
                prodBtn.BackColor = System.Drawing.Color.WhiteSmoke;
                prodBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.tlpTouchGrid.Controls.Add(prodBtn);
            }

            // lblSelectedProduct
            this.lblSelectedProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSelectedProduct.Height = 40;
            this.lblSelectedProduct.BackColor = System.Drawing.Color.DimGray;
            this.lblSelectedProduct.ForeColor = System.Drawing.Color.White;
            this.lblSelectedProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelectedProduct.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSelectedProduct.Text = "  Seçili Ürün: - | Stok: -";

            // flpFooter
            this.flpFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFooter.Padding = new System.Windows.Forms.Padding(10);
            
            System.Drawing.Size footerBtnSize = new System.Drawing.Size(140, 80);
            System.Drawing.Font footerFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            this.btnNakit.Text = "[F11]\nNAKİT SAT"; this.btnNakit.Size = footerBtnSize; this.btnNakit.BackColor = System.Drawing.Color.MediumSeaGreen; this.btnNakit.ForeColor = System.Drawing.Color.White; this.btnNakit.Font = footerFont; this.btnNakit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKrediKarti.Text = "[F12]\nKREDİ KARTI"; this.btnKrediKarti.Size = footerBtnSize; this.btnKrediKarti.BackColor = System.Drawing.Color.CornflowerBlue; this.btnKrediKarti.ForeColor = System.Drawing.Color.White; this.btnKrediKarti.Font = footerFont; this.btnKrediKarti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNakitKart.Text = "[F10]\nNAKİT & KART"; this.btnNakitKart.Size = footerBtnSize; this.btnNakitKart.BackColor = System.Drawing.Color.DarkOrange; this.btnNakitKart.ForeColor = System.Drawing.Color.White; this.btnNakitKart.Font = footerFont; this.btnNakitKart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeresiye.Text = "[F8]\nVERESİYE SAT"; this.btnVeresiye.Size = footerBtnSize; this.btnVeresiye.BackColor = System.Drawing.Color.Crimson; this.btnVeresiye.ForeColor = System.Drawing.Color.White; this.btnVeresiye.Font = footerFont; this.btnVeresiye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiger.Text = "[F5]\nDİĞER SATIŞ"; this.btnDiger.Size = footerBtnSize; this.btnDiger.BackColor = System.Drawing.Color.Gray; this.btnDiger.ForeColor = System.Drawing.Color.White; this.btnDiger.Font = footerFont; this.btnDiger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            
            this.chkFisVer.Text = "Fiş Ver"; this.chkFisVer.Appearance = System.Windows.Forms.Appearance.Button; this.chkFisVer.Size = new System.Drawing.Size(90, 80); this.chkFisVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; this.chkFisVer.Checked = true;
            this.chkYazarKasa.Text = "YazarKasa\nPOS"; this.chkYazarKasa.Appearance = System.Windows.Forms.Appearance.Button; this.chkYazarKasa.Size = new System.Drawing.Size(90, 80); this.chkYazarKasa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.flpFooter.Controls.Add(this.btnNakit);
            this.flpFooter.Controls.Add(this.btnKrediKarti);
            this.flpFooter.Controls.Add(this.btnNakitKart);
            this.flpFooter.Controls.Add(this.btnVeresiye);
            this.flpFooter.Controls.Add(this.btnDiger);
            this.flpFooter.Controls.Add(this.chkFisVer);
            this.flpFooter.Controls.Add(this.chkYazarKasa);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.tlpMain);
            this.Name = "Form1";
            this.Text = "POS Kasa Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.tlpMain.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.tlpContent.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.tlpMiddle.ResumeLayout(false);
            this.pnlSales.ResumeLayout(false);
            this.pnlSales.PerformLayout();
            this.flpTabs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            this.flpBanknotes.ResumeLayout(false);
            this.flpBanknotes.PerformLayout();
            this.pnlTouch.ResumeLayout(false);
            this.flpTouchCategories.ResumeLayout(false);
            this.flpFooter.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // Layout Containers
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.FlowLayoutPanel pnlSidebar;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TableLayoutPanel tlpMiddle;
        private System.Windows.Forms.Panel pnlSales;
        private System.Windows.Forms.FlowLayoutPanel flpBanknotes;
        private System.Windows.Forms.Panel pnlTouch;
        private System.Windows.Forms.FlowLayoutPanel flpFooter;
        
        // Sidebar Buttons
        private System.Windows.Forms.Button btnStok;
        private System.Windows.Forms.Button btnKasa;
        private System.Windows.Forms.Button btnVeresiyeDefteri;
        private System.Windows.Forms.Button btnEFatura;
        private System.Windows.Forms.Button btnRaporlar;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.Button btnKapat;

        // Header Controls
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalValue;

        // Sales Panel Controls
        private System.Windows.Forms.FlowLayoutPanel flpTabs;
        private System.Windows.Forms.Button btnTabKasa1;
        private System.Windows.Forms.Button btnTabKasa2;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.ComboBox cmbPersonnel;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanim;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKdv;
        private System.Windows.Forms.DataGridViewButtonColumn colSil;

        // Banknotes Controls
        private System.Windows.Forms.Label lblAlinan;
        private System.Windows.Forms.TextBox txtAlinan;
        private System.Windows.Forms.Label lblParaUstu;
        private System.Windows.Forms.TextBox txtParaUstu;
        private System.Windows.Forms.Button btn5TL;
        private System.Windows.Forms.Button btn10TL;
        private System.Windows.Forms.Button btn20TL;
        private System.Windows.Forms.Button btn50TL;
        private System.Windows.Forms.Button btn100TL;
        private System.Windows.Forms.Button btn200TL;

        // Touch Grid Controls
        private System.Windows.Forms.FlowLayoutPanel flpTouchCategories;
        private System.Windows.Forms.Button btnCatGenel;
        private System.Windows.Forms.Button btnCatTekel;
        private System.Windows.Forms.Button btnCatManav;
        private System.Windows.Forms.TableLayoutPanel tlpTouchGrid;
        private System.Windows.Forms.Label lblSelectedProduct;

        // Footer Controls
        private System.Windows.Forms.Button btnNakit;
        private System.Windows.Forms.Button btnKrediKarti;
        private System.Windows.Forms.Button btnNakitKart;
        private System.Windows.Forms.Button btnVeresiye;
        private System.Windows.Forms.Button btnDiger;
        private System.Windows.Forms.CheckBox chkFisVer;
        private System.Windows.Forms.CheckBox chkYazarKasa;
    }
}
