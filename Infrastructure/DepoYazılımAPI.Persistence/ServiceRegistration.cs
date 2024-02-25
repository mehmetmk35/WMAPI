using DepoYazılımAPI.Application.Repositorys;
using DepoYazılımAPI.Application.Repositorys.File;
using DepoYazılımAPI.Application.Repositorys.File.InvoiceFile;
using DepoYazılımAPI.Application.Repositorys.File.StockCardImageFile;
using DepoYazılımAPI.Domin.Entity.Identity;
using DepoYazılımAPI.Persistence.Concretes;
using DepoYazılımAPI.Persistence.Repositories.File;
using DepoYazılımAPI.Persistence.Repositories.File.InvoiceFile;
using DepoYazılımAPI.Persistence.Repositories.File.StockCardImageFile;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DepoYazılımAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
           
            
            services.AddDbContext<DepoYazılımAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddIdentity<AppUser, AppRole>(options => 
            { 
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<DepoYazılımAPIDbContext>();
            services.AddScoped<IStockCardReadRepository, StockCardReadRepository>();
            services.AddScoped<IStockCardWriteRepository, StockCardWriteRepository>();
            services.AddScoped<IFileReadRepository,FileReadRepository>();
            services.AddScoped<IFileWriteRepository,FileWriteRepository>();
            services.AddScoped<IStockCardImageFileWriteRepository,StockCardImageFileWriteRepository>();
            services.AddScoped<IStockCardImageFileReadRepository,StockCardImageFileReadRepository>();
            services.AddScoped<IInvoiceFileReadRepository,InvoiceFileReadRepository>();
            services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();
        }
}
}
