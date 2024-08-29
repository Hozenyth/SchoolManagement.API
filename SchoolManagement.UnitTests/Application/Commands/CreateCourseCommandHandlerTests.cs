using Moq;
using SchoolManagement.Application.Comands.CreateCourse;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Repositories;

namespace SchoolManagement.UnitTests.Application.Commands
{
    public class CreateCourseCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnCourseId()
        {
            //Arrange
            var courseRepository = new Mock<ICourseRepository>();

            var createCourseCommand = new CreateCourseCommand
            {
               Title = "Test",
               Description = "Test Description",
            };

            var createCourseCommandHandler = new CreateCourseCommandHandler(courseRepository.Object);

            //Act

            var id = await createCourseCommandHandler.Handle(createCourseCommand, new CancellationToken());

            //Assert

            Assert.True(id >= 0);
            courseRepository.Verify(c => c.AddAsync(It.IsAny<Course>()), Times.Once);
        }
    }
}
