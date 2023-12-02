using CompanyApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Repositories
{
    public class SqliteRepository<T> : IRepository<T>
    where T : class, IEntity, new()
    {

        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public event EventHandler<T>? ItemAdded;
        public event EventHandler<T>? ItemRemove;

        private List<T> _items;

        public SqliteRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();

        }

        public void Add(T item)
        {
            _dbSet.Add(item);
            ItemAdded?.Invoke(this, item);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
              ItemRemove?.Invoke(this, item);
        }

        public void RemoveAll()
        {
            var allItems = this.GetAll();

            if (allItems.Any())
            {
                _dbSet.RemoveRange(allItems);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Failure: the list of the Items is already empty");
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
