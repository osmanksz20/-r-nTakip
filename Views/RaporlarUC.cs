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
            this.Load += (s, e) => { 
                var today = DateTime.Today;
                dtpReportStartDate.Value = new DateTime(today.Year, today.Month, 1);
                dtpReportEndDate.Value = today;
                RefreshReport(); 
            };
            btnRefresh.Click += (s, e) => RefreshReport();
            dtpReportStartDate.ValueChanged += (s, e) => {
                if (dtpReportStartDate.Value > dtpReportEndDate.Value)
                {
                    MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpReportStartDate.Value = dtpReportEndDate.Value;
                    return;
                }
                RefreshReport();
            };
            dtpReportEndDate.ValueChanged += (s, e) => {
                if (dtpReportStartDate.Value > dtpReportEndDate.Value)
                {
                    MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpReportEndDate.Value = dtpReportStartDate.Value;
                    return;
                }
                RefreshReport();
            };

            btnMenuSummary.Click += (s, e) => ShowPanel(pnlSummary);
            btnMenuTop.Click += (s, e) => ShowPanel(pnlTopProducts);
            btnMenuLow.Click += (s, e) => ShowPanel(pnlLowStock);
            btnMenuDetail.Click += (s, e) => ShowPanel(pnlDailySalesDetail);
            
            btnBack.Click += (s, e) => {
                pnlSummary.Visible = false;
                pnlTopProducts.Visible = false;
                pnlLowStock.Visible = false;
                pnlDailySalesDetail.Visible = false;
                pnlMenu.Visible = true;
                btnBack.Visible = false;
            };
        }

        private void ShowPanel(Panel pnl)
        {
            pnlMenu.Visible = false;
            pnlSummary.Visible = false;
            pnlTopProducts.Visible = false;
            pnlLowStock.Visible = false;
            pnlDailySalesDetail.Visible = false;
            
            pnl.Visible = true;
            btnBack.Visible = true;
        }

        private void RefreshReport()
        {
            using (var db = new AppDbContext())
            {
                var startDate = dtpReportStartDate.Value.Date;
                var endDate = dtpReportEndDate.Value.Date.AddDays(1);

                // Günlük satış özeti
                var dailySales = db.Sales.Where(s => s.SaleDate >= startDate && s.SaleDate < endDate).ToList();
                decimal totalCiro = dailySales.Sum(s => s.TotalAmount);
                decimal totalVat = dailySales.Sum(s => s.VatTotal);
                int saleCount = dailySales.Count;

                lblDailySales.Text = $"Toplam Ciro: {totalCiro:C2}";
                lblDailyVat.Text = $"KDV Toplamı: {totalVat:C2}";
                lblDailyCount.Text = $"Satış Adedi: {saleCount}";

                // Brüt kâr hesabı (satış anındaki maliyet fiyatı üzerinden)
                var saleIds = dailySales.Select(s => s.Id).ToList();
                var saleItems = db.SaleItems.Where(si => saleIds.Contains(si.SaleId)).ToList();
                decimal totalProfit = 0;
                var profitBySaleId = new Dictionary<int, decimal>();
                
                foreach (var si in saleItems)
                {
                    decimal costPrice = si.PurchasePriceAtSale;
                    // Eski satışlar için fallback (migration öncesi kayıtlar)
                    if (costPrice == 0 && si.ProductId != null)
                    {
                        var product = db.Products.Find(si.ProductId);
                        if (product != null) costPrice = product.PurchasePrice;
                    }
                    decimal itemProfit = (si.UnitPrice - costPrice) * si.Quantity;
                    totalProfit += itemProfit;
                    
                    if (profitBySaleId.ContainsKey(si.SaleId))
                        profitBySaleId[si.SaleId] += itemProfit;
                    else
                        profitBySaleId[si.SaleId] = itemProfit;
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
                        Toplam = s.TotalAmount.ToString("C2"),
                        Kâr = profitBySaleId.ContainsKey(s.Id) ? profitBySaleId[s.Id].ToString("C2") : 0.ToString("C2")
                    })
                    .ToList();
                dgvDailySalesDetail.DataSource = salesDetail;
            }
        }
    }
}

