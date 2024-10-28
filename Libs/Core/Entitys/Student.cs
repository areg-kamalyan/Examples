using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entitys
{
    public class Student : Person, IPerson
    {
        public int Pension { get; set; }
    }
}
