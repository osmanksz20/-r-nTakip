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
            this.numPurchasePrice = new System.Windows.Forms.NumericUpDown();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.numSalePrice = new System.Windows.Forms.NumericUpDown();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.numVatRate = new System.Windows.Forms.NumericUpDown();
            this.lblVatRate = new System.Windows.Forms.Label();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.lblStock = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblKdvCalc = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.pnlList = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.tlpMain.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVatRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            this.pnlList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();

            System.Drawing.Font mainFont = new System.Drawing.Font("Segoe UI", 10F);

            // tlpMain
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlForm, 0, 0);
            this.tlpMain.Controls.Add(this.pnlList, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;

            // pnlForm
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Padding = new System.Windows.Forms.Padding(20);
            this.pnlForm.BackColor = System.Drawing.Color.White;
            
            // lblTitle
            this.lblTitle.Text = "Ürün Kayıt Formu";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Size = new System.Drawing.Size(300, 40);

            // lblCategory
            this.lblCategory.Text = "Kategori:"; this.lblCategory.Location = new System.Drawing.Point(20, 70); this.lblCategory.Size = new System.Drawing.Size(100, 25); this.lblCategory.Font = mainFont;
            this.cmbCategories.Location = new System.Drawing.Point(120, 70); this.cmbCategories.Size = new System.Drawing.Size(200, 30); this.cmbCategories.Font = mainFont; this.cmbCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.btnAddCategory.Text = "+"; this.btnAddCategory.Location = new System.Drawing.Point(330, 70); this.btnAddCategory.Size = new System.Drawing.Size(40, 30); this.btnAddCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            // lblBarcode
            this.lblBarcode.Text = "Barkod:"; this.lblBarcode.Location = new System.Drawing.Point(20, 110); this.lblBarcode.Size = new System.Drawing.Size(100, 25); this.lblBarcode.Font = mainFont;
            this.txtBarcode.Location = new System.Drawing.Point(120, 110); this.txtBarcode.Size = new System.Drawing.Size(200, 30); this.txtBarcode.Font = mainFont;
            this.btnGenBarcode.Text = "Oto"; this.btnGenBarcode.Location = new System.Drawing.Point(330, 110); this.btnGenBarcode.Size = new System.Drawing.Size(40, 30);

            // lblProductName
            this.lblProductName.Text = "Ürün Adı:"; this.lblProductName.Location = new System.Drawing.Point(20, 150); this.lblProductName.Size = new System.Drawing.Size(100, 25); this.lblProductName.Font = mainFont;
            this.txtProductName.Location = new System.Drawing.Point(120, 150); this.txtProductName.Size = new System.Drawing.Size(250, 30); this.txtProductName.Font = mainFont;

            // lblEntryDate
            this.lblEntryDate.Text = "Giriş Tarihi:"; this.lblEntryDate.Location = new System.Drawing.Point(20, 190); this.lblEntryDate.Size = new System.Drawing.Size(100, 25); this.lblEntryDate.Font = mainFont;
            this.dtpEntryDate.Location = new System.Drawing.Point(120, 190); this.dtpEntryDate.Size = new System.Drawing.Size(250, 30); this.dtpEntryDate.Font = mainFont; this.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            // Prices
            this.lblPurchasePrice.Text = "Alış Fiyatı:"; this.lblPurchasePrice.Location = new System.Drawing.Point(20, 230); this.lblPurchasePrice.Size = new System.Drawing.Size(100, 25); this.lblPurchasePrice.Font = mainFont;
            this.numPurchasePrice.Location = new System.Drawing.Point(120, 230); this.numPurchasePrice.Size = new System.Drawing.Size(100, 30); this.numPurchasePrice.Font = mainFont; this.numPurchasePrice.DecimalPlaces = 2; this.numPurchasePrice.Maximum = 999999;

            this.lblSalePrice.Text = "Satış Fiyatı:"; this.lblSalePrice.Location = new System.Drawing.Point(230, 230); this.lblSalePrice.Size = new System.Drawing.Size(80, 25); this.lblSalePrice.Font = mainFont;
            this.numSalePrice.Location = new System.Drawing.Point(310, 230); this.numSalePrice.Size = new System.Drawing.Size(60, 30); this.numSalePrice.Font = mainFont; this.numSalePrice.DecimalPlaces = 2; this.numSalePrice.Maximum = 999999;

            // VAT and Stock
            this.lblVatRate.Text = "KDV (%):"; this.lblVatRate.Location = new System.Drawing.Point(20, 270); this.lblVatRate.Size = new System.Drawing.Size(100, 25); this.lblVatRate.Font = mainFont;
            this.numVatRate.Location = new System.Drawing.Point(120, 270); this.numVatRate.Size = new System.Drawing.Size(100, 30); this.numVatRate.Font = mainFont; this.numVatRate.Maximum = 100;
            
            this.lblStock.Text = "Stok Adedi:"; this.lblStock.Location = new System.Drawing.Point(230, 270); this.lblStock.Size = new System.Drawing.Size(80, 25); this.lblStock.Font = mainFont;
            this.numStock.Location = new System.Drawing.Point(310, 270); this.numStock.Size = new System.Drawing.Size(60, 30); this.numStock.Font = mainFont; this.numStock.Maximum = 999999;

            this.chkIsActive.Text = "Aktif Mi?"; this.chkIsActive.Location = new System.Drawing.Point(120, 310); this.chkIsActive.Size = new System.Drawing.Size(100, 25); this.chkIsActive.Font = mainFont; this.chkIsActive.Checked = true;

            // KDV Calc View
            this.lblKdvCalc.Location = new System.Drawing.Point(20, 340);
            this.lblKdvCalc.Size = new System.Drawing.Size(350, 40);
            this.lblKdvCalc.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblKdvCalc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKdvCalc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblKdvCalc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKdvCalc.Text = "Hesap Bekleniyor...";

            // Action Buttons
            this.btnSave.Text = "KAYDET"; this.btnSave.Location = new System.Drawing.Point(20, 400); this.btnSave.Size = new System.Drawing.Size(170, 45); this.btnSave.BackColor = System.Drawing.Color.MediumSeaGreen; this.btnSave.ForeColor = System.Drawing.Color.White; this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Text = "GÜNCELLE"; this.btnUpdate.Location = new System.Drawing.Point(200, 400); this.btnUpdate.Size = new System.Drawing.Size(170, 45); this.btnUpdate.BackColor = System.Drawing.Color.SteelBlue; this.btnUpdate.ForeColor = System.Drawing.Color.White; this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Text = "SİL"; this.btnDelete.Location = new System.Drawing.Point(20, 455); this.btnDelete.Size = new System.Drawing.Size(170, 45); this.btnDelete.BackColor = System.Drawing.Color.Crimson; this.btnDelete.ForeColor = System.Drawing.Color.White; this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Text = "TEMİZLE"; this.btnClear.Location = new System.Drawing.Point(200, 455); this.btnClear.Size = new System.Drawing.Size(170, 45); this.btnClear.BackColor = System.Drawing.Color.Gray; this.btnClear.ForeColor = System.Drawing.Color.White; this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.pnlForm.Controls.Add(this.lblTitle);
            this.pnlForm.Controls.Add(this.cmbCategories); this.pnlForm.Controls.Add(this.lblCategory); this.pnlForm.Controls.Add(this.btnAddCategory);
            this.pnlForm.Controls.Add(this.txtBarcode); this.pnlForm.Controls.Add(this.lblBarcode); this.pnlForm.Controls.Add(this.btnGenBarcode);
            this.pnlForm.Controls.Add(this.txtProductName); this.pnlForm.Controls.Add(this.lblProductName);
            this.pnlForm.Controls.Add(this.dtpEntryDate); this.pnlForm.Controls.Add(this.lblEntryDate);
            this.pnlForm.Controls.Add(this.numPurchasePrice); this.pnlForm.Controls.Add(this.lblPurchasePrice);
            this.pnlForm.Controls.Add(this.numSalePrice); this.pnlForm.Controls.Add(this.lblSalePrice);
            this.pnlForm.Controls.Add(this.numVatRate); this.pnlForm.Controls.Add(this.lblVatRate);
            this.pnlForm.Controls.Add(this.numStock); this.pnlForm.Controls.Add(this.lblStock);
            this.pnlForm.Controls.Add(this.chkIsActive);
            this.pnlForm.Controls.Add(this.lblKdvCalc);
            this.pnlForm.Controls.Add(this.btnSave); this.pnlForm.Controls.Add(this.btnUpdate); this.pnlForm.Controls.Add(this.btnDelete); this.pnlForm.Controls.Add(this.btnClear);

            // pnlList
            this.pnlList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlList.Padding = new System.Windows.Forms.Padding(10);
            
            // dgvProducts
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colId, this.colBarcode, this.colName, this.colCat, this.colStock, this.colPrice});
            
            this.colId.Name = "colId"; this.colId.DataPropertyName = "Id"; this.colId.HeaderText = "ID"; this.colId.Visible = false;
            this.colBarcode.DataPropertyName = "Barcode"; this.colBarcode.HeaderText = "Barkod";
            this.colName.DataPropertyName = "Name"; this.colName.HeaderText = "Ürün Adı";
            this.colCat.DataPropertyName = "Kategori"; this.colCat.HeaderText = "Kategori";
            this.colStock.DataPropertyName = "CurrentStock"; this.colStock.HeaderText = "Stok";
            this.colPrice.DataPropertyName = "SalePrice"; this.colPrice.HeaderText = "Satış Fiyatı";

            this.pnlList.Controls.Add(this.dgvProducts);

            // StokIslemleriUC
            this.Controls.Add(this.tlpMain);
            this.Name = "StokIslemleriUC";
            this.Size = new System.Drawing.Size(1000, 600);
            this.Font = mainFont;

            this.tlpMain.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPurchasePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVatRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            this.pnlList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numPurchasePrice;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.NumericUpDown numSalePrice;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.NumericUpDown numVatRate;
        private System.Windows.Forms.Label lblVatRate;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblKdvCalc;
        
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;

        // List Controls
        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
    }
}
