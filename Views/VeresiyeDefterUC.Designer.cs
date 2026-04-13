namespace ÜrünTakip.Views
{
    partial class VeresiyeDefterUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Bileşen Tasarımcısı Üretimi Kod
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.pnlCustomerList = new System.Windows.Forms.Panel();
            this.pnlHistory = new System.Windows.Forms.Panel();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnSaveCustomer = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnClearCustomer = new System.Windows.Forms.Button();
            this.btnTakePayment = new System.Windows.Forms.Button();

            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.lblDebtInfo = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();

            this.tlpMain.SuspendLayout();
            this.pnlForm.SuspendLayout();
            this.pnlCustomerList.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.SuspendLayout();

            System.Drawing.Font mf = new System.Drawing.Font("Segoe UI", 10F);

            // tlpMain
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pnlForm, 0, 0);
            this.tlpMain.Controls.Add(this.pnlCustomerList, 1, 0);
            this.tlpMain.Controls.Add(this.pnlHistory, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;

            // pnlForm
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.BackColor = System.Drawing.Color.White;
            this.pnlForm.Padding = new System.Windows.Forms.Padding(15);

            this.lblTitle.Text = "Müşteri Bilgileri"; this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); this.lblTitle.Location = new System.Drawing.Point(15, 15); this.lblTitle.Size = new System.Drawing.Size(250, 35);
            this.lblName.Text = "Ad Soyad:"; this.lblName.Location = new System.Drawing.Point(15, 60); this.lblName.Size = new System.Drawing.Size(80, 25); this.lblName.Font = mf;
            this.txtName.Location = new System.Drawing.Point(100, 58); this.txtName.Size = new System.Drawing.Size(165, 28); this.txtName.Font = mf;
            this.lblPhone.Text = "Telefon:"; this.lblPhone.Location = new System.Drawing.Point(15, 95); this.lblPhone.Size = new System.Drawing.Size(80, 25); this.lblPhone.Font = mf;
            this.txtPhone.Location = new System.Drawing.Point(100, 93); this.txtPhone.Size = new System.Drawing.Size(165, 28); this.txtPhone.Font = mf;
            this.lblAddress.Text = "Adres:"; this.lblAddress.Location = new System.Drawing.Point(15, 130); this.lblAddress.Size = new System.Drawing.Size(80, 25); this.lblAddress.Font = mf;
            this.txtAddress.Location = new System.Drawing.Point(100, 128); this.txtAddress.Size = new System.Drawing.Size(165, 60); this.txtAddress.Font = mf; this.txtAddress.Multiline = true;

            this.btnSaveCustomer.Text = "KAYDET"; this.btnSaveCustomer.Location = new System.Drawing.Point(15, 200); this.btnSaveCustomer.Size = new System.Drawing.Size(120, 40); this.btnSaveCustomer.BackColor = System.Drawing.Color.MediumSeaGreen; this.btnSaveCustomer.ForeColor = System.Drawing.Color.White; this.btnSaveCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnSaveCustomer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteCustomer.Text = "SİL"; this.btnDeleteCustomer.Location = new System.Drawing.Point(145, 200); this.btnDeleteCustomer.Size = new System.Drawing.Size(120, 40); this.btnDeleteCustomer.BackColor = System.Drawing.Color.Crimson; this.btnDeleteCustomer.ForeColor = System.Drawing.Color.White; this.btnDeleteCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnDeleteCustomer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearCustomer.Text = "TEMİZLE"; this.btnClearCustomer.Location = new System.Drawing.Point(15, 250); this.btnClearCustomer.Size = new System.Drawing.Size(120, 40); this.btnClearCustomer.BackColor = System.Drawing.Color.Gray; this.btnClearCustomer.ForeColor = System.Drawing.Color.White; this.btnClearCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnClearCustomer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTakePayment.Text = "ÖDEME AL"; this.btnTakePayment.Location = new System.Drawing.Point(145, 250); this.btnTakePayment.Size = new System.Drawing.Size(120, 40); this.btnTakePayment.BackColor = System.Drawing.Color.SteelBlue; this.btnTakePayment.ForeColor = System.Drawing.Color.White; this.btnTakePayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnTakePayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            this.lblDebtInfo.Text = "Toplam Borç: 0,00 ₺"; this.lblDebtInfo.Location = new System.Drawing.Point(15, 310); this.lblDebtInfo.Size = new System.Drawing.Size(250, 40); this.lblDebtInfo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); this.lblDebtInfo.ForeColor = System.Drawing.Color.Crimson;

            this.pnlForm.Controls.Add(this.lblTitle); this.pnlForm.Controls.Add(this.lblName); this.pnlForm.Controls.Add(this.txtName);
            this.pnlForm.Controls.Add(this.lblPhone); this.pnlForm.Controls.Add(this.txtPhone);
            this.pnlForm.Controls.Add(this.lblAddress); this.pnlForm.Controls.Add(this.txtAddress);
            this.pnlForm.Controls.Add(this.btnSaveCustomer); this.pnlForm.Controls.Add(this.btnDeleteCustomer);
            this.pnlForm.Controls.Add(this.btnClearCustomer); this.pnlForm.Controls.Add(this.btnTakePayment);
            this.pnlForm.Controls.Add(this.lblDebtInfo);

            // pnlCustomerList
            this.pnlCustomerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCustomerList.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlCustomerList.Padding = new System.Windows.Forms.Padding(5);
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.AllowUserToAddRows = false; this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.pnlCustomerList.Controls.Add(this.dgvCustomers);

            // pnlHistory
            this.pnlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHistory.Padding = new System.Windows.Forms.Padding(5);
            this.lblHistoryTitle.Text = "Veresiye Geçmişi"; this.lblHistoryTitle.Dock = System.Windows.Forms.DockStyle.Top; this.lblHistoryTitle.Height = 30; this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold); this.lblHistoryTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.AllowUserToAddRows = false; this.dgvHistory.ReadOnly = true;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.pnlHistory.Controls.Add(this.dgvHistory);
            this.pnlHistory.Controls.Add(this.lblHistoryTitle);

            // UserControl
            this.Controls.Add(this.tlpMain);
            this.Size = new System.Drawing.Size(1000, 600);

            this.tlpMain.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false); this.pnlForm.PerformLayout();
            this.pnlCustomerList.ResumeLayout(false);
            this.pnlHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlCustomerList;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnSaveCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnClearCustomer;
        private System.Windows.Forms.Button btnTakePayment;
        private System.Windows.Forms.Label lblDebtInfo;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Label lblHistoryTitle;
    }
}
