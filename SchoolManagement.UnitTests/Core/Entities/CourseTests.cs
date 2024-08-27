using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Enums;

namespace SchoolManagement.UnitTests.Core.Entities
{
    public class CourseTests
    {
        [Fact]
        public void TestCourseStartWorks()
        {
            var course = new Course("Title of Course", "Description abou Course");

            Assert.Equal(CourseStatusEnum.Created, course.Status);
            
            Assert.NotEmpty(course.Title);
            Assert.NotNull(course.Title);
           
            Assert.NotEmpty(course.Description);
            Assert.NotNull(course.Description);
            
            course.Start();

            Assert.Equal(CourseStatusEnum.InProgress, course.Status);
            Assert.NotNull(course.StartedAt);
            
        }

        [Fact]
        public void TestCourseCancelWorks()
        {

        }
    }
}
