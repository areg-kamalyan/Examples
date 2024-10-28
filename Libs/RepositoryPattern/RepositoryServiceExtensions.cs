using Microsoft.Extensions.DependencyInjection;
using RepositoryPattern;
using RepositoryPattern.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryServiceExtensions
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
