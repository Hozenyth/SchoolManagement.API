using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Comands.CreateTeacher;
using SchoolManagement.Application.Commands.DeleteTeacher;
using SchoolManagement.Application.Commands.UpdateTeacher;
using SchoolManagement.Application.Queries.GetAllTeachers;
using SchoolManagement.Application.Queries.GetTeacherById;

namespace SchoolManagement.API.Controllers
{
    [Route("api/Teachers")]
    public class TeachersController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        public TeachersController( IMediator mediator) 
        {            
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            var getAllTeachersQuery = new GetAllTeachersQuery(query);
            var teachers = await _mediator.Send(getAllTeachersQuery);
           
            return Ok(teachers);
        }

        [HttpGet("{registration}")]
        public async Task<IActionResult> GetTeacher(int registration)
        {
            var getTeacherById = new GetTeacherByIdQuery(registration);
            var teacher = await _mediator.Send(getTeacherById);
            
            return Ok(teacher);
        }
      

        [HttpPost("CreateTeacher", Name = "CreateTeacher")]
        public async Task<IActionResult> Post([FromBody] CreateTeacherCommand command) 
        {           
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetTeacher), new { registration = id }, command);
        }

        [HttpDelete("DeleteTeacher", Name = "DeleteTeacher")]
        public async Task<IActionResult> DeleteRegistration(int registration) 
        {
            var deleteTeacher = new DeleteTeacherCommand(registration);
            await _mediator.Send(deleteTeacher);
           
            return NoContent();
        }

        [HttpPut("UpdateTeacher", Name = "Updateteacher")]
        public async Task<IActionResult> Put([FromBody] UpdateTeacherCommand command) 
        {
            if(command.Name == null )          
              return BadRequest();
           
            await _mediator.Send(command);           
            return NoContent();
        }

    }
}
