using Moq;
using SchoolManagement.Application.Comands.CreateCourse;
using SchoolManagement.Application.Comands.CreateStudent;
using SchoolManagement.Application.Comands.CreateTeacher;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Repositories;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.UnitTests.Application.Commands
{
    public class CreateTeacherCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnCourseId()
        {
            //Arrange
            var teacherRepository = new Mock<ITeacherRepository>();

            var createTeacherCommand = new CreateTeacherCommand
            {
                Email = "teste@teste.com",
                Name = "name",
                PhoneNumber = "1234567890",
                Registration = 1              
            };

            var createTeacherCommandHandler = new CreateTeacherCommandHandler(teacherRepository.Object);

            //Act

            var id = await createTeacherCommandHandler.Handle(createTeacherCommand, new CancellationToken());

            //Assert

            Assert.True(id >= 0);
            teacherRepository.Verify(c => c.AddAssync(It.IsAny<Teacher>()), Times.Once);
        }
    }
}
