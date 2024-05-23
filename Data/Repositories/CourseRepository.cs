using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using School.Contract.Repositories;
using School.Data.context;
using School.Models.Entities;
using System.Linq.Expressions;

namespace School.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CourseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IReadOnlyList<Course>> GetAsync(Expression<Func<Course, bool>> predicate, Func<IQueryable<Course>, IQueryable<Course>> include = null)
        {
            IQueryable<Course> query = _applicationDbContext.Courses.Where(predicate);
            if (include != null)
                query = include(query);

            return await query.ToListAsync();
        }
        public async Task<Course> FirstOrDefault(Expression<Func<Course, bool>> predicate, Func<IQueryable<Course>, IQueryable<Course>> include = null)
        {
            IQueryable<Course> query = _applicationDbContext.Set<Course>().AsQueryable();
            if (include != null)
                query = include(query);

            return await query.FirstOrDefaultAsync(predicate);
        }
        public async Task<Course> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Courses.FindAsync(id);
        }
        public async Task<Course> InsertAsync(Course course)
        {
            _applicationDbContext.Courses.Add(course);
            await _applicationDbContext.SaveChangesAsync();

            return course;
        }
        public async Task UpdateAsync(Course course)
        {
            _applicationDbContext.Courses.Update(course);
            await _applicationDbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var student = await _applicationDbContext.Students.FindAsync(id);
            if (student != null)
                _applicationDbContext.Students.Remove(student);
            await _applicationDbContext.SaveChangesAsync();

        }
    }
}
