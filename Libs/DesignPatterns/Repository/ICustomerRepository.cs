using Core.Entitys;

namespace DesignPatterns.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer, int>
    {
    }
}
