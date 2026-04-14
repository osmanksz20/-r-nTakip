using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ÜrünTakip.Data;

namespace ÜrünTakip.Views
{
    public partial class RaporlarUC : UserControl
    {
        public RaporlarUC()
        {
            InitializeComponent();
            this.Load += (s, e) => { dtpReportDate.Value = DateTime.Today; RefreshReport(); };
            btnRefresh.Click += (s, e) => RefreshReport();
            dtpReportDate.ValueChanged += (s, e) => RefreshReport();
        }

        private void RefreshReport()
        {
            using (var db = new AppDbContext())
            {
                var startDate = dtpReportDate.Value.Date;
                var endDate = startDate.AddDays(1);

                // Günlük satış özeti
                var dailySales = db.Sales.Where(s => s.SaleDate >= startDate && s.SaleDate < endDate).ToList();
                decimal totalCiro = dailySales.Sum(s => s.TotalAmount);
                decimal totalVat = dailySales.Sum(s => s.VatTotal);
                int saleCount = dailySales.Count;

                lblDailySales.Text = $"Toplam Ciro: {totalCiro:C2}";
                lblDailyVat.Text = $"KDV Toplamı: {totalVat:C2}";
                lblDailyCount.Text = $"Satış Adedi: {saleCount}";

                // Brüt kâr hesabı (satış fiyatı - alış fiyatı farkı)
                var saleIds = dailySales.Select(s => s.Id).ToList();
                var saleItems = db.SaleItems.Where(si => saleIds.Contains(si.SaleId)).ToList();
                decimal totalProfit = 0;
                foreach (var si in saleItems)
                {
                    var product = db.Products.Find(si.ProductId);
                    if (product != null)
                    {
                        totalProfit += (si.UnitPrice - product.PurchasePrice) * si.Quantity;
                    }
                }
                lblDailyProfit.Text = $"Brüt Kâr: {totalProfit:C2}";

                // En çok satan 10 ürün (tüm zamanlar)
                var topProducts = db.SaleItems
                    .GroupBy(si => si.ProductName)
                    .Select(g => new { Ürün = g.Key, ToplamSatış = g.Sum(x => x.Quantity) })
                    .OrderByDescending(x => x.ToplamSatış)
                    .Take(10)
                    .ToList();
                dgvTopProducts.DataSource = topProducts;

                // Kritik stok (3 altı)
                var lowStock = db.Products
                    .Where(p => p.IsActive && p.CurrentStock < 3)
                    .Select(p => new { p.Name, Stok = p.CurrentStock, p.Barcode })
                    .OrderBy(p => p.Stok)
                    .ToList();
                dgvLowStock.DataSource = lowStock;

                // Günlük satış detayları tablosu
                var salesDetail = dailySales
                    .OrderByDescending(s => s.SaleDate)
                    .Select(s => new
                    {
                        Saat = s.SaleDate.ToLocalTime().ToString("HH:mm:ss"),
                        Kasiyer = s.CashierName ?? "-",
                        Ödeme = s.PaymentType ?? "-",
                        Ürünler = string.Join(", ", saleItems
                            .Where(si => si.SaleId == s.Id)
                            .Select(si => $"{si.ProductName} x{si.Quantity}")),
                        KDV = s.VatTotal.ToString("C2"),
                        Toplam = s.TotalAmount.ToString("C2")
                    })
                    .ToList();
                dgvDailySalesDetail.DataSource = salesDetail;
            }
        }
    }
}

