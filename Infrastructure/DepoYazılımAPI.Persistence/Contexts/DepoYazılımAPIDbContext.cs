using DepoYazılımAPI.Domin.Entity.CustomerItem;
using DepoYazılımAPI.Domin.Entity.StockCard;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            .HasDefaultValueSql("0");                                            
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CustomerItem> CustomerItems { get; set; }
       public DbSet<StockCardRecord> ItemRecords { get; set; }
       public DbSet<Barcode> Barcodes { get; set; }

       




    }
}
