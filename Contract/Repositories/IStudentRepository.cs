using School.Models.Entities;
using System.Linq.Expressions;

namespace School.Contract.Repositories
{
    public interface IStudentRepository
    {
        Task<IReadOnlyList<Student>> GetAsync(Expression<Func<Student, bool>> predicate, Func<IQueryable<Student>, IQueryable<Student>> include = null);
        Task<Student> FirstOrDefault(Expression<Func<Student, bool>> predicate, Func<IQueryable<Student>, IQueryable<Student>> include = null);
        Task<Student> GetByIdAsync(int id);
        Task<Student> InsterAsync(Student student);
    }
}
