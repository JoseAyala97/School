using School.Models.Entities;
using System.Linq.Expressions;

namespace School.Contract.Repositories
{
    public interface ICourseRepository
    {
        Task<IReadOnlyList<Course>> GetAsync(Expression<Func<Course, bool>> predicate, Func<IQueryable<Course>, IQueryable<Course>> include = null);
        Task<Course> FirstOrDefault(Expression<Func<Course, bool>> predicate, Func<IQueryable<Course>, IQueryable<Course>> include = null);
        Task<Course> GetByIdAsync(int id); 
        Task<Course> InsertAsync(Course course);
        Task UpdateAsync(Course course);
        Task DeleteAsync(int id);
    }
}
