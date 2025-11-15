using Core;
using DesignPatterns.Repository.StorageՕptions;
using Microsoft.Extensions.Options;

namespace DesignPatterns.Repository.Implementation
{
    public abstract class BaseRepository<TEntity, Tkey> : IBaseRepository<TEntity, Tkey> where TEntity : class, IEntity<Tkey>, new()
    {
        private Dictionary<Tkey, TEntity> Data;
        private Storage storage;
        public BaseRepository(IOptionsSnapshot<RepositoryOptions> options)
        {
            var _options = options.Get(typeof(TEntity).Name);
            storage = _options.StoreType;
            Data = storage.Load<TEntity>().ToDictionary(p => p.ID);
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
            storage.Write(GetAll().ToList());
        }

        public void Update(TEntity item)
        {
            Data[item.ID] = item;
        }
    }
}
