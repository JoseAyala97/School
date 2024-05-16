using Microsoft.EntityFrameworkCore;
using School.Contract.Repositories;
using School.Data.context;
using School.Models.Entities;
using System.Linq.Expressions;

namespace School.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IReadOnlyList<Student>> GetAsync(Expression<Func<Student, bool>> predicate, Func<IQueryable<Student>, IQueryable<Student>> include = null)
        {
            IQueryable<Student> query = _applicationDbContext.Students.Where(predicate);
            if (include != null)
                query = include(query);

            return await query.ToListAsync();
        }
    }
}
