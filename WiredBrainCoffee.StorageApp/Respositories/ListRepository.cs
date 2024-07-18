using System.Linq;
using WiredBrainCoffee.StorageApp.Entites;

namespace WiredBrainCoffee.StorageApp.Respositories
{
    public class ListRepository<T>: IRepository<T> where T: IEntity
    {
       private readonly List<T> _items = new();
        public IEnumerable<T> GetAll()
        {
            return _items.ToList();
        }
        public void Add(T item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void save()
        {
           //Everything is saved already in the List<T>
        }

        public void remove(T item)
        {
            _items.Remove(item);
        }

        public T GetById(int id)
        {
            return _items.Single(item => item.Id == id);
        }
    }

}
