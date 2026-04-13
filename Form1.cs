using System;
using System.Drawing;
using System.Windows.Forms;
using ÜrünTakip.Data;
using ÜrünTakip.Models;

namespace ÜrünTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupCustomEvents();
        }

        private void SetupCustomEvents()
        {
            // Paneldeki 20 adet dokunmatik buton için tıklama olaylarını bağlıyoruz.
            // Butona tıklandığında alt kısımdaki "Seçili Ürün" çubuğunda ürün adı görünür.
            foreach (Control control in tlpTouchGrid.Controls)
            {
                if (control is Button button)
                {
                    button.Click += (s, e) =>
                    {
                        lblSelectedProduct.Text = $"  Seçili Ürün: {button.Text} | Stok: Mevcut";
                        
                        // İpucu: Burada DataGridView (dgvSales) içerisine ürün eklenebilir.
                        // Örnek satır ekleme (sadece görsel test için):
                        // dgvSales.Rows.Add(button.Text, "1", "0,00", "0,00", "%18");
                    };
                }
            }

            // Temel işlev butonları için örnek olaylar
            btnKapat.Click += (s, e) => Application.Exit();
            
            btnNakit.Click += (s, e) => MessageBox.Show("Nakit Tahsilat Ekranı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnKrediKarti.Click += (s, e) => MessageBox.Show("Kredi Kartı POS Tahsilat Ekranı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
