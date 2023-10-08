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

namespace DepoYazılımAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
           
            services.AddDbContext<DepoYazılımAPIDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
        } public static void AddPersistenceServicess(this IServiceCollection services)
        {
            services.AddSingleton<IStockCardListService,StockCardListService>();
        }
    }
}
