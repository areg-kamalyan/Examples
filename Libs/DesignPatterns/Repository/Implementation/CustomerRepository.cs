using Core.Entitys;
using Microsoft.Extensions.Options;

namespace DesignPatterns.Repository.Implementation
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(IOptionsSnapshot<RepositoryOptions> options) : base(options)
        {
        }
    }
}
