using RepositoryPattern.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public class RepositoryOptions
    {
        public string FileName { get; set; }
        public StoreType StoreType { get; set; }
    }
}
