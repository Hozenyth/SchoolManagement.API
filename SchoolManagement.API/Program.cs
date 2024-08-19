using Microsoft.EntityFrameworkCore;
using SchoolManagement.Infrastructure.Persistence.Repositories;
using SchoolManagement.Application.Comands.CreateCourse;
using SchoolManagement.Application.Comands.CreateStudent;
using SchoolManagement.Application.Comands.CreateTeacher;
using SchoolManagement.Application.Queries.GetStudentById;
using SchoolManagement.Core.Repositories;
using FluentValidation.AspNetCore;
using SchoolManagement.Application.Validators;
using SchoolManagement.API.Filters;
using SchoolManagement.Core.Services;
using SchoolManagement.Infrastructure.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(o => o.Filters.Add(typeof(ValidatorFilter)))
    .AddFluentValidation(fv =>
    {

        fv.RegisterValidatorsFromAssemblyContaining<CreateCourseCommandValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<GetCourseByIDQueryValidator>();

    }); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(CreateCourseCommand).Assembly));
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(CreateStudentCommand).Assembly));
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(CreateTeacherCommand).Assembly));
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(GetStudentByIdQuery).Assembly));


builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

var connectionString = builder.Configuration.GetConnectionString("SchoolManagementCs");
builder.Services.AddDbContext<SchoolManagementDbContext>(x => x.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
