using Core;

namespace DesignPatterns.Repository
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
