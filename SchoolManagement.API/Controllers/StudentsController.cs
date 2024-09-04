using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Comands.CreateStudent;
using SchoolManagement.Application.Commands.DeleteStudent;
using SchoolManagement.Application.Commands.FinishStudent;
using SchoolManagement.Application.Commands.StartCourse;
using SchoolManagement.Application.Commands.UpdateStudent;
using SchoolManagement.Application.Queries.GetAllStudents;
using SchoolManagement.Application.Queries.GetStudentById;

namespace SchoolManagement.Controllers
{

    [Route("api/students")]
   
    public class StudentsController : ControllerBase
    {
       
        private readonly IMediator _mediator;
        public StudentsController( IMediator mediator)
        {           
            _mediator = mediator;
        }
        
        [HttpGet]
        [Authorize(Roles = "student")]
        public async Task<IActionResult> GetAll(string query)
        {
            var getAllStudentsQuery = new GetAllStudentsQuery(query);
            var students = await _mediator.Send(getAllStudentsQuery);
            return Ok(students);
        }

        [HttpGet("{registration}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int registration)
        {
            var getStudentById = new GetStudentByIdQuery(registration);
            var student = await _mediator.Send(getStudentById);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] CreateStudentCommand command)
        {
            var id = _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { registration = id }, command);
        }

        [HttpPut("UpdateStudent", Name = "UpdateStudent")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            if (string.IsNullOrEmpty(command.Name))
                return BadRequest();
            var studentUpdate = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{registration}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int registration)
        {
            var command = new DeleteStudentCommand(registration);
            await _mediator.Send(command);            
            return NoContent();
        }

        // api/student/1/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartStudentCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/student/1/finish
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishStudentCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }


    }
}
