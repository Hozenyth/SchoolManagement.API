using SchoolManagement.Core.Repositories;
using SchoolManagement.Core.Services;
using SchoolManagement.Infrastructure.Auth;
using SchoolManagement.Infrastructure.MessageBus;
using SchoolManagement.Infrastructure.Payments;
using SchoolManagement.Infrastructure.Persistence.Repositories;

namespace SchoolManagement.API.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
           

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IMessageBusService, MessageBusService>();

            return services;
        }
    }
}
