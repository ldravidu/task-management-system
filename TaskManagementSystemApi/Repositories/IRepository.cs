using System.Linq.Expressions;

namespace TaskManagementSystemApi.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task SaveChanges();
    }
}