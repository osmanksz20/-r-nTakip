using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ÜrünTakip.Data;
using ÜrünTakip.Models;

namespace ÜrünTakip.Views
{
    public partial class StokIslemleriUC : UserControl
    {
        private int _selectedProductId = 0;

        public StokIslemleriUC()
        {
            InitializeComponent();
            
            // Event Wiring
            this.Load += StokIslemleriUC_Load;
            
            // KDV Calculation bindings
            numPurchasePrice.ValueChanged += CalculateKDV;
            numSalePrice.ValueChanged += CalculateKDV;
            numVatRate.ValueChanged += CalculateKDV;
            
            btnGenBarcode.Click += BtnGenBarcode_Click;
            btnAddCategory.Click += BtnAddCategory_Click;
            
            btnSave.Click += BtnSave_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += BtnClear_Click;
            
            dgvProducts.CellClick += DgvProducts_CellClick;
            txtSearch.TextChanged += (s, e) => LoadProducts(txtSearch.Text);
            cmbFilterCategory.SelectedIndexChanged += (s, e) => {
                if (cmbFilterCategory.DataSource != null) LoadProducts(txtSearch.Text);
            };
        }

        private void StokIslemleriUC_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProducts();
            CalculateKDV(null, null);
        }

        private void LoadCategories()
        {
            using (var db = new AppDbContext())
            {
                var cats = db.Categories.ToList();
                cmbCategories.DataSource = cats;
                cmbCategories.DisplayMember = "Name";
                cmbCategories.ValueMember = "Id";

                var filterCats = cats.ToList();
                filterCats.Insert(0, new Category { Id = 0, Name = "Tümü" });
                cmbFilterCategory.DataSource = filterCats;
                cmbFilterCategory.DisplayMember = "Name";
                cmbFilterCategory.ValueMember = "Id";
            }
        }

        private void LoadProducts(string searchTerm = "")
        {
            using (var db = new AppDbContext())
            {
                var allProds = db.Products.Include(p => p.Category).ToList();
                var prods = allProds;

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    prods = prods.Where(p => 
                        (p.Name != null && p.Name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0) || 
                        (p.Barcode != null && p.Barcode.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    ).ToList();
                }

                if (cmbFilterCategory.SelectedValue != null && cmbFilterCategory.SelectedValue is int catId && catId > 0)
                {
                    prods = prods.Where(p => p.CategoryId == catId).ToList();
                }
                var dataSource = prods.Select(p => new
                {
                    p.Id,
                    p.Barcode,
                    Name = p.Name,
                    Kategori = p.Category != null ? p.Category.Name : "Yok",
                    p.CurrentStock,
                    p.SalePrice
                }).ToList();
                
                dgvProducts.DataSource = dataSource;
            }
        }

        private void CalculateKDV(object sender, EventArgs e)
        {
            // Eğer net satış fiyatını numSalePrice üzerinden varsayarsak,
            // KDV Tutarı = Net Fiyat * (KDV Oranı / 100)
            // KDV Dahil = Net Fiyat + KDV Tutarı
            
            decimal netPrice = numSalePrice.Value;
            decimal vatRate = numVatRate.Value;
            
            decimal vatAmount = netPrice * (vatRate / 100m);
            decimal totalIncVat = netPrice + vatAmount;
            
            lblKdvCalc.Text = $"KDV Tutarı: {vatAmount:C2} | KDV Dahil Satış: {totalIncVat:C2}";
        }

