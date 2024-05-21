using Microsoft.EntityFrameworkCore;
using School.Contract.Repositories;
using School.Data.context;
using School.Models.Entities;
using System.Linq.Expressions;

namespace School.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TeacherRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IReadOnlyList<Teacher>> GetAsync(Expression<Func<Teacher, bool>> predicate, Func<IQueryable<Teacher>, IQueryable<Teacher>> include = null)
        {
            IQueryable<Teacher> query = _applicationDbContext.Teachers.Where(predicate);
            if (include != null)
                query = include(query);

            return await query.ToListAsync();
        }
        public async Task<Teacher> FirstOrDefault(Expression<Func<Teacher, bool>> predicate, Func<IQueryable<Teacher>, IQueryable<Teacher>> include = null)
        {
            IQueryable<Teacher> query = _applicationDbContext.Set<Teacher>().AsQueryable();
            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(predicate);
        }
        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Teachers.FindAsync(id);
        }
        public async Task<Teacher> InsertAsync(Teacher teacher)
        {
            _applicationDbContext.Teachers.Add(teacher);
            await _applicationDbContext.SaveChangesAsync();
            return teacher;
        }
    }
}
