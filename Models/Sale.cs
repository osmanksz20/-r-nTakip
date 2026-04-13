using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ÜrünTakip.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }
        public decimal VatTotal { get; set; }

        /// <summary>Nakit, Kart, Veresiye, Nakit&Kart (Detaylı)</summary>
        [MaxLength(100)]
        public string PaymentType { get; set; }

        /// <summary>Veresiye satışlarda müşteri Id</summary>
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        [MaxLength(100)]
        public string CashierName { get; set; }

        public ICollection<SaleItem> Items { get; set; }
    }
}
