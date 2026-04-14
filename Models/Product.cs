using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ÜrünTakip.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Barcode { get; set; } 
        
        [Required, MaxLength(200)]
        public string Name { get; set; }
        
        public DateTime EntryDate { get; set; } = DateTime.Now;
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        /// <summary>1. Alış Fiyatı</summary>
        public decimal PurchasePrice { get; set; }
        
        /// <summary>2. Alış Fiyatı</summary>
        public decimal PurchasePrice2 { get; set; }

        public decimal SalePrice { get; set; }
        public int VatRate { get; set; } // KDV (1, 8, 18, 20 vb.)
        
        /// <summary>1. Alış fiyatına ait stok miktarı</summary>
        public decimal Stock1 { get; set; }
        
        /// <summary>2. Alış fiyatına ait stok miktarı</summary>
        public decimal Stock2 { get; set; }

        /// <summary>Toplam stok (Stock1 + Stock2). DB'ye yazılır, satışta güncellenir.</summary>
        public decimal CurrentStock { get; set; } 

        // PostgreSQL'in gücü: Dinamik özellikler!
        [Column(TypeName = "jsonb")]
        public string Attributes { get; set; } 
        // Örn: {"marka": "Ülker", "gramaj": "50g", "raf_ömrü": "12_ay"}
        
        public bool IsActive { get; set; } = true;
    }
}
