using System.Drawing;
using System.Windows.Forms;

namespace ÜrünTakip
{
    /// <summary>
    /// Kurumsal tema renkleri ve yardımcı metodlar.
    /// Tüm uygulama genelinde tutarlı görünüm sağlar.
    /// </summary>
    internal static class ThemeManager
    {
        // ── Sidebar ──
        public static readonly Color SidebarBg = Color.FromArgb(22, 27, 34);
        public static readonly Color SidebarBtnActive = Color.FromArgb(37, 99, 235);
        public static readonly Color SidebarText = Color.FromArgb(139, 148, 158);
        public static readonly Color SidebarActiveText = Color.White;
        public static readonly Color SidebarCloseText = Color.FromArgb(248, 113, 113);

        // ── Header ──
        public static readonly Color HeaderBg = Color.FromArgb(249, 250, 251);
        public static readonly Color HeaderText = Color.FromArgb(15, 23, 42);

        // ── Content ──
        public static readonly Color ContentBg = Color.FromArgb(241, 245, 249);
        public static readonly Color CardBg = Color.White;
        public static readonly Color SurfaceBg = Color.FromArgb(248, 250, 252);

        // ── Aksiyon Renkleri ──
        public static readonly Color Primary = Color.FromArgb(37, 99, 235);
        public static readonly Color PrimaryDark = Color.FromArgb(29, 78, 216);
        public static readonly Color Success = Color.FromArgb(22, 163, 74);
        public static readonly Color SuccessDark = Color.FromArgb(21, 128, 61);
        public static readonly Color Danger = Color.FromArgb(220, 38, 38);
        public static readonly Color DangerDark = Color.FromArgb(185, 28, 28);
        public static readonly Color Warning = Color.FromArgb(234, 88, 12);
        public static readonly Color WarningDark = Color.FromArgb(194, 65, 12);
        public static readonly Color Info = Color.FromArgb(14, 165, 233);
        public static readonly Color Neutral = Color.FromArgb(100, 116, 139);
        public static readonly Color NeutralLight = Color.FromArgb(148, 163, 184);
        public static readonly Color Purple = Color.FromArgb(124, 58, 237);
        public static readonly Color Teal = Color.FromArgb(20, 184, 166);
        public static readonly Color Amber = Color.FromArgb(161, 98, 7);

        // ── Metin ──
        public static readonly Color TextPrimary = Color.FromArgb(15, 23, 42);
        public static readonly Color TextSecondary = Color.FromArgb(71, 85, 105);
        public static readonly Color TextMuted = Color.FromArgb(148, 163, 184);

        // ── Toplam Gösterge ──
        public static readonly Color TotalGreen = Color.FromArgb(5, 150, 105);

        // ── Banknot Renkleri ──
        public static readonly Color Banknote5 = Color.FromArgb(202, 138, 4);
        public static readonly Color Banknote10 = Color.FromArgb(219, 39, 119);
        public static readonly Color Banknote20 = Color.FromArgb(22, 163, 74);
        public static readonly Color Banknote50 = Color.FromArgb(234, 88, 12);
        public static readonly Color Banknote100 = Color.FromArgb(37, 99, 235);
        public static readonly Color Banknote200 = Color.FromArgb(147, 51, 234);

        // ── Footer / Alt Bar ──
        public static readonly Color FooterBg = Color.FromArgb(30, 41, 59);

        // ── DataGridView ──
        public static readonly Color GridHeaderBg = Color.FromArgb(241, 245, 249);
        public static readonly Color GridHeaderText = Color.FromArgb(51, 65, 85);
        public static readonly Color GridAlternateRow = Color.FromArgb(248, 250, 252);
        public static readonly Color GridSelectionBg = Color.FromArgb(219, 234, 254);
        public static readonly Color GridSelectionText = Color.FromArgb(15, 23, 42);
        public static readonly Color GridBorder = Color.FromArgb(226, 232, 240);

        // ── Dokunmatik Grid ──
        public static readonly Color TouchBtnBg = Color.FromArgb(248, 250, 252);
        public static readonly Color TouchBtnBorder = Color.FromArgb(203, 213, 225);
        public static readonly Color TouchCatActive = Color.FromArgb(37, 99, 235);
        public static readonly Color TouchCatInactive = Color.FromArgb(226, 232, 240);

        // ── Rapor Kartları ──
        public static readonly Color ReportGreen = Color.FromArgb(22, 163, 74);
        public static readonly Color ReportGold = Color.FromArgb(161, 98, 7);
        public static readonly Color ReportSlate = Color.FromArgb(51, 65, 85);

        // ── Kenarlık ──
        public static readonly Color Border = Color.FromArgb(226, 232, 240);
        public static readonly Color BorderLight = Color.FromArgb(241, 245, 249);

        // ── KDV Hesap Kutusu ──
        public static readonly Color KdvCalcBg = Color.FromArgb(254, 249, 195);

        /// <summary>
        /// DataGridView'e kurumsal tema uygular.
        /// </summary>
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = CardBg;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = GridBorder;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = GridHeaderBg;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = GridHeaderText;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = GridHeaderBg;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = GridHeaderText;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 4, 8, 4);

            dgv.DefaultCellStyle.BackColor = CardBg;
            dgv.DefaultCellStyle.ForeColor = TextPrimary;
            dgv.DefaultCellStyle.SelectionBackColor = GridSelectionBg;
            dgv.DefaultCellStyle.SelectionForeColor = GridSelectionText;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgv.DefaultCellStyle.Padding = new Padding(6, 2, 6, 2);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = GridAlternateRow;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = GridSelectionBg;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = GridSelectionText;
        }

        /// <summary>
        /// Butona kurumsal tema rengi uygular.
        /// </summary>
        public static void StyleButton(Button btn, Color bgColor)
        {
            btn.BackColor = bgColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
        }
    }
}
