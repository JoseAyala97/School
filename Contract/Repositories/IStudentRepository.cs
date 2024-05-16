using School.Models.Entities;
using System.Linq.Expressions;

namespace School.Contract.Repositories
{
    public interface IStudentRepository
    {
        //Task<Student> GetById(int id);
        Task<IReadOnlyList<Student>> GetAsync(Expression<Func<Student, bool>> predicate, Func<IQueryable<Student>, IQueryable<Student>> include = null);
        //Task<Student> InsertAsync(Student student);
        //Task<Student> UpdateAsync(Student student);
    }
}
