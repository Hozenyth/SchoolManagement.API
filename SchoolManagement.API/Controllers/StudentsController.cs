using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Models;
using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.Services.Interfaces;

namespace SchoolManagement.Controllers
{
   
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
                
        }

        [HttpGet]
        public IActionResult GetAll(string query)
        {
            var students = _studentService.GetAll(query);
            return Ok(students);
        }

        [HttpGet("{registration}")]
        public IActionResult GetById(int registration)
        {
            var student = _studentService.GetByRegistration(registration);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
              
        [HttpPost]
        public IActionResult Post([FromBody] NewStudentInputModel inputModel, [FromServices] IValidator<NewStudentInputModel> validator)
        {
            var result = validator.Validate(inputModel);
            var error = result.Errors.Select(e => e.ErrorMessage);

            if (!result.IsValid)
                return BadRequest(error);
            else
            {
                var registration = _studentService.CreateStudent(inputModel);
                return CreatedAtAction(nameof(GetById), new { registration = registration }, inputModel);
            }                     
        }

        [HttpPut("UpdateStudent", Name = "UpdateStudent")]       
        public IActionResult UpdateStudent([FromBody] UpdateStudentInputModel inputModel, int registration) 
        {
            if (string.IsNullOrEmpty(inputModel.Name))            
               return BadRequest();
            
            _studentService.UpdateStudent(inputModel, registration);

            return NoContent();
        }

        [HttpDelete("{registration}")]
        public IActionResult Delete(int registration)
        {
            _studentService.DeleteStudent(registration);
            return NoContent();
        }
    }
}
