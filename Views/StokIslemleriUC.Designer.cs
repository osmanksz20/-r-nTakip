using ÜrünTakip.Controls;
namespace ÜrünTakip.Views
{
    partial class StokIslemleriUC
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

        #region Bileşen Tasarımcısı Üretimi Kod

        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbCategories = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.btnGenBarcode = new System.Windows.Forms.Button();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.dtpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.lblEntryDate = new System.Windows.Forms.Label();
            this.numPurchasePrice = new ÜrünTakip.Controls.NoSpinnerNumeric();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.numStock = new ÜrünTakip.Controls.NoSpinnerNumeric();
            this.lblStock = new System.Windows.Forms.Label();
            this.numPurchasePrice2 = new ÜrünTakip.Controls.NoSpinnerNumeric();
            this.lblPurchasePrice2 = new System.Windows.Forms.Label();
            this.numStock2 = new ÜrünTakip.Controls.NoSpinnerNumeric();
            this.lblStock2 = new System.Windows.Forms.Label();
            this.lblTotalStock = new System.Windows.Forms.Label();
            this.numSalePrice = new ÜrünTakip.Controls.NoSpinnerNumeric();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.numVatRate = new ÜrünTakip.Controls.NoSpinnerNumeric();
            this.lblVatRate = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblKdvCalc = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlList = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.tlpMain.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVatRate)).BeginInit();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlForm, 0, 0);
            this.tlpMain.Controls.Add(this.pnlList, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(1000, 600);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlForm
            // 
            this.pnlForm.AutoScroll = true;
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Controls.Add(this.cmbCategories);
            this.pnlForm.Controls.Add(this.lblCategory);
            this.pnlForm.Controls.Add(this.btnAddCategory);
            this.pnlForm.Controls.Add(this.txtBarcode);
            this.pnlForm.Controls.Add(this.lblBarcode);
            this.pnlForm.Controls.Add(this.btnGenBarcode);
            this.pnlForm.Controls.Add(this.txtProductName);
            this.pnlForm.Controls.Add(this.lblProductName);
            this.pnlForm.Controls.Add(this.dtpEntryDate);
            this.pnlForm.Controls.Add(this.lblEntryDate);
            this.pnlForm.Controls.Add(this.numPurchasePrice);
            this.pnlForm.Controls.Add(this.lblPurchasePrice);
            this.pnlForm.Controls.Add(this.numStock);
            this.pnlForm.Controls.Add(this.lblStock);
            this.pnlForm.Controls.Add(this.numPurchasePrice2);
            this.pnlForm.Controls.Add(this.lblPurchasePrice2);
            this.pnlForm.Controls.Add(this.numStock2);
            this.pnlForm.Controls.Add(this.lblStock2);
            this.pnlForm.Controls.Add(this.lblTotalStock);
            this.pnlForm.Controls.Add(this.numSalePrice);
            this.pnlForm.Controls.Add(this.lblSalePrice);
            this.pnlForm.Controls.Add(this.numVatRate);
            this.pnlForm.Controls.Add(this.lblVatRate);
            this.pnlForm.Controls.Add(this.chkIsActive);
            this.pnlForm.Controls.Add(this.lblKdvCalc);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.btnUpdate);
            this.pnlForm.Controls.Add(this.btnDelete);
            this.pnlForm.Controls.Add(this.btnClear);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Location = new System.Drawing.Point(3, 3);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(20);
            this.pnlForm.Size = new System.Drawing.Size(394, 594);
            this.pnlForm.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ürün Kayıt Formu";
            // 
            // cmbCategories
            // 
            this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategories.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.cmbCategories.Location = new System.Drawing.Point(120, 70);
            this.cmbCategories.Name = "cmbCategories";
            this.cmbCategories.Size = new System.Drawing.Size(200, 31);
            this.cmbCategories.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblCategory.Location = new System.Drawing.Point(20, 70);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(100, 25);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Kategori:";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddCategory.Location = new System.Drawing.Point(330, 70);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(40, 30);
            this.btnAddCategory.TabIndex = 3;
            this.btnAddCategory.Text = "+";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtBarcode.Location = new System.Drawing.Point(120, 110);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(200, 30);
            this.txtBarcode.TabIndex = 4;
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBarcode.Location = new System.Drawing.Point(20, 110);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(100, 25);
            this.lblBarcode.TabIndex = 5;
            this.lblBarcode.Text = "Barkod:";
            // 
            // btnGenBarcode
            // 
            this.btnGenBarcode.Location = new System.Drawing.Point(330, 110);
            this.btnGenBarcode.Name = "btnGenBarcode";
            this.btnGenBarcode.Size = new System.Drawing.Size(40, 30);
            this.btnGenBarcode.TabIndex = 6;
            this.btnGenBarcode.Text = "Oto";
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtProductName.Location = new System.Drawing.Point(120, 150);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(250, 30);
            this.txtProductName.TabIndex = 7;
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblProductName.Location = new System.Drawing.Point(20, 150);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(100, 25);
            this.lblProductName.TabIndex = 8;
            this.lblProductName.Text = "Ürün Adı:";
            // 
            // dtpEntryDate
            // 
            this.dtpEntryDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEntryDate.Location = new System.Drawing.Point(120, 190);
            this.dtpEntryDate.Name = "dtpEntryDate";
            this.dtpEntryDate.Size = new System.Drawing.Size(250, 30);
            this.dtpEntryDate.TabIndex = 9;
            // 
            // lblEntryDate
            // 
            this.lblEntryDate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblEntryDate.Location = new System.Drawing.Point(20, 190);
            this.lblEntryDate.Name = "lblEntryDate";
            this.lblEntryDate.Size = new System.Drawing.Size(100, 25);
            this.lblEntryDate.TabIndex = 10;
            this.lblEntryDate.Text = "Giriş Tarihi:";
            // 
            // numPurchasePrice
            // 
            this.numPurchasePrice.DecimalPlaces = 2;
            this.numPurchasePrice.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.numPurchasePrice.Location = new System.Drawing.Point(120, 230);
            this.numPurchasePrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPurchasePrice.Name = "numPurchasePrice";
            this.numPurchasePrice.Size = new System.Drawing.Size(100, 30);
            this.numPurchasePrice.TabIndex = 11;
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblPurchasePrice.Location = new System.Drawing.Point(20, 230);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(100, 25);
            this.lblPurchasePrice.TabIndex = 12;
            this.lblPurchasePrice.Text = "Alış Fiyatı 1:";
            // 
            // numStock
            // 
            this.numStock.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.numStock.Location = new System.Drawing.Point(290, 230);
            this.numStock.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numStock.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(80, 30);
            this.numStock.TabIndex = 13;
            // 
            // lblStock
            // 
            this.lblStock.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblStock.Location = new System.Drawing.Point(230, 230);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(60, 25);
            this.lblStock.TabIndex = 14;
            this.lblStock.Text = "Stok 1:";
            // 
            // numPurchasePrice2
            // 
            this.numPurchasePrice2.DecimalPlaces = 2;
            this.numPurchasePrice2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.numPurchasePrice2.Location = new System.Drawing.Point(120, 270);
            this.numPurchasePrice2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPurchasePrice2.Name = "numPurchasePrice2";
            this.numPurchasePrice2.Size = new System.Drawing.Size(100, 30);
            this.numPurchasePrice2.TabIndex = 15;
            // 
            // lblPurchasePrice2
            // 
            this.lblPurchasePrice2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblPurchasePrice2.Location = new System.Drawing.Point(20, 270);
            this.lblPurchasePrice2.Name = "lblPurchasePrice2";
            this.lblPurchasePrice2.Size = new System.Drawing.Size(100, 25);
            this.lblPurchasePrice2.TabIndex = 16;
            this.lblPurchasePrice2.Text = "Alış Fiyatı 2:";
            // 
            // numStock2
            // 
            this.numStock2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.numStock2.Location = new System.Drawing.Point(290, 270);
            this.numStock2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numStock2.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.numStock2.Name = "numStock2";
            this.numStock2.Size = new System.Drawing.Size(80, 30);
            this.numStock2.TabIndex = 17;
            // 
            // lblStock2
            // 
            this.lblStock2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblStock2.Location = new System.Drawing.Point(230, 270);
            this.lblStock2.Name = "lblStock2";
            this.lblStock2.Size = new System.Drawing.Size(60, 25);
            this.lblStock2.TabIndex = 18;
            this.lblStock2.Text = "Stok 2:";
            // 
            // lblTotalStock
            // 
            this.lblTotalStock.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalStock.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTotalStock.Location = new System.Drawing.Point(20, 305);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.Size = new System.Drawing.Size(350, 22);
            this.lblTotalStock.TabIndex = 19;
            this.lblTotalStock.Text = "Toplam Stok: 0";
            // 
            // numSalePrice
            // 
            this.numSalePrice.DecimalPlaces = 2;
            this.numSalePrice.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.numSalePrice.Location = new System.Drawing.Point(120, 335);
            this.numSalePrice.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numSalePrice.Name = "numSalePrice";
            this.numSalePrice.Size = new System.Drawing.Size(100, 30);
            this.numSalePrice.TabIndex = 20;
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblSalePrice.Location = new System.Drawing.Point(20, 335);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(100, 25);
            this.lblSalePrice.TabIndex = 21;
            this.lblSalePrice.Text = "Satış Fiyatı:";
            // 
            // numVatRate
            // 
            this.numVatRate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.numVatRate.Location = new System.Drawing.Point(290, 335);
            this.numVatRate.Name = "numVatRate";
            this.numVatRate.Size = new System.Drawing.Size(80, 30);
            this.numVatRate.TabIndex = 22;
            // 
            // lblVatRate
            // 
            this.lblVatRate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblVatRate.Location = new System.Drawing.Point(230, 335);
            this.lblVatRate.Name = "lblVatRate";
            this.lblVatRate.Size = new System.Drawing.Size(60, 25);
            this.lblVatRate.TabIndex = 23;
            this.lblVatRate.Text = "KDV (%):";
            // 
            // chkIsActive
            // 
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.chkIsActive.Location = new System.Drawing.Point(120, 375);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(100, 25);
            this.chkIsActive.TabIndex = 24;
            this.chkIsActive.Text = "Aktif Mi?";
            // 
            // lblKdvCalc
            // 
            this.lblKdvCalc.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblKdvCalc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKdvCalc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKdvCalc.Location = new System.Drawing.Point(20, 405);
            this.lblKdvCalc.Name = "lblKdvCalc";
            this.lblKdvCalc.Size = new System.Drawing.Size(350, 40);
            this.lblKdvCalc.TabIndex = 25;
            this.lblKdvCalc.Text = "Hesap Bekleniyor...";
            this.lblKdvCalc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 45);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "KAYDET";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(200, 460);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(170, 45);
            this.btnUpdate.TabIndex = 27;
            this.btnUpdate.Text = "GÜNCELLE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Crimson;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(20, 515);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(170, 45);
            this.btnDelete.TabIndex = 28;
            this.btnDelete.Text = "SİL";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(200, 515);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(170, 45);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "TEMİZLE";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // pnlList
            // 
            this.pnlList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlList.Controls.Add(this.dgvProducts);
            this.pnlList.Controls.Add(this.pnlSearch);
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.Location = new System.Drawing.Point(403, 3);
            this.pnlList.Name = "pnlList";
            this.pnlList.Padding = new System.Windows.Forms.Padding(10);
            this.pnlList.Size = new System.Drawing.Size(594, 594);
            this.pnlList.TabIndex = 1;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.ColumnHeadersHeight = 29;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(10, 50);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(574, 534);
            this.dgvProducts.TabIndex = 0;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblFilterCategory);
            this.pnlSearch.Controls.Add(this.cmbFilterCategory);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(10, 10);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlSearch.Size = new System.Drawing.Size(574, 40);
            this.pnlSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSearch.Location = new System.Drawing.Point(0, 5);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(84, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Hızlı Ara:";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(70, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 30);
            this.txtSearch.TabIndex = 1;
            // 
            // lblFilterCategory
            // 
            this.lblFilterCategory.AutoSize = true;
            this.lblFilterCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFilterCategory.Location = new System.Drawing.Point(390, 5);
            this.lblFilterCategory.Name = "lblFilterCategory";
            this.lblFilterCategory.Size = new System.Drawing.Size(142, 23);
            this.lblFilterCategory.TabIndex = 2;
            this.lblFilterCategory.Text = "Kategori Seçimi:";
            // 
            // cmbFilterCategory
            // 
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.cmbFilterCategory.Location = new System.Drawing.Point(510, 2);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(150, 31);
            this.cmbFilterCategory.TabIndex = 3;
            // 
            // StokIslemleriUC
            // 
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Name = "StokIslemleriUC";
            this.Size = new System.Drawing.Size(1000, 600);
            this.tlpMain.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVatRate)).EndInit();
            this.pnlList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        
        // Form Controls
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbCategories;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Button btnGenBarcode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.DateTimePicker dtpEntryDate;
        private System.Windows.Forms.Label lblEntryDate;
        private NoSpinnerNumeric numPurchasePrice;
        private System.Windows.Forms.Label lblPurchasePrice;
        private NoSpinnerNumeric numPurchasePrice2;
        private System.Windows.Forms.Label lblPurchasePrice2;
        private NoSpinnerNumeric numSalePrice;
        private System.Windows.Forms.Label lblSalePrice;
        private NoSpinnerNumeric numVatRate;
        private System.Windows.Forms.Label lblVatRate;
        private NoSpinnerNumeric numStock;
        private System.Windows.Forms.Label lblStock;
        private NoSpinnerNumeric numStock2;
        private System.Windows.Forms.Label lblStock2;
        private System.Windows.Forms.Label lblTotalStock;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblKdvCalc;
        
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        // List Controls
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblFilterCategory;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    }
}
