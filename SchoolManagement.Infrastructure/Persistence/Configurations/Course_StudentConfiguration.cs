using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Persistence.Configurations
{
    public class Course_StudentConfiguration : IEntityTypeConfiguration<Course_Student>
    {               
        public void Configure(EntityTypeBuilder<Course_Student> builder)
        {
            builder
               .HasKey(x => new { x.StudentId, x.CourseId });
                      
        }
    }
}
