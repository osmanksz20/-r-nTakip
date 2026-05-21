using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ÜrünTakip.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string FullName { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        /// <summary>Anlık toplam borç (veresiye satışlardan hesaplanır)</summary>
        public decimal TotalDebt { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<Sale> Sales { get; set; }
    }
}
