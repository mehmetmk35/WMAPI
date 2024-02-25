using DepoYazılımAPI.Domin.Entity.Common;
using DepoYazılımAPI.Domin.Entity.CustomerItem;
using DepoYazılımAPI.Domin.Entity.FileUpload;
using DepoYazılımAPI.Domin.Entity.Identity;
using DepoYazılımAPI.Domin.Entity.StockCard;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DepoYazılımAPI.Persistence.Concretes
{
    public class DepoYazılımAPIDbContext : IdentityDbContext<AppUser,AppRole,string>     //normalde DbContext ama user ile ilgili işlemlerde  IdentityDbContext
    {
        public DepoYazılımAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<StockCardRecord>(entity => {

             entity.HasKey(e => e.StockCode)
            .HasName("itemrecords_pkey");

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
       public DbSet<Domin.Entity.FileUpload.File> Files { get; set; }
       public DbSet<InvoiceFile> InvoiceFiles { get; set; }
       public DbSet<StockCardImageFile> StockCardImageFiles { get; set; }






        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //update işlemlerinde changeTracker ile yakalayıp UpdatedAt alanına datedate veriyoruz
            //In update operations, we capture changes with ChangeTracker and assign a date to the UpdatedAt field.
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
               
                switch (data.State)
                {
                    case EntityState.Deleted:
                        data.Entity.IsDeleted = true;
                        data.Entity.DeletedDate = DateTime.UtcNow;
                        data.State = EntityState.Modified;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedAt = DateTime.UtcNow;
                        data.Entity.IsDeleted = false;
                        break;
                    case EntityState.Modified:
                        data.Entity.UpdatedAt = DateTime.UtcNow;
                        break;
                     
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }



    }
}
