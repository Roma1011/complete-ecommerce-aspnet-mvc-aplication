using System.Linq.Expressions;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T>:IEntityBaseRepository<T> where T : class,IEntityBase,new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityBaseRepository(AppDbContext context)
        {
            _context= context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetAllQ()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query= _context.Set<T>();
            query = includeProperties.Aggregate(query,(current, includeProperties) => current.Include(includeProperties));

            return await query.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
           return await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task Add(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task Update(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity= await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();

        }
    }
}
