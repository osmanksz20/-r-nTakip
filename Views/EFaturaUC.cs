using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ÜrünTakip.Data;

namespace ÜrünTakip.Views
{
    public partial class EFaturaUC : UserControl
    {
        public EFaturaUC()
        {
            InitializeComponent();
            this.Load += (s, e) => { dtpStart.Value = DateTime.Today; dtpEnd.Value = DateTime.Today; SearchSales(); };
            btnSearch.Click += (s, e) => SearchSales();
            dgvSales.CellClick += DgvSales_CellClick;
            btnPrintReceipt.Click += BtnPrintReceipt_Click;
        }

        private void SearchSales()
        {
            using (var db = new AppDbContext())
            {
                var startUtc = dtpStart.Value.Date.ToUniversalTime();
                var endUtc = dtpEnd.Value.Date.AddDays(1).ToUniversalTime();
                var list = db.Sales
                    .Where(s => s.SaleDate >= startUtc && s.SaleDate < endUtc)
                    .OrderByDescending(s => s.SaleDate)
                    .Select(s => new
                    {
                        s.Id,
                        Tarih = s.SaleDate,
                        Tutar = s.TotalAmount,
                        KDV = s.VatTotal,
                        Ödeme = s.PaymentType,
                        Kasiyer = s.CashierName
                    }).ToList();
                dgvSales.DataSource = list;
            }
        }

        private void DgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int saleId = Convert.ToInt32(dgvSales.Rows[e.RowIndex].Cells[0].Value);
            using (var db = new AppDbContext())
            {
                var items = db.SaleItems.Where(si => si.SaleId == saleId)
                    .Select(si => new
                    {
                        Ürün = si.ProductName,
                        Miktar = si.Quantity,
                        BirimFiyat = si.UnitPrice,
                        KDV = si.VatRate,
                        Toplam = si.LineTotal
                    }).ToList();
                dgvDetail.DataSource = items;
            }
        }

        private void BtnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null) { MessageBox.Show("Önce bir satış seçin!"); return; }
            int saleId = Convert.ToInt32(dgvSales.CurrentRow.Cells[0].Value);
            using (var db = new AppDbContext())
            {
                var sale = db.Sales.Find(saleId);
                if (sale == null) return;
                var items = db.SaleItems.Where(si => si.SaleId == saleId).ToList();

                string receipt = "═══════════════════════════\n";
                receipt += "        SATIŞ FİŞİ\n";
                receipt += "═══════════════════════════\n";
                receipt += $"Fiş No: {sale.Id}\n";
                receipt += $"Tarih : {sale.SaleDate.ToLocalTime():dd.MM.yyyy HH:mm}\n";
                receipt += $"Kasiyer: {sale.CashierName}\n";
                receipt += "───────────────────────────\n";
                foreach (var item in items)
                {
                    receipt += $"{item.ProductName}\n";
                    receipt += $"  {item.Quantity} x {item.UnitPrice:N2} = {item.LineTotal:N2} ₺\n";
                }
                receipt += "───────────────────────────\n";
                receipt += $"KDV Toplam : {sale.VatTotal:N2} ₺\n";
                receipt += $"GENEL TOPLAM: {sale.TotalAmount:N2} ₺\n";
                receipt += $"Ödeme: {sale.PaymentType}\n";
                receipt += "═══════════════════════════\n";
                receipt += "   Bizi tercih ettiğiniz\n     için teşekkürler!\n";

                MessageBox.Show(receipt, "Satış Fişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
