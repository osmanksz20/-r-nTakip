using System.ComponentModel.DataAnnotations;

namespace ÜrünTakip.Models
{
    public class SaleItem
    {
        public int Id { get; set; }

        public int SaleId { get; set; }
        public Sale Sale { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }

        /// <summary>Satış anındaki ürün adı (ürün sonradan değişse bile kayıt kalır)</summary>
        [MaxLength(200)]
        public string ProductName { get; set; }

        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int VatRate { get; set; }
        public decimal LineTotal { get; set; }

        /// <summary>Satış anındaki maliyet fiyatı (ağırlıklı ortalama, kâr hesabı için)</summary>
        public decimal PurchasePriceAtSale { get; set; }
    }
}
