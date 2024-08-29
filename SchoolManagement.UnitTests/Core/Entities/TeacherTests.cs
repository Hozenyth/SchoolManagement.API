using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Enums;

namespace SchoolManagement.UnitTests.Core.Entities
{
    public class TeacherTests
    {
        [Fact]
        public void TestTeacherStartWorks()
        {
            var teacher = new Student("Hoze", "2299999999", 2022401, "hoze@teste.com", "student", "123456");

            Assert.Equal(StudentStatusEnum.Created, teacher.StudentStatus);

            Assert.NotEmpty(teacher.Name);
            Assert.NotNull(teacher.Name);

            Assert.NotEmpty(teacher.PhoneNumber);
            Assert.NotNull(teacher.PhoneNumber);

            Assert.NotNull(teacher.Registration);

            Assert.NotEmpty(teacher.Email);
            Assert.NotNull(teacher.Email);

            Assert.NotNull(teacher.CreatedAt);
        }
        [Fact]
        public void TestTeacherEndWorks()
        {
            var teacher = new Student("Hoze", "2299999999", 2022401, "hoze@teste.com", "student", "123456");

            Assert.Equal(StudentStatusEnum.Created, teacher.StudentStatus);

            Assert.NotEmpty(teacher.Name);
            Assert.NotNull(teacher.Name);

            Assert.NotEmpty(teacher.PhoneNumber);
            Assert.NotNull(teacher.PhoneNumber);

            Assert.NotNull(teacher.Registration);

            Assert.NotEmpty(teacher.Email);
            Assert.NotNull(teacher.Email);

            teacher.Cancel();

            Assert.NotNull(teacher.CreatedAt);

        }
    }
}
