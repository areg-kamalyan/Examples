using Core.Entitys;
using Microsoft.Extensions.Options;
namespace DesignPatterns.Repository.Implementation
{
    public class StutentRepository : BaseRepository<Student, int>, IStutentRepository
    {
        public StutentRepository(IOptionsSnapshot<RepositoryOptions> options) : base(options)
        {
        }
    }
}
