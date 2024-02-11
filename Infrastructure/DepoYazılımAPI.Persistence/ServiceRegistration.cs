using DepoYazılımAPI.Application.Abstractions;
using Microsoft.EntityFrameworkCore;
using DepoYazılımAPI.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using DepoYazılımAPI.Application.Repositorys;
using DepoYazılımAPI.Application.Repositorys.File;
using DepoYazılımAPI.Persistence.Repositories.File;
using DepoYazılımAPI.Application.Repositorys.File.InvoiceFile;
using DepoYazılımAPI.Persistence.Repositories.File.InvoiceFile;
using DepoYazılımAPI.Persistence.Repositories.File.StockCardImageFile;
using DepoYazılımAPI.Application.Repositorys.File.StockCardImageFile;

namespace DepoYazılımAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
           
            services.AddDbContext<DepoYazılımAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
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
