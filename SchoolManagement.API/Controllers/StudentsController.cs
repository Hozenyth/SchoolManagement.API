﻿using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Models;
using SchoolManagement.Application.Comands.CreateStudent;
using SchoolManagement.Application.InputModels;
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
        public IActionResult GetAll(string query)
        {
            var students = _studentService.GetAll(query);
            return Ok(students);
        }

        [HttpGet("{registration}")]
        public IActionResult GetById(int registration)
        {
            var student = _studentService.GetByRegistration(registration);
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
