using DepoYazılımAPI.Application.Abstractions.Storage;
using DepoYazılımAPI.Application.Abstractions.Token;
using DepoYazılımAPI.Infrastructure.Services;
using DepoYazılımAPI.Infrastructure.Services.Storage;
using DepoYazılımAPI.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace DepoYazılımAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageServices>();
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T :  Storage, IStorage //Storage zaten  bir class oldugunda class yerine yazıldı
        {
            serviceCollection.AddScoped<IStorage, T>();
          
        }
    }
}
