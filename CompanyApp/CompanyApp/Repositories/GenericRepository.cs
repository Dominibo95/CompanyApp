using CompanyApp.Entities;
using System.Xml.Serialization;

namespace CompanyApp.Repositories
{
    public class GenericRepository<TEntity, Tkey> 
        where TEntity : class, IEntity , new()
        where Tkey : struct
    {
        private readonly List<TEntity> _items = new();

        public void Add(TEntity item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public TEntity GetById(int id)
        {
              return default(TEntity);
          //  return _items.Single(item => item.Id == id);
        }

        public void Safe()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(_items);
            }
        }


    }
}
