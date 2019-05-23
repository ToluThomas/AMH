using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace AMHaulage.Models
{
    public interface IAppointmentRepository<T> where T : class
    {
        EntityEntry<T > Add(T entity);
        EntityEntry<T > Update(T entity);
        Task<int> SaveChanges();
        void Remove(T entity);
        IQueryable<T> List();
        Task<T> Find(int? id);
        bool Any(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate);
        AppointmentContext GetContext();
    }
}