using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagement.Core.Entities;
using System.Reflection.Emit;

namespace SchoolManagement.Infrastructure.Persistence.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
            .HasKey(c => c.Id);

            builder
                  .HasOne(c => c.Teacher)
                  .WithMany(c => c.Courses)                 
                  .HasForeignKey(c => c.TeacherId).IsRequired(required: false)
                  .OnDelete(DeleteBehavior.Restrict);           
        }
    }
}
