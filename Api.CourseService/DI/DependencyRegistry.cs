using Aplication.Configurations;
using Aplication.Interfaces.Messaging;
using Aplication.Interfaces.Repositories;
using Aplication.Validations;
using Core.CourseService.Aplication.Interfaces.UseCases;
using Core.CourseService.Aplication.UseCases;
using Core.CourseService.Infrastructure.Messaging;
using Core.CourseService.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence.Database;
using Infrastructure.Persistence.Repositories;

namespace Api.CourseService.DI
{
    public class DependencyRegistry
    {
        public static void RegisterDependencyInjection(IServiceCollection serviceBuilder, ConfigurationManager configuration)
        {
            //Database Context
            serviceBuilder.AddDbContext<PostgresDbContext>();

            //Messaging Context
            serviceBuilder.Configure<KafkaConfiguration>(configuration.GetSection(nameof(KafkaConfiguration)));
            serviceBuilder.AddTransient<IEnrollmentDataPublisher, EnrollmentDataPublisher>();

            //Repositories
            serviceBuilder.AddTransient<ICourseRepository, CourseRepository>();
            serviceBuilder.AddTransient<IStudentRepository, StudentRepository>();
            serviceBuilder.AddTransient<IEnrollmentRepository, EnrollmentRepository>();

            //Validations
            serviceBuilder.AddFluentValidationAutoValidation();
            serviceBuilder.AddValidatorsFromAssemblyContaining<StudentValidator>();

            //UseCases
            serviceBuilder.AddTransient<IEnrollStudentToCourse, EnrollStudentToCourse>();
        }
    }
}
