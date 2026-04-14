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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.tlpMiddle = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSales = new System.Windows.Forms.Panel();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.colTanim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMiktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTutar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKdv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSil = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.cmbPersonnel = new System.Windows.Forms.ComboBox();
            this.txtKasaSearch = new System.Windows.Forms.TextBox();
            this.dgvKasaSearch = new System.Windows.Forms.DataGridView();
            this.flpTabs = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTabKasa1 = new System.Windows.Forms.Button();
            this.btnTabKasa2 = new System.Windows.Forms.Button();
            this.flpBanknotes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAlinan = new System.Windows.Forms.Label();
            this.flpAlinanRow = new System.Windows.Forms.FlowLayoutPanel();
            this.txtAlinan = new System.Windows.Forms.TextBox();
            this.btnClearAlinan = new System.Windows.Forms.Button();
            this.lblParaUstu = new System.Windows.Forms.Label();
            this.txtParaUstu = new System.Windows.Forms.TextBox();
            this.btn5TL = new System.Windows.Forms.Button();
            this.btn10TL = new System.Windows.Forms.Button();
            this.btn20TL = new System.Windows.Forms.Button();
            this.btn50TL = new System.Windows.Forms.Button();
            this.btn100TL = new System.Windows.Forms.Button();
            this.btn200TL = new System.Windows.Forms.Button();
            this.pnlTouch = new System.Windows.Forms.Panel();
            this.tlpTouchGrid = new System.Windows.Forms.TableLayoutPanel();
            this.flpTouchCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCatGenel = new System.Windows.Forms.Button();
            this.btnCatTekel = new System.Windows.Forms.Button();
            this.btnCatManav = new System.Windows.Forms.Button();
            this.lblSelectedProduct = new System.Windows.Forms.Label();
            this.flpFooter = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNakit = new System.Windows.Forms.Button();
            this.btnKrediKarti = new System.Windows.Forms.Button();
            this.btnNakitKart = new System.Windows.Forms.Button();
            this.btnVeresiye = new System.Windows.Forms.Button();
            this.btnDiger = new System.Windows.Forms.Button();
            this.chkFisVer = new System.Windows.Forms.CheckBox();
            this.chkYazarKasa = new System.Windows.Forms.CheckBox();
            this.pnlDynamicContent = new System.Windows.Forms.Panel();
            this.lblDynamicContentTitle = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.tlpContent.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.tlpMiddle.SuspendLayout();
            this.pnlSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKasaSearch)).BeginInit();
            this.flpTabs.SuspendLayout();
            this.flpBanknotes.SuspendLayout();
            this.flpAlinanRow.SuspendLayout();
            this.pnlTouch.SuspendLayout();
            this.flpTouchCategories.SuspendLayout();
            this.flpFooter.SuspendLayout();
            this.pnlDynamicContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlSidebar, 0, 0);
            this.tlpMain.Controls.Add(this.tlpContent, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1366, 768);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.pnlSidebar.Controls.Add(this.btnKasa);
            this.pnlSidebar.Controls.Add(this.btnStok);
            this.pnlSidebar.Controls.Add(this.btnVeresiyeDefteri);
            this.pnlSidebar.Controls.Add(this.btnEFatura);
            this.pnlSidebar.Controls.Add(this.btnRaporlar);
            this.pnlSidebar.Controls.Add(this.btnAyarlar);
            this.pnlSidebar.Controls.Add(this.btnKapat);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSidebar.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(260, 768);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnKasa
            // 
            this.btnKasa.FlatAppearance.BorderSize = 0;
            this.btnKasa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKasa.Font = new System.Drawing.Font("Open Sans", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKasa.ForeColor = System.Drawing.Color.White;
            this.btnKasa.Location = new System.Drawing.Point(10, 20);
            this.btnKasa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnKasa.Name = "btnKasa";
            this.btnKasa.Size = new System.Drawing.Size(240, 80);
            this.btnKasa.TabIndex = 0;
            this.btnKasa.Text = "💳 Kasa";
            this.btnKasa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKasa.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            // 
            // btnStok
            // 
            this.btnStok.FlatAppearance.BorderSize = 0;
            this.btnStok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStok.Font = new System.Drawing.Font("Open Sans", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStok.ForeColor = System.Drawing.Color.White;
            this.btnStok.Location = new System.Drawing.Point(10, 110);
            this.btnStok.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnStok.Name = "btnStok";
            this.btnStok.Size = new System.Drawing.Size(240, 80);
            this.btnStok.TabIndex = 1;
            this.btnStok.Text = "📦 Stok İşlemleri";
            this.btnStok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStok.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            // 
            // btnVeresiyeDefteri
            // 
            this.btnVeresiyeDefteri.FlatAppearance.BorderSize = 0;
            this.btnVeresiyeDefteri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeresiyeDefteri.Font = new System.Drawing.Font("Open Sans", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnVeresiyeDefteri.ForeColor = System.Drawing.Color.White;
            this.btnVeresiyeDefteri.Location = new System.Drawing.Point(10, 200);
            this.btnVeresiyeDefteri.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnVeresiyeDefteri.Name = "btnVeresiyeDefteri";
            this.btnVeresiyeDefteri.Size = new System.Drawing.Size(240, 80);
            this.btnVeresiyeDefteri.TabIndex = 2;
            this.btnVeresiyeDefteri.Text = "📖 Veresiye Defteri";
            this.btnVeresiyeDefteri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVeresiyeDefteri.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            // 
            // btnEFatura
            // 
            this.btnEFatura.FlatAppearance.BorderSize = 0;
            this.btnEFatura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEFatura.Font = new System.Drawing.Font("Open Sans", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEFatura.ForeColor = System.Drawing.Color.White;
            this.btnEFatura.Location = new System.Drawing.Point(10, 290);
            this.btnEFatura.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnEFatura.Name = "btnEFatura";
            this.btnEFatura.Size = new System.Drawing.Size(240, 80);
            this.btnEFatura.TabIndex = 3;
            this.btnEFatura.Text = "🧾 e-Fatura";
            this.btnEFatura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEFatura.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            // 
            // btnRaporlar
            // 
            this.btnRaporlar.FlatAppearance.BorderSize = 0;
            this.btnRaporlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRaporlar.Font = new System.Drawing.Font("Open Sans", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporlar.ForeColor = System.Drawing.Color.White;
            this.btnRaporlar.Location = new System.Drawing.Point(10, 380);
            this.btnRaporlar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.btnRaporlar.Name = "btnRaporlar";
            this.btnRaporlar.Size = new System.Drawing.Size(240, 80);
            this.btnRaporlar.TabIndex = 4;
            this.btnRaporlar.Text = "📊 Raporlar";
            this.btnRaporlar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRaporlar.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.FlatAppearance.BorderSize = 0;
            this.btnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyarlar.Font = new System.Drawing.Font("Open Sans", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAyarlar.ForeColor = System.Drawing.Color.White;
            this.btnAyarlar.Location = new System.Drawing.Point(10, 470);
            this.btnAyarlar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 25);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(240, 80);
            this.btnAyarlar.TabIndex = 5;
            this.btnAyarlar.Text = "⚙️ Ayarlar";
            this.btnAyarlar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAyarlar.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            // 
            // btnKapat
            // 
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.Font = new System.Drawing.Font("Open Sans Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKapat.ForeColor = System.Drawing.Color.LightCoral;
            this.btnKapat.Location = new System.Drawing.Point(10, 585);
            this.btnKapat.Margin = new System.Windows.Forms.Padding(0);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(240, 80);
            this.btnKapat.TabIndex = 6;
            this.btnKapat.Text = "❌ Kapat";
            this.btnKapat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKapat.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            // 
            // tlpContent
            // 
            this.tlpContent.ColumnCount = 1;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.Controls.Add(this.pnlHeader, 0, 0);
            this.tlpContent.Controls.Add(this.tlpMiddle, 0, 1);
            this.tlpContent.Controls.Add(this.flpFooter, 0, 2);
            this.tlpContent.Controls.Add(this.pnlDynamicContent, 0, 1);
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(260, 0);
            this.tlpContent.Margin = new System.Windows.Forms.Padding(0);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 3;
            // Note: the following RowStyles block is automatically adjusted by the designer
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContent.Size = new System.Drawing.Size(1106, 768);
            this.tlpContent.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblInfo);
            this.pnlHeader.Controls.Add(this.lblTotalValue);
            this.pnlHeader.Controls.Add(this.lblTotalTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1166, 80);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Open Sans", 12F);
            this.lblInfo.Location = new System.Drawing.Point(20, 25);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(604, 28);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Destek: 0507 186 54 22 | Biz daha iyisini yapana kadar en iyisi bu 😉";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalValue.Font = new System.Drawing.Font("Open Sans", 36F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalValue.Location = new System.Drawing.Point(666, 0);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(350, 80);
            this.lblTotalValue.TabIndex = 1;
            this.lblTotalValue.Text = "0 ₺";
            this.lblTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblTotalTitle.Font = new System.Drawing.Font("Open Sans", 14F);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalTitle.Location = new System.Drawing.Point(1016, 0);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(150, 80);
            this.lblTotalTitle.TabIndex = 2;
            this.lblTotalTitle.Text = "KASA TOPLAM:";
            this.lblTotalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlpMiddle
            // 
            this.tlpMiddle.ColumnCount = 3;
            this.tlpMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMiddle.Controls.Add(this.pnlSales, 0, 0);
            this.tlpMiddle.Controls.Add(this.flpBanknotes, 1, 0);
            this.tlpMiddle.Controls.Add(this.pnlTouch, 2, 0);
            this.tlpMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMiddle.Location = new System.Drawing.Point(0, 728);
            this.tlpMiddle.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMiddle.Name = "tlpMiddle";
            this.tlpMiddle.RowCount = 1;
            this.tlpMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMiddle.Size = new System.Drawing.Size(1166, 20);
            this.tlpMiddle.TabIndex = 1;
            // 
            // pnlSales
            // 
            this.pnlSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlSales.Controls.Add(this.dgvSales);
            this.pnlSales.Controls.Add(this.txtBarcode);
            this.pnlSales.Controls.Add(this.cmbPersonnel);
            this.pnlSales.Controls.Add(this.txtKasaSearch);
            this.pnlSales.Controls.Add(this.dgvKasaSearch);
            this.pnlSales.Controls.Add(this.flpTabs);
            this.pnlSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSales.Location = new System.Drawing.Point(10, 10);
            this.pnlSales.Margin = new System.Windows.Forms.Padding(10);
            this.pnlSales.Name = "pnlSales";
            this.pnlSales.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSales.Size = new System.Drawing.Size(488, 1);
            this.pnlSales.TabIndex = 0;
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSales.BackgroundColor = System.Drawing.Color.White;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTanim,
            this.colMiktar,
            this.colFiyat,
            this.colTutar,
            this.colKdv,
            this.colSil});
            this.dgvSales.Location = new System.Drawing.Point(10, 140);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.RowHeadersWidth = 51;
            this.dgvSales.RowTemplate.Height = 35;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.Size = new System.Drawing.Size(528, 51);
            this.dgvSales.TabIndex = 0;
            // 
            // colTanim
            // 
            this.colTanim.HeaderText = "ÜRÜN TANIMI";
            this.colTanim.MinimumWidth = 6;
            this.colTanim.Name = "colTanim";
            // 
            // colMiktar
            // 
            this.colMiktar.HeaderText = "MİKTAR";
            this.colMiktar.MinimumWidth = 6;
            this.colMiktar.Name = "colMiktar";
            // 
            // colFiyat
            // 
            this.colFiyat.HeaderText = "FİYAT";
            this.colFiyat.MinimumWidth = 6;
            this.colFiyat.Name = "colFiyat";
            // 
            // colTutar
            // 
            this.colTutar.HeaderText = "TUTAR";
            this.colTutar.MinimumWidth = 6;
            this.colTutar.Name = "colTutar";
            // 
            // colKdv
            // 
            this.colKdv.HeaderText = "KDV";
            this.colKdv.MinimumWidth = 6;
            this.colKdv.Name = "colKdv";
            // 
            // colSil
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            this.colSil.DefaultCellStyle = dataGridViewCellStyle1;
            this.colSil.HeaderText = "SİL";
            this.colSil.MinimumWidth = 6;
            this.colSil.Name = "colSil";
            this.colSil.Text = "✖";
            this.colSil.UseColumnTextForButtonValue = true;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Open Sans", 14F);
            this.txtBarcode.Location = new System.Drawing.Point(10, 50);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(220, 39);
            this.txtBarcode.TabIndex = 1;
            this.txtBarcode.Text = "Barkod Okutunuz...";
            // 
            // cmbPersonnel
            // 
            this.cmbPersonnel.Font = new System.Drawing.Font("Open Sans", 14F);
            this.cmbPersonnel.Items.AddRange(new object[] {
            "Onur ATİK"});
            this.cmbPersonnel.Location = new System.Drawing.Point(250, 50);
            this.cmbPersonnel.Name = "cmbPersonnel";
            this.cmbPersonnel.Size = new System.Drawing.Size(230, 39);
            this.cmbPersonnel.TabIndex = 2;
            // 
            // txtKasaSearch
            // 
            this.txtKasaSearch.Font = new System.Drawing.Font("Open Sans", 14F);
            this.txtKasaSearch.Location = new System.Drawing.Point(10, 95);
            this.txtKasaSearch.Name = "txtKasaSearch";
            this.txtKasaSearch.Size = new System.Drawing.Size(470, 39);
            this.txtKasaSearch.TabIndex = 6;
            // 
            // dgvKasaSearch
            // 
            this.dgvKasaSearch.AllowUserToAddRows = false;
            this.dgvKasaSearch.AllowUserToDeleteRows = false;
            this.dgvKasaSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKasaSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKasaSearch.BackgroundColor = System.Drawing.Color.White;
            this.dgvKasaSearch.ColumnHeadersHeight = 35;
            this.dgvKasaSearch.Font = new System.Drawing.Font("Open Sans", 12F);
            this.dgvKasaSearch.Location = new System.Drawing.Point(10, 134);
            this.dgvKasaSearch.Name = "dgvKasaSearch";
            this.dgvKasaSearch.ReadOnly = true;
            this.dgvKasaSearch.RowHeadersVisible = false;
            this.dgvKasaSearch.RowHeadersWidth = 51;
            this.dgvKasaSearch.RowTemplate.Height = 40;
            this.dgvKasaSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKasaSearch.Size = new System.Drawing.Size(470, 350);
            this.dgvKasaSearch.TabIndex = 10;
            this.dgvKasaSearch.Visible = false;
            // 
            // flpTabs
            // 
            this.flpTabs.Controls.Add(this.btnTabKasa1);
            this.flpTabs.Controls.Add(this.btnTabKasa2);
            this.flpTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTabs.Location = new System.Drawing.Point(10, 10);
            this.flpTabs.Name = "flpTabs";
            this.flpTabs.Size = new System.Drawing.Size(468, 40);
            this.flpTabs.TabIndex = 3;
            // 
            // btnTabKasa1
            // 
            this.btnTabKasa1.BackColor = System.Drawing.Color.White;
            this.btnTabKasa1.Location = new System.Drawing.Point(3, 3);
            this.btnTabKasa1.Name = "btnTabKasa1";
            this.btnTabKasa1.Size = new System.Drawing.Size(120, 30);
            this.btnTabKasa1.TabIndex = 0;
            this.btnTabKasa1.Text = "SATIŞ KASA 1";
            this.btnTabKasa1.UseVisualStyleBackColor = false;
            // 
            // btnTabKasa2
            // 
            this.btnTabKasa2.Location = new System.Drawing.Point(129, 3);
            this.btnTabKasa2.Name = "btnTabKasa2";
            this.btnTabKasa2.Size = new System.Drawing.Size(120, 30);
            this.btnTabKasa2.TabIndex = 1;
            this.btnTabKasa2.Text = "SATIŞ KASA 2";
            // 
            // flpBanknotes
            // 
            this.flpBanknotes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpBanknotes.Controls.Add(this.lblAlinan);
            this.flpBanknotes.Controls.Add(this.flpAlinanRow);
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
            this.flpBanknotes.Location = new System.Drawing.Point(511, 3);
            this.flpBanknotes.Name = "flpBanknotes";
            this.flpBanknotes.Padding = new System.Windows.Forms.Padding(10);
            this.flpBanknotes.Size = new System.Drawing.Size(144, 14);
            this.flpBanknotes.TabIndex = 1;
            // 
            // lblAlinan
            // 
            this.lblAlinan.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.lblAlinan.Location = new System.Drawing.Point(13, 10);
            this.lblAlinan.Name = "lblAlinan";
            this.lblAlinan.Size = new System.Drawing.Size(100, 23);
            this.lblAlinan.TabIndex = 0;
            this.lblAlinan.Text = "ALINAN PARA";
            // 
            // flpAlinanRow
            // 
            this.flpAlinanRow.Controls.Add(this.txtAlinan);
            this.flpAlinanRow.Controls.Add(this.btnClearAlinan);
            this.flpAlinanRow.Location = new System.Drawing.Point(116, 10);
            this.flpAlinanRow.Margin = new System.Windows.Forms.Padding(0);
            this.flpAlinanRow.Name = "flpAlinanRow";
            this.flpAlinanRow.Size = new System.Drawing.Size(130, 50);
            this.flpAlinanRow.TabIndex = 1;
            // 
            // txtAlinan
            // 
            this.txtAlinan.Font = new System.Drawing.Font("Open Sans", 16F);
            this.txtAlinan.Location = new System.Drawing.Point(3, 3);
            this.txtAlinan.Name = "txtAlinan";
            this.txtAlinan.Size = new System.Drawing.Size(85, 43);
            this.txtAlinan.TabIndex = 0;
            this.txtAlinan.Text = "0,00";
            // 
            // btnClearAlinan
            // 
            this.btnClearAlinan.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearAlinan.Location = new System.Drawing.Point(94, 3);
            this.btnClearAlinan.Name = "btnClearAlinan";
            this.btnClearAlinan.Size = new System.Drawing.Size(30, 43);
            this.btnClearAlinan.TabIndex = 1;
            this.btnClearAlinan.Text = "C";
            this.btnClearAlinan.UseVisualStyleBackColor = true;
            // 
            // lblParaUstu
            // 
            this.lblParaUstu.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.lblParaUstu.Location = new System.Drawing.Point(249, 20);
            this.lblParaUstu.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lblParaUstu.Name = "lblParaUstu";
            this.lblParaUstu.Size = new System.Drawing.Size(100, 23);
            this.lblParaUstu.TabIndex = 2;
            this.lblParaUstu.Text = "PARA ÜSTÜ";
            // 
            // txtParaUstu
            // 
            this.txtParaUstu.Font = new System.Drawing.Font("Open Sans", 16F);
            this.txtParaUstu.ForeColor = System.Drawing.Color.Red;
            this.txtParaUstu.Location = new System.Drawing.Point(355, 13);
            this.txtParaUstu.Name = "txtParaUstu";
            this.txtParaUstu.Size = new System.Drawing.Size(130, 43);
            this.txtParaUstu.TabIndex = 3;
            this.txtParaUstu.Text = "0,00";
            // 
            // btn5TL
            // 
            this.btn5TL.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btn5TL.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Bold);
            this.btn5TL.Location = new System.Drawing.Point(488, 25);
            this.btn5TL.Margin = new System.Windows.Forms.Padding(0, 15, 0, 5);
            this.btn5TL.Name = "btn5TL";
            this.btn5TL.Size = new System.Drawing.Size(130, 50);
            this.btn5TL.TabIndex = 4;
            this.btn5TL.Text = "5 TL";
            this.btn5TL.UseVisualStyleBackColor = false;
            // 
            // btn10TL
            // 
            this.btn10TL.BackColor = System.Drawing.Color.LightPink;
            this.btn10TL.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Bold);
            this.btn10TL.Location = new System.Drawing.Point(621, 13);
            this.btn10TL.Name = "btn10TL";
            this.btn10TL.Size = new System.Drawing.Size(130, 50);
            this.btn10TL.TabIndex = 5;
            this.btn10TL.Text = "10 TL";
            this.btn10TL.UseVisualStyleBackColor = false;
            // 
            // btn20TL
            // 
            this.btn20TL.BackColor = System.Drawing.Color.LightGreen;
            this.btn20TL.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Bold);
            this.btn20TL.Location = new System.Drawing.Point(757, 13);
            this.btn20TL.Name = "btn20TL";
            this.btn20TL.Size = new System.Drawing.Size(130, 50);
            this.btn20TL.TabIndex = 6;
            this.btn20TL.Text = "20 TL";
            this.btn20TL.UseVisualStyleBackColor = false;
            // 
            // btn50TL
            // 
            this.btn50TL.BackColor = System.Drawing.Color.LightSalmon;
            this.btn50TL.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Bold);
            this.btn50TL.Location = new System.Drawing.Point(893, 13);
            this.btn50TL.Name = "btn50TL";
            this.btn50TL.Size = new System.Drawing.Size(130, 50);
            this.btn50TL.TabIndex = 7;
            this.btn50TL.Text = "50 TL";
            this.btn50TL.UseVisualStyleBackColor = false;
            // 
            // btn100TL
            // 
            this.btn100TL.BackColor = System.Drawing.Color.LightBlue;
            this.btn100TL.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Bold);
            this.btn100TL.Location = new System.Drawing.Point(1029, 13);
            this.btn100TL.Name = "btn100TL";
            this.btn100TL.Size = new System.Drawing.Size(130, 50);
            this.btn100TL.TabIndex = 8;
            this.btn100TL.Text = "100 TL";
            this.btn100TL.UseVisualStyleBackColor = false;
            // 
            // btn200TL
            // 
            this.btn200TL.BackColor = System.Drawing.Color.Plum;
            this.btn200TL.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Bold);
            this.btn200TL.Location = new System.Drawing.Point(1165, 13);
            this.btn200TL.Name = "btn200TL";
            this.btn200TL.Size = new System.Drawing.Size(130, 50);
            this.btn200TL.TabIndex = 9;
            this.btn200TL.Text = "200 TL";
            this.btn200TL.UseVisualStyleBackColor = false;
            // 
            // pnlTouch
            // 
            this.pnlTouch.BackColor = System.Drawing.Color.White;
            this.pnlTouch.Controls.Add(this.tlpTouchGrid);
            this.pnlTouch.Controls.Add(this.flpTouchCategories);
            this.pnlTouch.Controls.Add(this.lblSelectedProduct);
            this.pnlTouch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTouch.Location = new System.Drawing.Point(668, 10);
            this.pnlTouch.Margin = new System.Windows.Forms.Padding(10);
            this.pnlTouch.Name = "pnlTouch";
            this.pnlTouch.Size = new System.Drawing.Size(488, 1);
            this.pnlTouch.TabIndex = 2;
            // 
            // tlpTouchGrid
            // 
            this.tlpTouchGrid.ColumnCount = 4;
            this.tlpTouchGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTouchGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTouchGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTouchGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpTouchGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTouchGrid.Location = new System.Drawing.Point(0, 40);
            this.tlpTouchGrid.Name = "tlpTouchGrid";
            this.tlpTouchGrid.RowCount = 5;
            this.tlpTouchGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTouchGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTouchGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTouchGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTouchGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTouchGrid.Size = new System.Drawing.Size(488, 0);
            this.tlpTouchGrid.TabIndex = 0;
            // 
            // flpTouchCategories
            // 
            this.flpTouchCategories.Controls.Add(this.btnCatGenel);
            this.flpTouchCategories.Controls.Add(this.btnCatTekel);
            this.flpTouchCategories.Controls.Add(this.btnCatManav);
            this.flpTouchCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpTouchCategories.Location = new System.Drawing.Point(0, 0);
            this.flpTouchCategories.Name = "flpTouchCategories";
            this.flpTouchCategories.Size = new System.Drawing.Size(488, 40);
            this.flpTouchCategories.TabIndex = 1;
            // 
            // btnCatGenel
            // 
            this.btnCatGenel.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCatGenel.ForeColor = System.Drawing.Color.White;
            this.btnCatGenel.Location = new System.Drawing.Point(3, 3);
            this.btnCatGenel.Name = "btnCatGenel";
            this.btnCatGenel.Size = new System.Drawing.Size(100, 35);
            this.btnCatGenel.TabIndex = 0;
            this.btnCatGenel.Text = "GENEL";
            this.btnCatGenel.UseVisualStyleBackColor = false;
            // 
            // btnCatTekel
            // 
            this.btnCatTekel.BackColor = System.Drawing.Color.LightGray;
            this.btnCatTekel.Location = new System.Drawing.Point(109, 3);
            this.btnCatTekel.Name = "btnCatTekel";
            this.btnCatTekel.Size = new System.Drawing.Size(100, 35);
            this.btnCatTekel.TabIndex = 1;
            this.btnCatTekel.Text = "TEKEL";
            this.btnCatTekel.UseVisualStyleBackColor = false;
            // 
            // btnCatManav
            // 
            this.btnCatManav.BackColor = System.Drawing.Color.LightGray;
            this.btnCatManav.Location = new System.Drawing.Point(215, 3);
            this.btnCatManav.Name = "btnCatManav";
            this.btnCatManav.Size = new System.Drawing.Size(100, 35);
            this.btnCatManav.TabIndex = 2;
            this.btnCatManav.Text = "MANAV";
            this.btnCatManav.UseVisualStyleBackColor = false;
            // 
            // lblSelectedProduct
            // 
            this.lblSelectedProduct.BackColor = System.Drawing.Color.DimGray;
            this.lblSelectedProduct.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSelectedProduct.Font = new System.Drawing.Font("Open Sans", 12F);
            this.lblSelectedProduct.ForeColor = System.Drawing.Color.White;
            this.lblSelectedProduct.Location = new System.Drawing.Point(0, -39);
            this.lblSelectedProduct.Name = "lblSelectedProduct";
            this.lblSelectedProduct.Size = new System.Drawing.Size(488, 40);
            this.lblSelectedProduct.TabIndex = 2;
            this.lblSelectedProduct.Text = "  Seçili Ürün: - | Stok: -";
            this.lblSelectedProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flpFooter
            // 
            this.flpFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flpFooter.Controls.Add(this.btnNakit);
            this.flpFooter.Controls.Add(this.btnKrediKarti);
            this.flpFooter.Controls.Add(this.btnNakitKart);
            this.flpFooter.Controls.Add(this.btnVeresiye);
            this.flpFooter.Controls.Add(this.btnDiger);
            this.flpFooter.Controls.Add(this.chkFisVer);
            this.flpFooter.Controls.Add(this.chkYazarKasa);
            this.flpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpFooter.Location = new System.Drawing.Point(3, 751);
            this.flpFooter.Name = "flpFooter";
            this.flpFooter.Padding = new System.Windows.Forms.Padding(10);
            this.flpFooter.Size = new System.Drawing.Size(1160, 14);
            this.flpFooter.TabIndex = 2;
            // 
            // btnNakit
            // 
            this.btnNakit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnNakit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNakit.Font = new System.Drawing.Font("Open Sans", 11F, System.Drawing.FontStyle.Bold);
            this.btnNakit.ForeColor = System.Drawing.Color.White;
            this.btnNakit.Location = new System.Drawing.Point(13, 13);
            this.btnNakit.Name = "btnNakit";
            this.btnNakit.Size = new System.Drawing.Size(140, 80);
            this.btnNakit.TabIndex = 0;
            this.btnNakit.Text = "[F11]\nNAKİT SAT";
            this.btnNakit.UseVisualStyleBackColor = false;
            // 
            // btnKrediKarti
            // 
            this.btnKrediKarti.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnKrediKarti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKrediKarti.Font = new System.Drawing.Font("Open Sans", 11F, System.Drawing.FontStyle.Bold);
            this.btnKrediKarti.ForeColor = System.Drawing.Color.White;
            this.btnKrediKarti.Location = new System.Drawing.Point(159, 13);
            this.btnKrediKarti.Name = "btnKrediKarti";
            this.btnKrediKarti.Size = new System.Drawing.Size(140, 80);
            this.btnKrediKarti.TabIndex = 1;
            this.btnKrediKarti.Text = "[F12]\nKREDİ KARTI";
            this.btnKrediKarti.UseVisualStyleBackColor = false;
            // 
            // btnNakitKart
            // 
            this.btnNakitKart.BackColor = System.Drawing.Color.DarkOrange;
            this.btnNakitKart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNakitKart.Font = new System.Drawing.Font("Open Sans", 11F, System.Drawing.FontStyle.Bold);
            this.btnNakitKart.ForeColor = System.Drawing.Color.White;
            this.btnNakitKart.Location = new System.Drawing.Point(305, 13);
            this.btnNakitKart.Name = "btnNakitKart";
            this.btnNakitKart.Size = new System.Drawing.Size(140, 80);
            this.btnNakitKart.TabIndex = 2;
            this.btnNakitKart.Text = "[F10]\nNAKİT & KART";
            this.btnNakitKart.UseVisualStyleBackColor = false;
            // 
            // btnVeresiye
            // 
            this.btnVeresiye.BackColor = System.Drawing.Color.Crimson;
            this.btnVeresiye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVeresiye.Font = new System.Drawing.Font("Open Sans", 11F, System.Drawing.FontStyle.Bold);
            this.btnVeresiye.ForeColor = System.Drawing.Color.White;
            this.btnVeresiye.Location = new System.Drawing.Point(451, 13);
            this.btnVeresiye.Name = "btnVeresiye";
            this.btnVeresiye.Size = new System.Drawing.Size(140, 80);
            this.btnVeresiye.TabIndex = 3;
            this.btnVeresiye.Text = "[F8]\nVERESİYE SAT";
            this.btnVeresiye.UseVisualStyleBackColor = false;
            // 
            // btnDiger
            // 
            this.btnDiger.BackColor = System.Drawing.Color.Gray;
            this.btnDiger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiger.Font = new System.Drawing.Font("Open Sans", 11F, System.Drawing.FontStyle.Bold);
            this.btnDiger.ForeColor = System.Drawing.Color.White;
            this.btnDiger.Location = new System.Drawing.Point(597, 13);
            this.btnDiger.Name = "btnDiger";
            this.btnDiger.Size = new System.Drawing.Size(140, 80);
            this.btnDiger.TabIndex = 4;
            this.btnDiger.Text = "[F5]\nDİĞER SATIŞ";
            this.btnDiger.UseVisualStyleBackColor = false;
            // 
            // chkFisVer
            // 
            this.chkFisVer.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFisVer.Checked = true;
            this.chkFisVer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFisVer.Location = new System.Drawing.Point(743, 13);
            this.chkFisVer.Name = "chkFisVer";
            this.chkFisVer.Size = new System.Drawing.Size(90, 80);
            this.chkFisVer.TabIndex = 5;
            this.chkFisVer.Text = "Fiş Ver";
            this.chkFisVer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkYazarKasa
            // 
            this.chkYazarKasa.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkYazarKasa.Location = new System.Drawing.Point(839, 13);
            this.chkYazarKasa.Name = "chkYazarKasa";
            this.chkYazarKasa.Size = new System.Drawing.Size(90, 80);
            this.chkYazarKasa.TabIndex = 6;
            this.chkYazarKasa.Text = "YazarKasa\nPOS";
            this.chkYazarKasa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDynamicContent
            // 
            this.pnlDynamicContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDynamicContent.Controls.Add(this.lblDynamicContentTitle);
            this.pnlDynamicContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDynamicContent.Location = new System.Drawing.Point(0, 80);
            this.pnlDynamicContent.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDynamicContent.Name = "pnlDynamicContent";
            this.tlpContent.SetRowSpan(this.pnlDynamicContent, 2);
            this.pnlDynamicContent.Size = new System.Drawing.Size(1166, 648);
            this.pnlDynamicContent.TabIndex = 3;
            this.pnlDynamicContent.Visible = false;
            // 
            // lblDynamicContentTitle
            // 
            this.lblDynamicContentTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDynamicContentTitle.Font = new System.Drawing.Font("Open Sans", 36F, System.Drawing.FontStyle.Bold);
            this.lblDynamicContentTitle.ForeColor = System.Drawing.Color.LightGray;
            this.lblDynamicContentTitle.Location = new System.Drawing.Point(0, 0);
            this.lblDynamicContentTitle.Name = "lblDynamicContentTitle";
            this.lblDynamicContentTitle.Size = new System.Drawing.Size(1166, 648);
            this.lblDynamicContentTitle.TabIndex = 0;
            this.lblDynamicContentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKasaSearch)).EndInit();
            this.flpTabs.ResumeLayout(false);
            this.flpBanknotes.ResumeLayout(false);
            this.flpBanknotes.PerformLayout();
            this.flpAlinanRow.ResumeLayout(false);
            this.flpAlinanRow.PerformLayout();
            this.pnlTouch.ResumeLayout(false);
            this.flpTouchCategories.ResumeLayout(false);
            this.flpFooter.ResumeLayout(false);
            this.pnlDynamicContent.ResumeLayout(false);
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

        // Dynamic Panel for Sidebar Routing
        private System.Windows.Forms.Panel pnlDynamicContent;
        private System.Windows.Forms.Label lblDynamicContentTitle;

        // Sales Panel Controls
        private System.Windows.Forms.FlowLayoutPanel flpTabs;
        private System.Windows.Forms.Button btnTabKasa1;
        private System.Windows.Forms.Button btnTabKasa2;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.ComboBox cmbPersonnel;
        private System.Windows.Forms.TextBox txtKasaSearch;
        private System.Windows.Forms.DataGridView dgvKasaSearch;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTanim;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMiktar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTutar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKdv;
        private System.Windows.Forms.DataGridViewButtonColumn colSil;

        // Banknotes Controls
        private System.Windows.Forms.Label lblAlinan;
        private System.Windows.Forms.FlowLayoutPanel flpAlinanRow;
        private System.Windows.Forms.TextBox txtAlinan;
        private System.Windows.Forms.Button btnClearAlinan;
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
