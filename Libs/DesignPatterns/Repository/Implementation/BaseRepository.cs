using Core;
using Microsoft.Extensions.Options;

namespace DesignPatterns.Repository.Implementation
{
    public class BaseRepository<TEntity, Tkey> : IBaseRepository<TEntity, Tkey> where TEntity : class, IEntity<Tkey>, new()
    {
        private Dictionary<Tkey, TEntity> Data;
        private StoreType storeType;

        protected string FileName;
        public BaseRepository(IOptionsSnapshot<RepositoryOptions> options)
        {
            var _options = options.Get(typeof(TEntity).Name);
            FileName = _options.FileName;
            storeType = _options.StoreType;
            Data = Extensions.Load<TEntity>(storeType, FileName).ToDictionary(p => p.ID);
        }

        public void Delete(Tkey ID)
        {
            Data.Remove(ID);
        }

        public TEntity Get(Tkey ID)
        {
            return Data[ID];
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Data.Select(p => p.Value).ToList();
        }

        public void Insert(TEntity item)
        {
            Data.TryAdd(item.ID, item);
        }

        public void Save()
        {
            Extensions.Write(GetAll().ToList(), storeType, FileName);
        }

        public void Update(TEntity item)
        {
            Data[item.ID] = item;
        }
    }
}
