using Microsoft.EntityFrameworkCore;
using ÜrünTakip.Models;

namespace ÜrünTakip.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // TODO: Kendi yerel PostgreSQL bilgilerinize göre burayı düzenleyiniz.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=UrunTakipDB;Username=postgres;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Barcode alanı için Unique Index oluşturulması
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.Barcode)
                .IsUnique();
        }
    }
}
