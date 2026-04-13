using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ÜrünTakip.Data;
using ÜrünTakip.Models;
using Microsoft.EntityFrameworkCore;

namespace ÜrünTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var cat = new Category { Name = "Örnek Kategori " + DateTime.Now.Millisecond };
                    context.Categories.Add(cat);
                    context.SaveChanges();
                    MessageBox.Show("Kategori başarıyla eklendi: " + cat.Name, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori eklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var cat = context.Categories.FirstOrDefault();
                    if (cat == null)
                    {
                        MessageBox.Show("Lütfen önce bir kategori ekleyin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var prod = new Product
                    {
                        Name = "Örnek Ürün " + DateTime.Now.Millisecond,
                        Barcode = Guid.NewGuid().ToString().Substring(0, 8),
                        PurchasePrice = 100,
                        SalePrice = 150,
                        VatRate = 18,
                        CurrentStock = 10,
                        Attributes = "{\"renk\": \"rastgele\", \"boyut\": \"bilinmiyor\"}",
                        CategoryId = cat.Id,
                        IsActive = true
                    };
                    
                    context.Products.Add(prod);
                    context.SaveChanges();
                    MessageBox.Show("Ürün başarıyla eklendi: " + prod.Name, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürün eklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListCategories_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    dataGridView1.DataSource = context.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategoriler listelenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListProducts_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var data = context.Products
                        .Include(p => p.Category)
                        .Select(p => new {
                            p.Id,
                            p.Barcode,
                            p.Name,
                            Kategori = p.Category.Name,
                            AlisFiyati = p.PurchasePrice,
                            SatisFiyati = p.SalePrice,
                            Stok = p.CurrentStock,
                            Ozellikler = p.Attributes,
                            Aktif = p.IsActive
                        }).ToList();
                    
                    dataGridView1.DataSource = data;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ürünler listelenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
