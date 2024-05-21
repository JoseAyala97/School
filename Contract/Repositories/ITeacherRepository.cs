using School.Models.Entities;
using System.Linq.Expressions;

namespace School.Contract.Repositories
{
    public interface ITeacherRepository
    {
        Task<IReadOnlyList<Teacher>> GetAsync(Expression<Func<Teacher, bool>> predicate, Func<IQueryable<Teacher>, IQueryable<Teacher>> include = null);
        Task<Teacher> FirstOrDefault(Expression<Func<Teacher, bool>> predicate, Func<IQueryable<Teacher>, IQueryable<Teacher>> include = null);
        Task<Teacher> GetByIdAsync(int id);
        Task<Teacher> InsertAsync(Teacher teacher);
    }
}
