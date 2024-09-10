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
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SchoolManagement.Infrastructure.Payments;

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


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolManagement.API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header with Bearer."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}
                     }
    });
   
});

builder.Services
              .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,

                      ValidIssuer = builder.Configuration["Jwt:Issuer"],
                      ValidAudience = builder.Configuration["Jwt:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                  };
              });


builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(CreateCourseCommand).Assembly));
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(CreateStudentCommand).Assembly));
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(CreateTeacherCommand).Assembly));
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(GetStudentByIdQuery).Assembly));


builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddHttpClient<IPaymentService, PaymentService>();

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
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
