using System.Reflection;

namespace API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExtensionsServices(this IServiceCollection services, Assembly assembly)
        {
            var servicesInterfaceTypes = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Service"))
                .Select(t => new
                {
                    ServiceType = t.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDisposable) || i.IsAssignableFrom(t)),
                    ImplementationType = t
                }).Where(x => x.ServiceType != null);

            foreach (var serviceType in servicesInterfaceTypes)
            {
                services.AddScoped(serviceType.ServiceType, serviceType.ImplementationType);
            }

            return services;
        }
    }
}
