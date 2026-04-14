namespace ÜrünTakip.Views
{
    partial class RaporlarUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Bileşen Tasarımcısı Üretimi Kod
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();

            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblDailyTitle = new System.Windows.Forms.Label();
            this.lblDailySales = new System.Windows.Forms.Label();
            this.lblDailyVat = new System.Windows.Forms.Label();
            this.lblDailyCount = new System.Windows.Forms.Label();
            this.lblDailyProfit = new System.Windows.Forms.Label();

            this.pnlActions = new System.Windows.Forms.Panel();
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblReportDate = new System.Windows.Forms.Label();

            this.pnlTopProducts = new System.Windows.Forms.Panel();
            this.lblTopTitle = new System.Windows.Forms.Label();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();

            this.pnlLowStock = new System.Windows.Forms.Panel();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();

            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.SuspendLayout();

            System.Drawing.Font mf = new System.Drawing.Font("Segoe UI", 10F);
            System.Drawing.Font bigFont = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);

            // tlpMain (2x2 grid)
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMain.Controls.Add(this.pnlSummary, 0, 0);
            this.tlpMain.Controls.Add(this.pnlActions, 1, 0);
            this.tlpMain.Controls.Add(this.pnlTopProducts, 0, 1);
            this.tlpMain.Controls.Add(this.pnlLowStock, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;

            // pnlSummary
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSummary.BackColor = System.Drawing.Color.White;
            this.pnlSummary.Padding = new System.Windows.Forms.Padding(20);
            this.lblDailyTitle.Text = "GÜNLÜK SATIŞ ÖZETİ"; this.lblDailyTitle.Location = new System.Drawing.Point(20, 15); this.lblDailyTitle.Size = new System.Drawing.Size(300, 30); this.lblDailyTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDailySales.Text = "Toplam Ciro: 0,00 ₺"; this.lblDailySales.Location = new System.Drawing.Point(20, 55); this.lblDailySales.Size = new System.Drawing.Size(350, 40); this.lblDailySales.Font = bigFont; this.lblDailySales.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblDailyVat.Text = "KDV Toplamı: 0,00 ₺"; this.lblDailyVat.Location = new System.Drawing.Point(20, 100); this.lblDailyVat.Size = new System.Drawing.Size(300, 25); this.lblDailyVat.Font = mf;
            this.lblDailyCount.Text = "Satış Adedi: 0"; this.lblDailyCount.Location = new System.Drawing.Point(20, 130); this.lblDailyCount.Size = new System.Drawing.Size(300, 25); this.lblDailyCount.Font = mf;
            this.lblDailyProfit.Text = "Brüt Kâr: 0,00 ₺"; this.lblDailyProfit.Location = new System.Drawing.Point(20, 160); this.lblDailyProfit.Size = new System.Drawing.Size(300, 30); this.lblDailyProfit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold); this.lblDailyProfit.ForeColor = System.Drawing.Color.SteelBlue;
            this.pnlSummary.Controls.Add(this.lblDailyTitle); this.pnlSummary.Controls.Add(this.lblDailySales);
            this.pnlSummary.Controls.Add(this.lblDailyVat); this.pnlSummary.Controls.Add(this.lblDailyCount);
            this.pnlSummary.Controls.Add(this.lblDailyProfit);

            // pnlActions
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActions.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlActions.Padding = new System.Windows.Forms.Padding(20);
            this.lblReportDate.Text = "Rapor Tarihi:"; this.lblReportDate.Location = new System.Drawing.Point(20, 20); this.lblReportDate.Size = new System.Drawing.Size(100, 25); this.lblReportDate.Font = mf;
            this.dtpReportDate.Location = new System.Drawing.Point(125, 18); this.dtpReportDate.Size = new System.Drawing.Size(200, 28); this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.btnRefresh.Text = "RAPORU GÜNCELLE"; this.btnRefresh.Location = new System.Drawing.Point(20, 60); this.btnRefresh.Size = new System.Drawing.Size(305, 45); this.btnRefresh.BackColor = System.Drawing.Color.SteelBlue; this.btnRefresh.ForeColor = System.Drawing.Color.White; this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.pnlActions.Controls.Add(this.lblReportDate); this.pnlActions.Controls.Add(this.dtpReportDate); this.pnlActions.Controls.Add(this.btnRefresh);

            // pnlTopProducts
            this.pnlTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopProducts.BackColor = System.Drawing.Color.White;
            this.pnlTopProducts.Padding = new System.Windows.Forms.Padding(5);
            this.lblTopTitle.Text = "  EN ÇOK SATAN 10 ÜRÜN"; this.lblTopTitle.Dock = System.Windows.Forms.DockStyle.Top; this.lblTopTitle.Height = 30; this.lblTopTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold); this.lblTopTitle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dgvTopProducts.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvTopProducts.AllowUserToAddRows = false; this.dgvTopProducts.ReadOnly = true; this.dgvTopProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvTopProducts.BackgroundColor = System.Drawing.Color.White;
            this.pnlTopProducts.Controls.Add(this.dgvTopProducts); this.pnlTopProducts.Controls.Add(this.lblTopTitle);

            // pnlLowStock
            this.pnlLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLowStock.BackColor = System.Drawing.Color.White;
            this.pnlLowStock.Padding = new System.Windows.Forms.Padding(5);
            this.lblLowStockTitle.Text = "  KRİTİK STOK UYARISI (< 3 adet)"; this.lblLowStockTitle.Dock = System.Windows.Forms.DockStyle.Top; this.lblLowStockTitle.Height = 30; this.lblLowStockTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold); this.lblLowStockTitle.BackColor = System.Drawing.Color.MistyRose;
            this.dgvLowStock.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvLowStock.AllowUserToAddRows = false; this.dgvLowStock.ReadOnly = true; this.dgvLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvLowStock.BackgroundColor = System.Drawing.Color.White;
            this.pnlLowStock.Controls.Add(this.dgvLowStock); this.pnlLowStock.Controls.Add(this.lblLowStockTitle);

            this.Controls.Add(this.tlpMain);
            this.Size = new System.Drawing.Size(1000, 600);

            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblDailyTitle;
        private System.Windows.Forms.Label lblDailySales;
        private System.Windows.Forms.Label lblDailyVat;
        private System.Windows.Forms.Label lblDailyCount;
        private System.Windows.Forms.Label lblDailyProfit;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblReportDate;
        private System.Windows.Forms.Panel pnlTopProducts;
        private System.Windows.Forms.Label lblTopTitle;
        private System.Windows.Forms.DataGridView dgvTopProducts;
        private System.Windows.Forms.Panel pnlLowStock;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.DataGridView dgvLowStock;
    }
}
