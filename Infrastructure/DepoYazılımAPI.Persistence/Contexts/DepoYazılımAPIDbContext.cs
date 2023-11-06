using DepoYazılımAPI.Domin.Entity.CustomerItem;
using DepoYazılımAPI.Domin.Entity.StockCard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DepoYazılımAPI.Persistence.Concretes
{
    public class DepoYazılımAPIDbContext : DbContext
    {
        public DepoYazılımAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StockCardRecord>(entity => {

            entity.Property(e => e.BranchCode)
            .HasDefaultValueSql(("0"));
             entity.Property(e => e.IsDeleted)
            .HasColumnType("bit")
            .HasDefaultValue(0);
                entity.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
            entity.Property(e => e.UnitOfMeasure1Denominator)
                 .HasColumnType("decimal(28, 8)")
                .IsRequired(false);
            entity.Property(e => e.UnitOfMeasure1Numerator)
                 .HasColumnType("decimal(28, 8)")
                .IsRequired(false);
            entity.Property(e => e.UnitOfMeasure2Denominator)
                 .HasColumnType("decimal(28, 8)")
                .IsRequired(false);
            entity.Property(e => e.UnitOfMeasure2Numerator)
                 .HasColumnType("decimal(28, 8)")
                .IsRequired(false);
            entity.Property(e => e.SellingPrice1)
                 .HasColumnType("decimal(28, 8)")
                .IsRequired(false);
            entity.Property(e => e.SellingPrice2)
                .HasColumnType("decimal(28, 8)")
                .IsRequired(false);
            entity.Property(e => e.VATRate)
                .HasColumnType("decimal(28, 8)")
                .IsRequired(false);
            entity.Property(e => e.PurchasePrice1)
                .HasColumnType("decimal(28, 8)")
                .IsRequired(false);
            entity.Property(e => e.PurchasePrice2)
                .HasColumnType("decimal(28, 8)")
                .IsRequired(false);
            entity.Property(e => e.UnitOfMeasure1Denominator)
                .HasColumnType("decimal(28, 8)")
                .IsRequired(false);
            entity.Property(e => e.Lock)
                .IsRequired(false);                  

            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CustomerItem> CustomerItems { get; set; }
       public DbSet<StockCardRecord> ItemRecords { get; set; }
       public DbSet<Barcode> Barcodes { get; set; }

       




    }
}
