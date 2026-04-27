using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ÜrünTakip.Data;
using ÜrünTakip.Models;

namespace ÜrünTakip.Views
{
    public class KisayolAyarlariForm : Form
    {
        private ComboBox cmbCategory;
        private TableLayoutPanel tlpGrid;
        
        public KisayolAyarlariForm()
        {
            InitializeComponent();
            LoadGrid();
        }

        private void InitializeComponent()
        {
            this.Text = "Kısayol Menüsü Ayarları";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;

            // Top Panel
            Panel pnlTop = new Panel { Dock = DockStyle.Top, Height = 80, Padding = new Padding(20) };
            
            Label lblCat = new Label { Text = "Ayar Yapılacak Kategori:", AutoSize = true, Location = new Point(20, 25), Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
            
            cmbCategory = new ComboBox { Location = new Point(230, 20), Width = 300, Font = new Font("Segoe UI", 14F), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCategory.Items.AddRange(new object[] { "GENEL", "TEKEL", "MANAV" });
            cmbCategory.SelectedIndex = 0;
            cmbCategory.SelectedIndexChanged += (s, e) => LoadGrid();

            Label lblInfo = new Label { Text = "ℹ️ Kutulara tıklayarak ürün atayabilir veya mevcut atamayı değiştirebilirsiniz.", AutoSize = true, Location = new Point(20, 60), Font = new Font("Segoe UI", 10F, FontStyle.Italic), ForeColor = Color.Gray };

            Button btnClose = new Button { Text = "KAPAT", Location = new Point(850, 15), Size = new Size(100, 45), BackColor = Color.LightCoral, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Font = new Font("Segoe UI", 12F, FontStyle.Bold) };
            btnClose.Click += (s, e) => this.Close();

            pnlTop.Controls.Add(lblCat);
            pnlTop.Controls.Add(cmbCategory);
            pnlTop.Controls.Add(lblInfo);
            pnlTop.Controls.Add(btnClose);

            // Grid Panel
            tlpGrid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 5,
                Padding = new Padding(20)
            };
            for (int i = 0; i < 4; i++) tlpGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            for (int i = 0; i < 5; i++) tlpGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

            this.Controls.Add(tlpGrid);
            this.Controls.Add(pnlTop);
        }

        private void LoadGrid()
        {
            tlpGrid.Controls.Clear();
            string selectedCategory = cmbCategory.SelectedItem.ToString();

            using (var db = new AppDbContext())
            {
                var products = db.Products
                                 .Where(p => p.PosCategory == selectedCategory && p.PosPosition != null)
                                 .ToList();

                Product[] gridProducts = new Product[20];
                foreach (var p in products)
                {
                    if (p.PosPosition >= 1 && p.PosPosition <= 20)
                    {
                        if (gridProducts[p.PosPosition.Value - 1] == null)
                            gridProducts[p.PosPosition.Value - 1] = p;
                    }
                }

                for (int i = 0; i < 20; i++)
                {
                    var prod = gridProducts[i];
                    Button btn = new Button();
                    btn.Dock = DockStyle.Fill;
                    btn.Margin = new Padding(5);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.Tag = i + 1; // 1-20 position

                    if (prod != null)
                    {
                        btn.Text = prod.Name + "\n" + prod.SalePrice.ToString("N2") + " ₺";
                        btn.BackColor = Color.LightSkyBlue;
                    }
                    else
                    {
                        btn.Text = "+ Ekle (" + (i + 1) + ")";
                        btn.BackColor = Color.WhiteSmoke;
                        btn.ForeColor = Color.Gray;
                    }

                    btn.Click += GridBtn_Click;
                    tlpGrid.Controls.Add(btn);
                }
            }
        }

        private void GridBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int position = (int)btn.Tag;
            string selectedCategory = cmbCategory.SelectedItem.ToString();

            UrunSecimForm secimForm = new UrunSecimForm();
            if (secimForm.ShowDialog() == DialogResult.OK)
            {
                using (var db = new AppDbContext())
                {
                    // If a product is already at this position in this category, clear it first
                    var existingProd = db.Products.FirstOrDefault(p => p.PosCategory == selectedCategory && p.PosPosition == position);
                    if (existingProd != null)
                    {
                        existingProd.PosCategory = null;
                        existingProd.PosPosition = null;
                    }

                    if (secimForm.IsRemoved)
                    {
                        db.SaveChanges();
                        LoadGrid();
                        return;
                    }

                    int newProductId = secimForm.SelectedProductId;
                    var newProd = db.Products.Find(newProductId);
                    if (newProd != null)
                    {
                        newProd.PosCategory = selectedCategory;
                        newProd.PosPosition = position;
                        db.SaveChanges();
                    }
                }
                LoadGrid();
            }
        }
    }
}
