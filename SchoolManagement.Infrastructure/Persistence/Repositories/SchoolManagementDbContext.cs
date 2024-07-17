using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Persistence.Repositories
{
    public class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }      
        public DbSet<Course> Courses { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());                      
        }
    }
}
