using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public interface IBaseRepository<TEntity, Tkey> where TEntity : IEntity<Tkey>
    {
        public void Insert(TEntity item);
        public void Update(TEntity item);
        public void Delete(Tkey ID);
        public TEntity Get(Tkey ID);
        public void Save();
        public IEnumerable<TEntity> GetAll();
    }
}
