using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ÜrünTakip.Data;
using ÜrünTakip.Models;

namespace ÜrünTakip.Views
{
    public class UrunSecimForm : Form
    {
        public int SelectedProductId { get; private set; } = 0;
        public bool IsRemoved { get; private set; } = false;

        private TextBox txtSearch;
        private DataGridView dgvProducts;
        private Button btnRemove;

        public UrunSecimForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "Ürün Seçimi";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            Panel pnlTop = new Panel { Dock = DockStyle.Top, Height = 60, Padding = new Padding(10) };
            
            Label lblSearch = new Label { Text = "Ürün Ara:", AutoSize = true, Location = new Point(10, 20), Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
            txtSearch = new TextBox { Location = new Point(100, 15), Width = 400, Font = new Font("Segoe UI", 14F) };
            txtSearch.TextChanged += TxtSearch_TextChanged;
            
            btnRemove = new Button { Text = "❌ KISAYOLU KALDIR", Location = new Point(550, 10), Size = new Size(200, 40), BackColor = Color.Crimson, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
            btnRemove.Click += BtnRemove_Click;

            pnlTop.Controls.Add(lblSearch);
            pnlTop.Controls.Add(txtSearch);
            pnlTop.Controls.Add(btnRemove);

            dgvProducts = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                RowTemplate = { Height = 40 },
                Font = new Font("Segoe UI", 12F),
                BackgroundColor = Color.WhiteSmoke
            };
            dgvProducts.CellDoubleClick += DgvProducts_CellDoubleClick;

            this.Controls.Add(dgvProducts);
            this.Controls.Add(pnlTop);
            
            this.Shown += (s, e) => txtSearch.Focus();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            IsRemoved = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadData(string search = "")
        {
            using (var db = new AppDbContext())
            {
                var query = db.Products.Where(p => p.IsActive);
                if (!string.IsNullOrWhiteSpace(search))
                {
                    var lowerSearch = search.ToLower();
                    query = query.Where(p => p.Name.ToLower().Contains(lowerSearch) || p.Barcode.Contains(search));
                }

                var list = query.Select(p => new {
                    p.Id,
                    Barkod = p.Barcode,
                    UrunAdi = p.Name,
                    SatisFiyati = p.SalePrice
                }).Take(100).ToList();

                dgvProducts.DataSource = list;
                if (dgvProducts.Columns.Contains("Id")) dgvProducts.Columns["Id"].Visible = false;
                if (dgvProducts.Columns.Contains("UrunAdi")) dgvProducts.Columns["UrunAdi"].HeaderText = "ÜRÜN ADI";
                if (dgvProducts.Columns.Contains("SatisFiyati")) dgvProducts.Columns["SatisFiyati"].HeaderText = "SATIŞ FİYATI";
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text);
        }

        private void DgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedProductId = (int)dgvProducts.Rows[e.RowIndex].Cells["Id"].Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
