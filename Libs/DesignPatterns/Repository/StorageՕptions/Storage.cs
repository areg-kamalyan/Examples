using Core;

namespace DesignPatterns.Repository.StorageՕptions
{
    public abstract class Storage
    {
        protected string ConnectionString = @"Server=(localdb)\ProjectModels;Database=UniversityDb;Trusted_Connection=True;Integrated Security=True";
        public Storage()
        {

        }

        public abstract IEnumerable<T> Load<T>();

        public abstract void Write<T>(List<T> source);

    }
}
