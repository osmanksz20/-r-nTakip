namespace ÜrünTakip.Views
{
    partial class RaporlarUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Bileşen Tasarımcısı Üretimi Kod
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblReportStartDate = new System.Windows.Forms.Label();
            this.dtpReportStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblReportEndDate = new System.Windows.Forms.Label();
            this.dtpReportEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();

            this.pnlContent = new System.Windows.Forms.Panel();

            this.pnlMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMenuSummary = new System.Windows.Forms.Button();
            this.btnMenuTop = new System.Windows.Forms.Button();
            this.btnMenuLow = new System.Windows.Forms.Button();
            this.btnMenuDetail = new System.Windows.Forms.Button();

            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblDailyTitle = new System.Windows.Forms.Label();
            this.lblDailySales = new System.Windows.Forms.Label();
            this.lblDailyVat = new System.Windows.Forms.Label();
            this.lblDailyCount = new System.Windows.Forms.Label();
            this.lblDailyProfit = new System.Windows.Forms.Label();

            this.pnlTopProducts = new System.Windows.Forms.Panel();
            this.lblTopTitle = new System.Windows.Forms.Label();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();

            this.pnlLowStock = new System.Windows.Forms.Panel();
            this.lblLowStockTitle = new System.Windows.Forms.Label();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();

            this.pnlDailySalesDetail = new System.Windows.Forms.Panel();
            this.lblDailySalesDetailTitle = new System.Windows.Forms.Label();
            this.dgvDailySalesDetail = new System.Windows.Forms.DataGridView();

            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlTopProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.pnlLowStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).BeginInit();
            this.pnlDailySalesDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailySalesDetail)).BeginInit();
            this.SuspendLayout();

            System.Drawing.Font mainFont = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular);
            System.Drawing.Font titleFont = new System.Drawing.Font("Open Sans", 16F, System.Drawing.FontStyle.Bold);
            System.Drawing.Font btnFont = new System.Drawing.Font("Open Sans", 14F, System.Drawing.FontStyle.Bold);
            System.Drawing.Font bigFont = new System.Drawing.Font("Open Sans", 24F, System.Drawing.FontStyle.Bold);

            // pnlHeader
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 80;
            this.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Controls.Add(this.lblReportStartDate);
            this.pnlHeader.Controls.Add(this.dtpReportStartDate);
            this.pnlHeader.Controls.Add(this.lblReportEndDate);
            this.pnlHeader.Controls.Add(this.dtpReportEndDate);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            
            this.btnBack.Text = "⬅ MENÜYE DÖN"; this.btnBack.Location = new System.Drawing.Point(20, 15); this.btnBack.Size = new System.Drawing.Size(180, 50); this.btnBack.Font = mainFont; this.btnBack.BackColor = System.Drawing.Color.IndianRed; this.btnBack.ForeColor = System.Drawing.Color.White; this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnBack.Visible = false;

            this.lblReportStartDate.Text = "Başlangıç:"; this.lblReportStartDate.Location = new System.Drawing.Point(220, 30); this.lblReportStartDate.Size = new System.Drawing.Size(90, 30); this.lblReportStartDate.Font = mainFont;
            this.dtpReportStartDate.Location = new System.Drawing.Point(315, 27); this.dtpReportStartDate.Size = new System.Drawing.Size(130, 30); this.dtpReportStartDate.Font = mainFont; this.dtpReportStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.lblReportEndDate.Text = "Bitiş:"; this.lblReportEndDate.Location = new System.Drawing.Point(460, 30); this.lblReportEndDate.Size = new System.Drawing.Size(50, 30); this.lblReportEndDate.Font = mainFont;
            this.dtpReportEndDate.Location = new System.Drawing.Point(515, 27); this.dtpReportEndDate.Size = new System.Drawing.Size(130, 30); this.dtpReportEndDate.Font = mainFont; this.dtpReportEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            this.btnRefresh.Text = "🔄 YENİLE"; this.btnRefresh.Location = new System.Drawing.Point(660, 20); this.btnRefresh.Size = new System.Drawing.Size(150, 45); this.btnRefresh.BackColor = System.Drawing.Color.SteelBlue; this.btnRefresh.ForeColor = System.Drawing.Color.White; this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnRefresh.Font = mainFont;

            // pnlContent
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.pnlMenu);
            this.pnlContent.Controls.Add(this.pnlSummary);
            this.pnlContent.Controls.Add(this.pnlTopProducts);
            this.pnlContent.Controls.Add(this.pnlLowStock);
            this.pnlContent.Controls.Add(this.pnlDailySalesDetail);

            // pnlMenu
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Padding = new System.Windows.Forms.Padding(50);
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.btnMenuSummary);
            this.pnlMenu.Controls.Add(this.btnMenuTop);
            this.pnlMenu.Controls.Add(this.btnMenuLow);
            this.pnlMenu.Controls.Add(this.btnMenuDetail);
            
            System.Drawing.Size menuBtnSize = new System.Drawing.Size(350, 150);
            System.Windows.Forms.Padding menuBtnMargin = new System.Windows.Forms.Padding(20);

            this.btnMenuSummary.Text = "📊 Mali Özet (Ciro ve Kâr)"; this.btnMenuSummary.Size = menuBtnSize; this.btnMenuSummary.Margin = menuBtnMargin; this.btnMenuSummary.Font = btnFont; this.btnMenuSummary.BackColor = System.Drawing.Color.SeaGreen; this.btnMenuSummary.ForeColor = System.Drawing.Color.White; this.btnMenuSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuTop.Text = "🏆 En Çok Satan Ürünler"; this.btnMenuTop.Size = menuBtnSize; this.btnMenuTop.Margin = menuBtnMargin; this.btnMenuTop.Font = btnFont; this.btnMenuTop.BackColor = System.Drawing.Color.DarkGoldenrod; this.btnMenuTop.ForeColor = System.Drawing.Color.White; this.btnMenuTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuLow.Text = "⚠️ Kritik Stok Uyarıları"; this.btnMenuLow.Size = menuBtnSize; this.btnMenuLow.Margin = menuBtnMargin; this.btnMenuLow.Font = btnFont; this.btnMenuLow.BackColor = System.Drawing.Color.Crimson; this.btnMenuLow.ForeColor = System.Drawing.Color.White; this.btnMenuLow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuDetail.Text = "📋 Günlük Satış Detayları"; this.btnMenuDetail.Size = menuBtnSize; this.btnMenuDetail.Margin = menuBtnMargin; this.btnMenuDetail.Font = btnFont; this.btnMenuDetail.BackColor = System.Drawing.Color.SlateGray; this.btnMenuDetail.ForeColor = System.Drawing.Color.White; this.btnMenuDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            // pnlSummary
            this.pnlSummary.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlSummary.Visible = false; this.pnlSummary.Padding = new System.Windows.Forms.Padding(50);
            this.lblDailyTitle.Text = "GÜNLÜK SATIŞ MASAÜSTÜ"; this.lblDailyTitle.Location = new System.Drawing.Point(50, 30); this.lblDailyTitle.Size = new System.Drawing.Size(500, 40); this.lblDailyTitle.Font = titleFont;
            this.lblDailySales.Text = "Toplam Ciro: 0,00 ₺"; this.lblDailySales.Location = new System.Drawing.Point(50, 100); this.lblDailySales.Size = new System.Drawing.Size(600, 50); this.lblDailySales.Font = bigFont; this.lblDailySales.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblDailyVat.Text = "KDV Toplamı: 0,00 ₺"; this.lblDailyVat.Location = new System.Drawing.Point(50, 180); this.lblDailyVat.Size = new System.Drawing.Size(400, 35); this.lblDailyVat.Font = mainFont;
            this.lblDailyCount.Text = "Satış Adedi: 0"; this.lblDailyCount.Location = new System.Drawing.Point(50, 230); this.lblDailyCount.Size = new System.Drawing.Size(400, 35); this.lblDailyCount.Font = mainFont;
            this.lblDailyProfit.Text = "Brüt Kâr: 0,00 ₺"; this.lblDailyProfit.Location = new System.Drawing.Point(50, 300); this.lblDailyProfit.Size = new System.Drawing.Size(600, 50); this.lblDailyProfit.Font = bigFont; this.lblDailyProfit.ForeColor = System.Drawing.Color.SteelBlue;
            this.pnlSummary.Controls.Add(this.lblDailyTitle); this.pnlSummary.Controls.Add(this.lblDailySales); this.pnlSummary.Controls.Add(this.lblDailyVat); this.pnlSummary.Controls.Add(this.lblDailyCount); this.pnlSummary.Controls.Add(this.lblDailyProfit);

            // pnlTopProducts
            this.pnlTopProducts.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlTopProducts.Visible = false; this.pnlTopProducts.Padding = new System.Windows.Forms.Padding(20);
            this.lblTopTitle.Text = "  EN ÇOK SATAN 10 ÜRÜN"; this.lblTopTitle.Dock = System.Windows.Forms.DockStyle.Top; this.lblTopTitle.Height = 40; this.lblTopTitle.Font = titleFont; this.lblTopTitle.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dgvTopProducts.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvTopProducts.AllowUserToAddRows = false; this.dgvTopProducts.ReadOnly = true; this.dgvTopProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvTopProducts.BackgroundColor = System.Drawing.Color.White; this.dgvTopProducts.Font = mainFont; this.dgvTopProducts.RowTemplate.Height = 40; this.dgvTopProducts.ColumnHeadersHeight = 40;
            this.pnlTopProducts.Controls.Add(this.dgvTopProducts); this.pnlTopProducts.Controls.Add(this.lblTopTitle);

            // pnlLowStock
            this.pnlLowStock.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlLowStock.Visible = false; this.pnlLowStock.Padding = new System.Windows.Forms.Padding(20);
            this.lblLowStockTitle.Text = "  KRİTİK STOK UYARISI (< 3 adet)"; this.lblLowStockTitle.Dock = System.Windows.Forms.DockStyle.Top; this.lblLowStockTitle.Height = 40; this.lblLowStockTitle.Font = titleFont; this.lblLowStockTitle.BackColor = System.Drawing.Color.MistyRose;
            this.dgvLowStock.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvLowStock.AllowUserToAddRows = false; this.dgvLowStock.ReadOnly = true; this.dgvLowStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvLowStock.BackgroundColor = System.Drawing.Color.White; this.dgvLowStock.Font = mainFont; this.dgvLowStock.RowTemplate.Height = 40; this.dgvLowStock.ColumnHeadersHeight = 40;
            this.pnlLowStock.Controls.Add(this.dgvLowStock); this.pnlLowStock.Controls.Add(this.lblLowStockTitle);

            // pnlDailySalesDetail
            this.pnlDailySalesDetail.Dock = System.Windows.Forms.DockStyle.Fill; this.pnlDailySalesDetail.Visible = false; this.pnlDailySalesDetail.Padding = new System.Windows.Forms.Padding(20);
            this.lblDailySalesDetailTitle.Text = "  GÜNLÜK SATIŞ DETAYLARI"; this.lblDailySalesDetailTitle.Dock = System.Windows.Forms.DockStyle.Top; this.lblDailySalesDetailTitle.Height = 40; this.lblDailySalesDetailTitle.Font = titleFont; this.lblDailySalesDetailTitle.BackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvDailySalesDetail.Dock = System.Windows.Forms.DockStyle.Fill; this.dgvDailySalesDetail.AllowUserToAddRows = false; this.dgvDailySalesDetail.ReadOnly = true; this.dgvDailySalesDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; this.dgvDailySalesDetail.BackgroundColor = System.Drawing.Color.White; this.dgvDailySalesDetail.Font = mainFont; this.dgvDailySalesDetail.RowTemplate.Height = 40; this.dgvDailySalesDetail.ColumnHeadersHeight = 40;
            this.pnlDailySalesDetail.Controls.Add(this.dgvDailySalesDetail); this.pnlDailySalesDetail.Controls.Add(this.lblDailySalesDetailTitle);

            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlHeader);
            this.Size = new System.Drawing.Size(1200, 800);

            this.pnlHeader.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlTopProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.pnlLowStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLowStock)).EndInit();
            this.pnlDailySalesDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDailySalesDetail)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        // Added controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.FlowLayoutPanel pnlMenu;
        private System.Windows.Forms.Button btnMenuSummary;
        private System.Windows.Forms.Button btnMenuTop;
        private System.Windows.Forms.Button btnMenuLow;
        private System.Windows.Forms.Button btnMenuDetail;

        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblDailyTitle;
        private System.Windows.Forms.Label lblDailySales;
        private System.Windows.Forms.Label lblDailyVat;
        private System.Windows.Forms.Label lblDailyCount;
        private System.Windows.Forms.Label lblDailyProfit;
        private System.Windows.Forms.DateTimePicker dtpReportStartDate;
        private System.Windows.Forms.Label lblReportStartDate;
        private System.Windows.Forms.DateTimePicker dtpReportEndDate;
        private System.Windows.Forms.Label lblReportEndDate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlTopProducts;
        private System.Windows.Forms.Label lblTopTitle;
        private System.Windows.Forms.DataGridView dgvTopProducts;
        private System.Windows.Forms.Panel pnlLowStock;
        private System.Windows.Forms.Label lblLowStockTitle;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.Panel pnlDailySalesDetail;
        private System.Windows.Forms.Label lblDailySalesDetailTitle;
        private System.Windows.Forms.DataGridView dgvDailySalesDetail;
    }
}
