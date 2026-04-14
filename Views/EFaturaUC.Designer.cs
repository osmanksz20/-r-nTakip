namespace ÜrünTakip.Views
{
    partial class EFaturaUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }

        #region Bileşen Tasarımcısı Üretimi Kod
        private void InitializeComponent()
        {
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrintReceipt = new System.Windows.Forms.Button();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.lblDetailTitle = new System.Windows.Forms.Label();

            this.tlpMain.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.SuspendLayout();

            System.Drawing.Font mf = new System.Drawing.Font("Open Sans", 10F);

            // tlpMain
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.Controls.Add(this.pnlFilter, 0, 0);
            this.tlpMain.Controls.Add(this.dgvSales, 0, 1);
            this.tlpMain.Controls.Add(this.lblDetailTitle, 0, 2);
            this.tlpMain.Controls.Add(this.dgvDetail, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;

            // pnlFilter
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.lblStart.Text = "Başlangıç:"; this.lblStart.Location = new System.Drawing.Point(10, 18); this.lblStart.Size = new System.Drawing.Size(70, 25); this.lblStart.Font = mf;
            this.dtpStart.Location = new System.Drawing.Point(85, 15); this.dtpStart.Size = new System.Drawing.Size(150, 28); this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.lblEnd.Text = "Bitiş:"; this.lblEnd.Location = new System.Drawing.Point(250, 18); this.lblEnd.Size = new System.Drawing.Size(40, 25); this.lblEnd.Font = mf;
            this.dtpEnd.Location = new System.Drawing.Point(295, 15); this.dtpEnd.Size = new System.Drawing.Size(150, 28); this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.btnSearch.Text = "ARA"; this.btnSearch.Location = new System.Drawing.Point(460, 12); this.btnSearch.Size = new System.Drawing.Size(90, 35); this.btnSearch.BackColor = System.Drawing.Color.SteelBlue; this.btnSearch.ForeColor = System.Drawing.Color.White; this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnSearch.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrintReceipt.Text = "FİŞ GÖRÜNTÜLE"; this.btnPrintReceipt.Location = new System.Drawing.Point(560, 12); this.btnPrintReceipt.Size = new System.Drawing.Size(140, 35); this.btnPrintReceipt.BackColor = System.Drawing.Color.MediumSeaGreen; this.btnPrintReceipt.ForeColor = System.Drawing.Color.White; this.btnPrintReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnPrintReceipt.Font = new System.Drawing.Font("Open Sans", 10F, System.Drawing.FontStyle.Bold);
            this.pnlFilter.Controls.Add(this.lblStart); this.pnlFilter.Controls.Add(this.dtpStart);
            this.pnlFilter.Controls.Add(this.lblEnd); this.pnlFilter.Controls.Add(this.dtpEnd);
            this.pnlFilter.Controls.Add(this.btnSearch); this.pnlFilter.Controls.Add(this.btnPrintReceipt);

            // dgvSales
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSales.AllowUserToAddRows = false; this.dgvSales.ReadOnly = true;
            this.dgvSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSales.BackgroundColor = System.Drawing.Color.White;

            // lblDetailTitle
            this.lblDetailTitle.Text = "  Seçili Satışın Detayları";
            this.lblDetailTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDetailTitle.Font = new System.Drawing.Font("Open Sans", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetailTitle.BackColor = System.Drawing.Color.LightGray;
            this.lblDetailTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // dgvDetail
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.AllowUserToAddRows = false; this.dgvDetail.ReadOnly = true;
            this.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;

            this.Controls.Add(this.tlpMain);
            this.Size = new System.Drawing.Size(1000, 600);

            this.tlpMain.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false); this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrintReceipt;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.Label lblDetailTitle;
    }
}
