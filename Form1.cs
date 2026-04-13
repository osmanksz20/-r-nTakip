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

            // TABS (Sidebar) Geçiş Olayları
            btnKasa.Click += delegate { SayfaDegistir("Kasa"); };
            btnStok.Click += delegate { SayfaDegistir("Stok İşlemleri"); };
            btnVeresiyeDefteri.Click += delegate { SayfaDegistir("Veresiye Defteri"); };
            btnEFatura.Click += delegate { SayfaDegistir("e-Fatura Modülü"); };
            btnRaporlar.Click += delegate { SayfaDegistir("Genel Raporlar"); };
            btnAyarlar.Click += delegate { SayfaDegistir("Sistem Ayarları"); };
        }

        private void SayfaDegistir(string sayfaAdi)
        {
            if (sayfaAdi == "Kasa")
            {
                pnlDynamicContent.Visible = false;
                tlpMiddle.Visible = true;
                flpFooter.Visible = true;
                
                lblTotalTitle.Text = "KASA TOPLAM:";
                lblTotalValue.Text = "594,00 ₺";
                lblTotalValue.ForeColor = Color.ForestGreen;
            }
            else
            {
                tlpMiddle.Visible = false;
                flpFooter.Visible = false;
                pnlDynamicContent.Visible = true;
                
                lblDynamicContentTitle.Text = sayfaAdi.ToUpper() + "\n(Bu sayfa yapım aşamasında)";
                
                lblTotalTitle.Text = "BÖLÜM:";
                lblTotalValue.Text = sayfaAdi;
                lblTotalValue.ForeColor = Color.SteelBlue;
            }
        }
    }
}
