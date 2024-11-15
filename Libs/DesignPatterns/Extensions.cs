using DesignPatterns.Repository.Implementation;
using DesignPatterns.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services,  Dictionary<string, Action<RepositoryOptions>> ConfigureOptions)
        {
            foreach (var service in ConfigureOptions)
            {
                services.AddOptions().Configure(service.Key, service.Value);
            }
            return services
                     .AddScoped<IStutentRepository, StutentRepository>()
                     .AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
