using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Comands.CreateCourse;
using SchoolManagement.Application.Comands.DeleteCourse;
using SchoolManagement.Application.Comands.UpdateCourse;
using SchoolManagement.Application.Comands.UpdateTeacherCourse;
using SchoolManagement.Application.Queries.GetAllCourses;
using SchoolManagement.Application.Queries.GetCourseById;
using SchoolManagement.Application.Validators;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.API.Controllers
{
    [Route("api/Course")]
    public class CourseController : ControllerBase
    {
       
        private readonly IMediator _mediator;
        public CourseController( IMediator mediator)
        {            
            _mediator = mediator;
        }

        [HttpGet("GetAllCourses", Name = "GetAllCourse")]
        public async Task<IActionResult> GetAll(string query)
        {
            var getAllCoursesQuery = new GetAllCoursesQuery(query);
            var courses = await _mediator.Send(getAllCoursesQuery);

            return Ok(courses);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, [FromServices] GetCourseByIDQueryValidator validator)
        {
            var getCourseQuery = new GetCourseByIdQuery(id);
            var validationResult = await validator.ValidateAsync(getCourseQuery);
                      
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select( e => e.ErrorMessage));
            }
            var course = await _mediator.Send(getCourseQuery);          
            return Ok(course);
           
        }

        [HttpPost("CreateCourse", Name = "CreateCourse")]
        public async Task<IActionResult> Post([FromBody] CreateCourseCommand command)
        {
           
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id }, command);
        }

        [HttpPut("UpdateCourse", Name = "UpdateCourse")]
        public async Task<IActionResult> Put([FromBody] UpdateCourseCommand command)
        {
                       
            if (string.IsNullOrEmpty(command.Title))
                return BadRequest();
            else
            {
                await _mediator.Send(command);
                return Ok();
            }
        }

        [HttpDelete("DeleteCourse", Name = "DeleteCourse")]
        public async Task<IActionResult> Delete(int id, [FromServices] GetCourseByIDQueryValidator validator)
        {
            var getCourseQuery = new GetCourseByIdQuery(id);
            var validationResult = await validator.ValidateAsync(getCourseQuery);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            var command = new DeleteCourseCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("UpdateTeacherCourse", Name = "UpdateTeacherCourse")]
        public async Task<IActionResult> Put([FromBody] UpdateTeacherCourseCommand command)
        {          
            await _mediator.Send(command);
            return Ok();
        }
      
    }
}
