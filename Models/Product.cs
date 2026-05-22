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
        public decimal PurchasePrice2 { get; set; }

        public decimal SalePrice { get; set; }
        public int VatRate { get; set; }
        
        public decimal Stock1 { get; set; }
        public decimal Stock2 { get; set; }

        public decimal CurrentStock { get; set; } 

        public decimal CriticalStock { get; set; } = 0;

        public string PosCategory { get; set; }

        public int? PosPosition { get; set; }

        [Column(TypeName = "jsonb")]
        public string Attributes { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
}
