using Microsoft.EntityFrameworkCore;
using School.Models.Entities;

namespace School.Data.context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students {  get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
