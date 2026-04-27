using ÜrünTakip.Controls;
namespace ÜrünTakip.Views
{
    partial class AyarlarUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Bileşen Tasarımcısı Üretimi Kod
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCompany = new System.Windows.Forms.Panel();
            this.lblCompanyTitle = new System.Windows.Forms.Label();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.lblStorePhone = new System.Windows.Forms.Label();
            this.txtStorePhone = new System.Windows.Forms.TextBox();
            this.lblStoreAddress = new System.Windows.Forms.Label();
            this.txtStoreAddress = new System.Windows.Forms.TextBox();
            this.lblDefaultVat = new System.Windows.Forms.Label();
            this.numDefaultVat = new ÜrünTakip.Controls.NoSpinnerNumeric();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.lblDbInfo = new System.Windows.Forms.Label();
            this.lblBackupPath = new System.Windows.Forms.Label();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.btnBrowseBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.pnlPersonnel = new System.Windows.Forms.Panel();
            this.lblPersonnelTitle = new System.Windows.Forms.Label();
            this.txtNewPersonnel = new System.Windows.Forms.TextBox();
            this.btnAddPersonnel = new System.Windows.Forms.Button();
            this.btnRemovePersonnel = new System.Windows.Forms.Button();
            this.lstPersonnel = new System.Windows.Forms.ListBox();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.btnRemoveCategory = new System.Windows.Forms.Button();
            this.lstCategories = new System.Windows.Forms.ListBox();
            this.btnRefreshCategories = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.pnlCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefaultVat)).BeginInit();
            this.pnlPersonnel.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpMain.Controls.Add(this.pnlCompany, 0, 0);
            this.tlpMain.Controls.Add(this.pnlPersonnel, 1, 0);
            this.tlpMain.Controls.Add(this.pnlCategory, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1000, 600);
            this.tlpMain.TabIndex = 0;
            // 
            // pnlCompany
            // 
            this.pnlCompany.BackColor = System.Drawing.Color.White;
            this.pnlCompany.Controls.Add(this.lblCompanyTitle);
            this.pnlCompany.Controls.Add(this.lblStoreName);
            this.pnlCompany.Controls.Add(this.txtStoreName);
            this.pnlCompany.Controls.Add(this.lblStorePhone);
            this.pnlCompany.Controls.Add(this.txtStorePhone);
            this.pnlCompany.Controls.Add(this.lblStoreAddress);
            this.pnlCompany.Controls.Add(this.txtStoreAddress);
            this.pnlCompany.Controls.Add(this.lblDefaultVat);
            this.pnlCompany.Controls.Add(this.numDefaultVat);
            this.pnlCompany.Controls.Add(this.btnSaveSettings);
            this.pnlCompany.Controls.Add(this.lblDbInfo);
            this.pnlCompany.Controls.Add(this.lblBackupPath);
            this.pnlCompany.Controls.Add(this.txtBackupPath);
            this.pnlCompany.Controls.Add(this.btnBrowseBackup);
            this.pnlCompany.Controls.Add(this.btnRestore);
            this.pnlCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCompany.Location = new System.Drawing.Point(3, 3);
            this.pnlCompany.Name = "pnlCompany";
            this.pnlCompany.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCompany.Size = new System.Drawing.Size(327, 594);
            this.pnlCompany.TabIndex = 0;
            // 
            // lblCompanyTitle
            // 
            this.lblCompanyTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCompanyTitle.Location = new System.Drawing.Point(20, 15);
            this.lblCompanyTitle.Name = "lblCompanyTitle";
            this.lblCompanyTitle.Size = new System.Drawing.Size(300, 35);
            this.lblCompanyTitle.TabIndex = 0;
            this.lblCompanyTitle.Text = "Firma Bilgileri";
            // 
            // lblStoreName
            // 
            this.lblStoreName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblStoreName.Location = new System.Drawing.Point(20, 60);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(100, 25);
            this.lblStoreName.TabIndex = 1;
            this.lblStoreName.Text = "Mağaza Adı:";
            // 
            // txtStoreName
            // 
            this.txtStoreName.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtStoreName.Location = new System.Drawing.Point(130, 58);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Size = new System.Drawing.Size(250, 30);
            this.txtStoreName.TabIndex = 2;
            this.txtStoreName.Text = "Örnek Market";
            // 
            // lblStorePhone
            // 
            this.lblStorePhone.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblStorePhone.Location = new System.Drawing.Point(20, 95);
            this.lblStorePhone.Name = "lblStorePhone";
            this.lblStorePhone.Size = new System.Drawing.Size(100, 25);
            this.lblStorePhone.TabIndex = 3;
            this.lblStorePhone.Text = "Telefon:";
            // 
            // txtStorePhone
            // 
            this.txtStorePhone.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtStorePhone.Location = new System.Drawing.Point(130, 93);
            this.txtStorePhone.Name = "txtStorePhone";
            this.txtStorePhone.Size = new System.Drawing.Size(250, 30);
            this.txtStorePhone.TabIndex = 4;
            this.txtStorePhone.Text = "0850 123 45 67";
            // 
            // lblStoreAddress
            // 
            this.lblStoreAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblStoreAddress.Location = new System.Drawing.Point(20, 130);
            this.lblStoreAddress.Name = "lblStoreAddress";
            this.lblStoreAddress.Size = new System.Drawing.Size(100, 25);
            this.lblStoreAddress.TabIndex = 5;
            this.lblStoreAddress.Text = "Adres:";
            // 
            // txtStoreAddress
            // 
            this.txtStoreAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtStoreAddress.Location = new System.Drawing.Point(130, 128);
            this.txtStoreAddress.Multiline = true;
            this.txtStoreAddress.Name = "txtStoreAddress";
            this.txtStoreAddress.Size = new System.Drawing.Size(250, 60);
            this.txtStoreAddress.TabIndex = 6;
            // 
            // lblDefaultVat
            // 
            this.lblDefaultVat.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblDefaultVat.Location = new System.Drawing.Point(20, 200);
            this.lblDefaultVat.Name = "lblDefaultVat";
            this.lblDefaultVat.Size = new System.Drawing.Size(110, 25);
            this.lblDefaultVat.TabIndex = 7;
            this.lblDefaultVat.Text = "Vars. KDV (%):";
            // 
            // numDefaultVat
            // 
            this.numDefaultVat.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.numDefaultVat.Location = new System.Drawing.Point(130, 198);
            this.numDefaultVat.Name = "numDefaultVat";
            this.numDefaultVat.Size = new System.Drawing.Size(80, 30);
            this.numDefaultVat.TabIndex = 8;
            this.numDefaultVat.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaveSettings.ForeColor = System.Drawing.Color.White;
            this.btnSaveSettings.Location = new System.Drawing.Point(20, 250);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(360, 45);
            this.btnSaveSettings.TabIndex = 9;
            this.btnSaveSettings.Text = "AYARLARI KAYDET";
            this.btnSaveSettings.UseVisualStyleBackColor = false;
            // 
            // lblDbInfo
            // 
            this.lblDbInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblDbInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblDbInfo.Location = new System.Drawing.Point(20, 310);
            this.lblDbInfo.Name = "lblDbInfo";
            this.lblDbInfo.Size = new System.Drawing.Size(380, 25);
            this.lblDbInfo.TabIndex = 10;
            this.lblDbInfo.Text = "Veritabanı: PostgreSQL @ localhost:5432 / UrunTakipDB";
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblBackupPath.Location = new System.Drawing.Point(20, 350);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(120, 25);
            this.lblBackupPath.TabIndex = 11;
            this.lblBackupPath.Text = "Yedek Klasörü:";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBackupPath.Location = new System.Drawing.Point(20, 378);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.ReadOnly = true;
            this.txtBackupPath.Size = new System.Drawing.Size(300, 27);
            this.txtBackupPath.TabIndex = 12;
            // 
            // btnBrowseBackup
            // 
            this.btnBrowseBackup.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBrowseBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowseBackup.ForeColor = System.Drawing.Color.White;
            this.btnBrowseBackup.Location = new System.Drawing.Point(325, 376);
            this.btnBrowseBackup.Name = "btnBrowseBackup";
            this.btnBrowseBackup.Size = new System.Drawing.Size(55, 29);
            this.btnBrowseBackup.TabIndex = 13;
            this.btnBrowseBackup.Text = "📁";
            this.btnBrowseBackup.UseVisualStyleBackColor = false;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.DarkOrange;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(20, 420);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(360, 45);
            this.btnRestore.TabIndex = 14;
            this.btnRestore.Text = "♻️ YEDEKTENGERİ YÜKLE";
            this.btnRestore.UseVisualStyleBackColor = false;
            // 
            // pnlPersonnel
            // 
            this.pnlPersonnel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPersonnel.Controls.Add(this.lblPersonnelTitle);
            this.pnlPersonnel.Controls.Add(this.txtNewPersonnel);
            this.pnlPersonnel.Controls.Add(this.btnAddPersonnel);
            this.pnlPersonnel.Controls.Add(this.btnRemovePersonnel);
            this.pnlPersonnel.Controls.Add(this.lstPersonnel);
            this.pnlPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPersonnel.Location = new System.Drawing.Point(336, 3);
            this.pnlPersonnel.Name = "pnlPersonnel";
            this.pnlPersonnel.Padding = new System.Windows.Forms.Padding(20);
            this.pnlPersonnel.Size = new System.Drawing.Size(327, 594);
            this.pnlPersonnel.TabIndex = 1;
            // 
            // lblPersonnelTitle
            // 
            this.lblPersonnelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPersonnelTitle.Location = new System.Drawing.Point(20, 15);
            this.lblPersonnelTitle.Name = "lblPersonnelTitle";
            this.lblPersonnelTitle.Size = new System.Drawing.Size(300, 35);
            this.lblPersonnelTitle.TabIndex = 0;
            this.lblPersonnelTitle.Text = "Personel Yönetimi";
            // 
            // txtNewPersonnel
            // 
            this.txtNewPersonnel.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtNewPersonnel.Location = new System.Drawing.Point(20, 60);
            this.txtNewPersonnel.Name = "txtNewPersonnel";
            this.txtNewPersonnel.Size = new System.Drawing.Size(230, 30);
            this.txtNewPersonnel.TabIndex = 1;
            // 
            // btnAddPersonnel
            // 
            this.btnAddPersonnel.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddPersonnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPersonnel.ForeColor = System.Drawing.Color.White;
            this.btnAddPersonnel.Location = new System.Drawing.Point(260, 58);
            this.btnAddPersonnel.Name = "btnAddPersonnel";
            this.btnAddPersonnel.Size = new System.Drawing.Size(70, 30);
            this.btnAddPersonnel.TabIndex = 2;
            this.btnAddPersonnel.Text = "EKLE";
            this.btnAddPersonnel.UseVisualStyleBackColor = false;
            // 
            // btnRemovePersonnel
            // 
            this.btnRemovePersonnel.BackColor = System.Drawing.Color.Crimson;
            this.btnRemovePersonnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemovePersonnel.ForeColor = System.Drawing.Color.White;
            this.btnRemovePersonnel.Location = new System.Drawing.Point(340, 58);
            this.btnRemovePersonnel.Name = "btnRemovePersonnel";
            this.btnRemovePersonnel.Size = new System.Drawing.Size(80, 30);
            this.btnRemovePersonnel.TabIndex = 3;
            this.btnRemovePersonnel.Text = "SEÇİLİ SİL";
            this.btnRemovePersonnel.UseVisualStyleBackColor = false;
            // 
            // lstPersonnel
            // 
            this.lstPersonnel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPersonnel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstPersonnel.ItemHeight = 28;
            this.lstPersonnel.Location = new System.Drawing.Point(20, 100);
            this.lstPersonnel.Name = "lstPersonnel";
            this.lstPersonnel.Size = new System.Drawing.Size(527, 788);
            this.lstPersonnel.TabIndex = 4;
            // 
            // pnlCategory
            // 
            this.pnlCategory.BackColor = System.Drawing.Color.White;
            this.pnlCategory.Controls.Add(this.lblCategoryTitle);
            this.pnlCategory.Controls.Add(this.btnRemoveCategory);
            this.pnlCategory.Controls.Add(this.lstCategories);
            this.pnlCategory.Controls.Add(this.btnRefreshCategories);
            this.pnlCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategory.Location = new System.Drawing.Point(669, 3);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Padding = new System.Windows.Forms.Padding(20);
            this.pnlCategory.Size = new System.Drawing.Size(328, 594);
            this.pnlCategory.TabIndex = 2;
            // 
            // lblCategoryTitle
            // 
            this.lblCategoryTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCategoryTitle.Location = new System.Drawing.Point(20, 15);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(300, 35);
            this.lblCategoryTitle.TabIndex = 0;
            this.lblCategoryTitle.Text = "Kategori Yönetimi";
            // 
            // btnRemoveCategory
            // 
            this.btnRemoveCategory.BackColor = System.Drawing.Color.Crimson;
            this.btnRemoveCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveCategory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRemoveCategory.ForeColor = System.Drawing.Color.White;
            this.btnRemoveCategory.Location = new System.Drawing.Point(20, 60);
            this.btnRemoveCategory.Name = "btnRemoveCategory";
            this.btnRemoveCategory.Size = new System.Drawing.Size(200, 35);
            this.btnRemoveCategory.TabIndex = 1;
            this.btnRemoveCategory.Text = "SEÇİLİ KATEGORİYİ SİL";
            this.btnRemoveCategory.UseVisualStyleBackColor = false;
            // 
            // lstCategories
            // 
            this.lstCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstCategories.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstCategories.ItemHeight = 28;
            this.lstCategories.Location = new System.Drawing.Point(20, 110);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(428, 788);
            this.lstCategories.TabIndex = 2;
            // 
            // btnRefreshCategories
            // 
            this.btnRefreshCategories.BackColor = System.Drawing.Color.LightGray;
            this.btnRefreshCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshCategories.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefreshCategories.Location = new System.Drawing.Point(230, 60);
            this.btnRefreshCategories.Name = "btnRefreshCategories";
            this.btnRefreshCategories.Size = new System.Drawing.Size(40, 35);
            this.btnRefreshCategories.TabIndex = 3;
            this.btnRefreshCategories.Text = "🔄";
            this.btnRefreshCategories.UseVisualStyleBackColor = false;
            // 
            // AyarlarUC
            // 
            this.Controls.Add(this.tlpMain);
            this.Name = "AyarlarUC";
            this.Size = new System.Drawing.Size(1000, 600);
            this.tlpMain.ResumeLayout(false);
            this.pnlCompany.ResumeLayout(false);
            this.pnlCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefaultVat)).EndInit();
            this.pnlPersonnel.ResumeLayout(false);
            this.pnlPersonnel.PerformLayout();
            this.pnlCategory.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlCompany;
        private System.Windows.Forms.Panel pnlPersonnel;
        private System.Windows.Forms.Panel pnlCategory;
        private System.Windows.Forms.Label lblCompanyTitle;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.TextBox txtStoreName;
        private System.Windows.Forms.Label lblStorePhone;
        private System.Windows.Forms.TextBox txtStorePhone;
        private System.Windows.Forms.Label lblStoreAddress;
        private System.Windows.Forms.TextBox txtStoreAddress;
        private System.Windows.Forms.Label lblDefaultVat;
        private NoSpinnerNumeric numDefaultVat;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Label lblDbInfo;
        private System.Windows.Forms.Label lblBackupPath;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Button btnBrowseBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label lblPersonnelTitle;
        private System.Windows.Forms.TextBox txtNewPersonnel;
        private System.Windows.Forms.Button btnAddPersonnel;
        private System.Windows.Forms.Button btnRemovePersonnel;
        private System.Windows.Forms.ListBox lstPersonnel;
        private System.Windows.Forms.Label lblCategoryTitle;
        private System.Windows.Forms.ListBox lstCategories;
        private System.Windows.Forms.Button btnRemoveCategory;
        private System.Windows.Forms.Button btnRefreshCategories;
    }
}
