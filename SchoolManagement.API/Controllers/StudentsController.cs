﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Comands.CreateStudent;
using SchoolManagement.Application.Comands.DeleteCourse;
using SchoolManagement.Application.Commands.DeleteStudent;
using SchoolManagement.Application.Commands.UpdateStudent;
using SchoolManagement.Application.InputModels;
using SchoolManagement.Application.Queries.GetAllCourses;
using SchoolManagement.Application.Queries.GetAllStudents;
using SchoolManagement.Application.Queries.GetStudentById;
using SchoolManagement.Application.Services.Interfaces;

namespace SchoolManagement.Controllers
{

    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMediator _mediator;
        public StudentsController(IStudentService studentService, IMediator mediator)
        {
            _studentService = studentService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            var getAllStudentsQuery = new GetAllStudentsQuery(query);
            var students = await _mediator.Send(getAllStudentsQuery);
            return Ok(students);
        }

        [HttpGet("{registration}")]
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
        public IActionResult Post([FromBody] CreateStudentCommand command)
        {

            var id = _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { registration = id }, command);

        }

        [HttpPut("UpdateStudent", Name = "UpdateStudent")]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            if (string.IsNullOrEmpty(command.Name))
                return BadRequest();
            var studentUpdate = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{registration}")]
        public async Task<IActionResult> Delete(int registration)
        {
            var command = new DeleteStudentCommand(registration);
            await _mediator.Send(command);            
            return NoContent();
        }
    }
}
