using WiredBrainCoffee.StorageApp.Entites;

namespace WiredBrainCoffee.StorageApp.Respositories
{
    public interface IWriteRepository<in T>
    {
        void Add(T item);
        void remove(T item);
        void save();
    }
    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
    
    
    
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> 
        where T : IEntity
    {
       
    }
}