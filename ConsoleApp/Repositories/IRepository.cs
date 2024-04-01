using ConsoleApp.Models;

namespace ConsoleApp.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T? GetById(Guid id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}