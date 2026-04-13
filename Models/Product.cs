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

        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int VatRate { get; set; } // KDV (1, 8, 18, 20 vb.)
        
        // Anlık gösterim için stok (Asıl stok her zaman hareketlerden hesaplanmalı)
        public decimal CurrentStock { get; set; } 

        // PostgreSQL'in gücü: Dinamik özellikler!
        [Column(TypeName = "jsonb")]
        public string Attributes { get; set; } 
        // Örn: {"marka": "Ülker", "gramaj": "50g", "raf_ömrü": "12_ay"}
        
        public bool IsActive { get; set; } = true;
    }
}
