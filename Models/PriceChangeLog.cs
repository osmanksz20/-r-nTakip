using System;
using System.ComponentModel.DataAnnotations;

namespace ÜrünTakip.Models
{
    /// <summary>
    /// Ürün fiyat değişikliği kaydı. Raf etiketi modülünde kullanılır.
    /// </summary>
    public class PriceChangeLog
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [MaxLength(200)]
        public string ProductName { get; set; }

        [MaxLength(50)]
        public string Barcode { get; set; }

        /// <summary>Eski satış fiyatı</summary>
        public decimal OldPrice { get; set; }

        /// <summary>Yeni satış fiyatı</summary>
        public decimal NewPrice { get; set; }

        /// <summary>Değişiklik tarihi</summary>
        public DateTime ChangeDate { get; set; } = DateTime.Now;

        /// <summary>Etiket yazdırıldı mı?</summary>
        public bool LabelPrinted { get; set; } = false;
    }
}
