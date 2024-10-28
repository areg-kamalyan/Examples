using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IPerson : IEntity<int>
    {
        string? Email { get; set; }
        string? Name { get; set; }
        string? Phone { get; set; }
        int Age { get; set; }
    }
}
