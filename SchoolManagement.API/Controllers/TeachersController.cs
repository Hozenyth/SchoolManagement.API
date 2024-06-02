using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Models;
using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.Services.Implementations.Services;
using SchoolManagement.Application.Services.Interfaces;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.API.Controllers
{
    [Route("api/Teachers")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _service;
        public TeachersController(ITeacherService teacherService) 
        { 
            _service = teacherService;
        }

        [HttpGet]
        public IActionResult GetAll(string query)
        {
            var teachers = _service.GetAllTeachers();
            
            return Ok(teachers);
        }

        [HttpGet("{registration}")]
        public IActionResult GetTeacherDetais(int registration)
        {
            var teacher = _service.GetTeacherDetails(registration);
            
            return Ok(teacher);
        }
      

        [HttpPost("CreateTeacher", Name = "CreateTeacher")]
        public IActionResult Post([FromBody] NewTeacherInputModel inputModel) 
        {
            var id = _service.CreateNewTeacher(inputModel);

            return CreatedAtAction(nameof(GetTeacherDetais), new { id = id }, inputModel);
        }

        [HttpDelete]
        public IActionResult DeleteRegistration(int registration) 
        {
           _service.DeleteTeacher(registration);
           
            return NoContent();
        }

        [HttpPut]
        public IActionResult PutRegistration(int registration) 
        { 
            return Ok();
        }

    }
}
