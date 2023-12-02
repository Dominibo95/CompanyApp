using CompanyApp.Entities;

namespace CompanyApp.Repositories
{
    public interface IWriteRepository<in T> where T : class , IEntity 
    {
        void Add(T item);
        void RemoveAll();
        void Remove(T item);
        void Save();
    }
}