        private void BtnGenBarcode_Click(object sender, EventArgs e)
        {
            var r = new Random();
            txtBarcode.Text = "86" + r.Next(100000000, 999999999).ToString();
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            // Özel basit bir Input Form oluşturuyoruz
            Form inputForm = new Form()
            {
                Width = 400, Height = 150, FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Kategori Ekle", StartPosition = FormStartPosition.CenterParent
            };
            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Yeni Kategori Adı:" };
            TextBox textBox = new TextBox() { Left = 130, Top = 18, Width = 230 };
            Button confirmation = new Button() { Text = "Ekle", Left = 260, Width = 100, Top = 60, DialogResult = DialogResult.OK };
            inputForm.Controls.Add(textLabel); inputForm.Controls.Add(textBox); inputForm.Controls.Add(confirmation);
            inputForm.AcceptButton = confirmation;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                string newCatName = textBox.Text.Trim();
                if (!string.IsNullOrWhiteSpace(newCatName))
                {
                    try
                    {
                        using (var db = new AppDbContext())
                        {
                            var cat = new Category { Name = newCatName };
                            db.Categories.Add(cat);
                            db.SaveChanges();
                        }
                        LoadCategories();
                        MessageBox.Show("Kategori Eklendi!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbCategories.SelectedValue == null) { MessageBox.Show("Lütfen kategori seçin!"); return; }
            if (string.IsNullOrWhiteSpace(txtProductName.Text) || string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                MessageBox.Show("Ürün adı ve barkod zorunludur!"); return;
            }
            
            try
            {
                using (var db = new AppDbContext())
                {
                    var p = new Product
                    {
                        Barcode = txtBarcode.Text,
                        Name = txtProductName.Text,
                        CategoryId = (int)cmbCategories.SelectedValue,
                        EntryDate = dtpEntryDate.Value, // Artık doğrudan yerel saat kaydediliyor
                        PurchasePrice = numPurchasePrice.Value,
                        SalePrice = numSalePrice.Value,
                        VatRate = (int)numVatRate.Value,
                        CurrentStock = numStock.Value,
                        IsActive = chkIsActive.Checked,
                        Attributes = "{}" // empty JSON
                    };
                    db.Products.Add(p);
                    db.SaveChanges();
                }
                MessageBox.Show("Ürün Kaydedildi!");
                LoadProducts();
                BtnClear_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kaydetme hatası: (Barkod benzersiz olmalıdır!) \n" + ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == 0) { MessageBox.Show("Önce listeden güncellenecek ürünü seçin!"); return; }
            
            try
            {
                using (var db = new AppDbContext())
                {
                    var p = db.Products.Find(_selectedProductId);
                    if (p != null)
                    {
                        p.Barcode = txtBarcode.Text;
                        p.Name = txtProductName.Text;
                        p.CategoryId = (int)cmbCategories.SelectedValue;
                        p.EntryDate = dtpEntryDate.Value;
                        p.PurchasePrice = numPurchasePrice.Value;
                        p.SalePrice = numSalePrice.Value;
                        p.VatRate = (int)numVatRate.Value;
                        p.CurrentStock = numStock.Value;
                        p.IsActive = chkIsActive.Checked;
                        
                        db.SaveChanges();
                        MessageBox.Show("Ürün Güncellendi!");
                        LoadProducts();
                        BtnClear_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProductId == 0) return;
            var confirm = MessageBox.Show("Bu ürünü silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (var db = new AppDbContext())
                    {
                        var p = db.Products.Find(_selectedProductId);
                        if (p != null)
                        {
                            db.Products.Remove(p);
                            db.SaveChanges();
                        }
                    }
                    MessageBox.Show("Ürün Silindi!");
                    LoadProducts();
                    BtnClear_Click(null, null);
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                    if (ex.InnerException != null)
                    {
                        errorMsg += "\nDetay: " + ex.InnerException.Message;
                    }
                    MessageBox.Show("Beklenmeyen bir hata oluştu:\n" + errorMsg, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            _selectedProductId = 0;
            txtBarcode.Clear();
            txtProductName.Clear();
            dtpEntryDate.Value = DateTime.Now;
            numPurchasePrice.Value = 0;
            numSalePrice.Value = 0;
            numVatRate.Value = 18;
            numStock.Value = 0;
            chkIsActive.Checked = true;
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvProducts.Rows[e.RowIndex];
                // Sütun adıyla Id'yi bul (gizli sütunlarda index kayması olmaz)
                int pId = Convert.ToInt32(row.Cells["colId"].Value);
                _selectedProductId = pId;
                
                using (var db = new AppDbContext())
                {
                    var p = db.Products.Find(pId);
                    if (p != null)
                    {
                        txtBarcode.Text = p.Barcode;
                        txtProductName.Text = p.Name;
                        cmbCategories.SelectedValue = p.CategoryId;
                        try { dtpEntryDate.Value = p.EntryDate; } catch { dtpEntryDate.Value = DateTime.Now; }
                        numPurchasePrice.Value = p.PurchasePrice;
                        numSalePrice.Value = p.SalePrice;
                        numVatRate.Value = p.VatRate;
                        numStock.Value = p.CurrentStock;
                        chkIsActive.Checked = p.IsActive;
                    }
                }
            }
        }
    }
}
