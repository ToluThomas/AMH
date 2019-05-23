using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AMHaulage.Models
{
    public class AppointmentRepository<T> : IAppointmentRepository<T> where T : class
    {
        private readonly AppointmentContext _dbContext;
        private readonly DbSet<T> _dbSet;
 
        public AppointmentRepository(AppointmentContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
 
        #region IAppointmentRepository<T> Members
        
        public EntityEntry<T> Add(T entity)
        {
            return _dbContext.Add(entity);
        }

        public EntityEntry<T> Update(T entity)
        {
            return _dbContext.Update(entity);
        }

        public Task<int> SaveChanges()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> List()
        {
            return _dbSet;
        }
 
        public async Task<T> Find(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        public Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefaultAsync(predicate);
        }

        public AppointmentContext GetContext()
        {
            return _dbContext;
        }

        #endregion
    }
}