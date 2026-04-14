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
            this.pnlPersonnel = new System.Windows.Forms.Panel();

            this.lblCompanyTitle = new System.Windows.Forms.Label();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.txtStoreName = new System.Windows.Forms.TextBox();
            this.lblStorePhone = new System.Windows.Forms.Label();
            this.txtStorePhone = new System.Windows.Forms.TextBox();
            this.lblStoreAddress = new System.Windows.Forms.Label();
            this.txtStoreAddress = new System.Windows.Forms.TextBox();
            this.lblDefaultVat = new System.Windows.Forms.Label();
            this.numDefaultVat = new System.Windows.Forms.NumericUpDown();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.lblDbInfo = new System.Windows.Forms.Label();

            this.lblPersonnelTitle = new System.Windows.Forms.Label();
            this.txtNewPersonnel = new System.Windows.Forms.TextBox();
            this.btnAddPersonnel = new System.Windows.Forms.Button();
            this.btnRemovePersonnel = new System.Windows.Forms.Button();
            this.lstPersonnel = new System.Windows.Forms.ListBox();

            this.tlpMain.SuspendLayout();
            this.pnlCompany.SuspendLayout();
            this.pnlPersonnel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefaultVat)).BeginInit();
            this.SuspendLayout();

            System.Drawing.Font mf = new System.Drawing.Font("Open Sans", 10F);

            // tlpMain
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlCompany, 0, 0);
            this.tlpMain.Controls.Add(this.pnlPersonnel, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;

            // pnlCompany
            this.pnlCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCompany.BackColor = System.Drawing.Color.White;
            this.pnlCompany.Padding = new System.Windows.Forms.Padding(20);

            this.lblCompanyTitle.Text = "Firma Bilgileri"; this.lblCompanyTitle.Location = new System.Drawing.Point(20, 15); this.lblCompanyTitle.Size = new System.Drawing.Size(300, 35); this.lblCompanyTitle.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Bold);

            this.lblStoreName.Text = "Mağaza Adı:"; this.lblStoreName.Location = new System.Drawing.Point(20, 60); this.lblStoreName.Size = new System.Drawing.Size(100, 25); this.lblStoreName.Font = mf;
            this.txtStoreName.Location = new System.Drawing.Point(130, 58); this.txtStoreName.Size = new System.Drawing.Size(250, 28); this.txtStoreName.Font = mf; this.txtStoreName.Text = "Örnek Market";

            this.lblStorePhone.Text = "Telefon:"; this.lblStorePhone.Location = new System.Drawing.Point(20, 95); this.lblStorePhone.Size = new System.Drawing.Size(100, 25); this.lblStorePhone.Font = mf;
            this.txtStorePhone.Location = new System.Drawing.Point(130, 93); this.txtStorePhone.Size = new System.Drawing.Size(250, 28); this.txtStorePhone.Font = mf; this.txtStorePhone.Text = "0850 123 45 67";

            this.lblStoreAddress.Text = "Adres:"; this.lblStoreAddress.Location = new System.Drawing.Point(20, 130); this.lblStoreAddress.Size = new System.Drawing.Size(100, 25); this.lblStoreAddress.Font = mf;
            this.txtStoreAddress.Location = new System.Drawing.Point(130, 128); this.txtStoreAddress.Size = new System.Drawing.Size(250, 60); this.txtStoreAddress.Font = mf; this.txtStoreAddress.Multiline = true;

            this.lblDefaultVat.Text = "Vars. KDV (%):"; this.lblDefaultVat.Location = new System.Drawing.Point(20, 200); this.lblDefaultVat.Size = new System.Drawing.Size(110, 25); this.lblDefaultVat.Font = mf;
            this.numDefaultVat.Location = new System.Drawing.Point(130, 198); this.numDefaultVat.Size = new System.Drawing.Size(80, 28); this.numDefaultVat.Font = mf; this.numDefaultVat.Maximum = 100; this.numDefaultVat.Value = 18;

            this.btnSaveSettings.Text = "AYARLARI KAYDET"; this.btnSaveSettings.Location = new System.Drawing.Point(20, 250); this.btnSaveSettings.Size = new System.Drawing.Size(360, 45); this.btnSaveSettings.BackColor = System.Drawing.Color.MediumSeaGreen; this.btnSaveSettings.ForeColor = System.Drawing.Color.White; this.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnSaveSettings.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold);

            this.lblDbInfo.Text = "Veritabanı: PostgreSQL @ localhost:5432 / UrunTakipDB"; this.lblDbInfo.Location = new System.Drawing.Point(20, 310); this.lblDbInfo.Size = new System.Drawing.Size(380, 25); this.lblDbInfo.Font = mf; this.lblDbInfo.ForeColor = System.Drawing.Color.Gray;

            this.pnlCompany.Controls.Add(this.lblCompanyTitle);
            this.pnlCompany.Controls.Add(this.lblStoreName); this.pnlCompany.Controls.Add(this.txtStoreName);
            this.pnlCompany.Controls.Add(this.lblStorePhone); this.pnlCompany.Controls.Add(this.txtStorePhone);
            this.pnlCompany.Controls.Add(this.lblStoreAddress); this.pnlCompany.Controls.Add(this.txtStoreAddress);
            this.pnlCompany.Controls.Add(this.lblDefaultVat); this.pnlCompany.Controls.Add(this.numDefaultVat);
            this.pnlCompany.Controls.Add(this.btnSaveSettings);
            this.pnlCompany.Controls.Add(this.lblDbInfo);

            // pnlPersonnel
            this.pnlPersonnel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPersonnel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPersonnel.Padding = new System.Windows.Forms.Padding(20);

            this.lblPersonnelTitle.Text = "Personel Yönetimi"; this.lblPersonnelTitle.Location = new System.Drawing.Point(20, 15); this.lblPersonnelTitle.Size = new System.Drawing.Size(300, 35); this.lblPersonnelTitle.Font = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Bold);
            this.txtNewPersonnel.Location = new System.Drawing.Point(20, 60); this.txtNewPersonnel.Size = new System.Drawing.Size(230, 28); this.txtNewPersonnel.Font = mf; this.txtNewPersonnel.Text = "";
            this.btnAddPersonnel.Text = "EKLE"; this.btnAddPersonnel.Location = new System.Drawing.Point(260, 58); this.btnAddPersonnel.Size = new System.Drawing.Size(70, 30); this.btnAddPersonnel.BackColor = System.Drawing.Color.SteelBlue; this.btnAddPersonnel.ForeColor = System.Drawing.Color.White; this.btnAddPersonnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemovePersonnel.Text = "SEÇİLİ SİL"; this.btnRemovePersonnel.Location = new System.Drawing.Point(340, 58); this.btnRemovePersonnel.Size = new System.Drawing.Size(80, 30); this.btnRemovePersonnel.BackColor = System.Drawing.Color.Crimson; this.btnRemovePersonnel.ForeColor = System.Drawing.Color.White; this.btnRemovePersonnel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lstPersonnel.Location = new System.Drawing.Point(20, 100); this.lstPersonnel.Size = new System.Drawing.Size(400, 300); this.lstPersonnel.Font = new System.Drawing.Font("Open Sans", 12F);
            this.lstPersonnel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            this.pnlPersonnel.Controls.Add(this.lblPersonnelTitle);
            this.pnlPersonnel.Controls.Add(this.txtNewPersonnel); this.pnlPersonnel.Controls.Add(this.btnAddPersonnel);
            this.pnlPersonnel.Controls.Add(this.btnRemovePersonnel); this.pnlPersonnel.Controls.Add(this.lstPersonnel);

            this.Controls.Add(this.tlpMain);
            this.Size = new System.Drawing.Size(1000, 600);

            this.tlpMain.ResumeLayout(false);
            this.pnlCompany.ResumeLayout(false); this.pnlCompany.PerformLayout();
            this.pnlPersonnel.ResumeLayout(false); this.pnlPersonnel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDefaultVat)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlCompany;
        private System.Windows.Forms.Panel pnlPersonnel;
        private System.Windows.Forms.Label lblCompanyTitle;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.TextBox txtStoreName;
        private System.Windows.Forms.Label lblStorePhone;
        private System.Windows.Forms.TextBox txtStorePhone;
        private System.Windows.Forms.Label lblStoreAddress;
        private System.Windows.Forms.TextBox txtStoreAddress;
        private System.Windows.Forms.Label lblDefaultVat;
        private System.Windows.Forms.NumericUpDown numDefaultVat;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Label lblDbInfo;
        private System.Windows.Forms.Label lblPersonnelTitle;
        private System.Windows.Forms.TextBox txtNewPersonnel;
        private System.Windows.Forms.Button btnAddPersonnel;
        private System.Windows.Forms.Button btnRemovePersonnel;
        private System.Windows.Forms.ListBox lstPersonnel;
    }
}
