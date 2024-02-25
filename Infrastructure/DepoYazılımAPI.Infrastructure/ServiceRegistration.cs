using DepoYazılımAPI.Application.Abstractions.Storage;
using DepoYazılımAPI.Infrastructure.Services;
using DepoYazılımAPI.Infrastructure.Services.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace DepoYazılımAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageServices>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T :  Storage, IStorage //Storage zaten  bir class oldugunda class yerine yazıldı
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
