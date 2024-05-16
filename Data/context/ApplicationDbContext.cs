using Microsoft.EntityFrameworkCore;
using School.Models.Entities;

namespace School.Data.context
{
    public class ApplicationDbContext : DbContext
    {
        DbSet<Student> Students {  get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Course> Courses { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
