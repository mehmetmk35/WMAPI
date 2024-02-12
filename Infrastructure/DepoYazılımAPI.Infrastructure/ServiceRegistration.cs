using DepoYazılımAPI.Application.Abstractions.Storage;
using DepoYazılımAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DepoYazılımAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageServices>();
        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}
