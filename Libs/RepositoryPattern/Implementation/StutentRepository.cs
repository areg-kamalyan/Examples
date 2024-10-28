using Core.Entitys;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Implementation
{
    public class StutentRepository : BaseRepository<Student, int>, IStutentRepository
    {
        public StutentRepository(IOptionsSnapshot<RepositoryOptions> options) : base(options)
        {
        }
    }
}
