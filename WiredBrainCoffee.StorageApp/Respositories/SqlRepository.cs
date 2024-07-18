using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.StorageApp.Entites;

namespace WiredBrainCoffee.StorageApp.Respositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public event EventHandler<T>? itemadded;

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }
        public void Add(T item)
        {
            _dbSet.Add(item);
            itemadded?.Invoke(this, item);
        }

        public void save()
        {
            _dbContext.SaveChanges();
        }

        public void remove(T item)
        {
            _dbSet.Remove(item);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }

}
