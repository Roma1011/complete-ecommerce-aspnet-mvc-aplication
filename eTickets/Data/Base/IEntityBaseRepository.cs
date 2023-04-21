using System.Linq.Expressions;
using eTickets.Models;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAll();
        IQueryable<T> GetAllQ();
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetById(int id);
        Task Add(T actor);
        Task Update(int id, T entity);
        Task Delete(int id);
    }
}
