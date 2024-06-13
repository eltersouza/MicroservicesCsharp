using Aplication.Interfaces.Messaging;
using Aplication.Interfaces.Repositories;
using Aplication.Validations;
using Core.CourseService.Infrastructure.Persistence.Repositories;
using Core.FinanceService.Application.Configurations;
using Core.FinanceService.Application.Interfaces.UseCases;
using Core.FinanceService.Application.UseCases;
using Core.FinanceService.Infrastructure.Messaging;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Persistence.Database;
using Infrastructure.Persistence.Repositories;

namespace Worker.FinanceService.DI
{
    public class DependencyRegistry
    {
        public static void RegisterDependencyInjection(IServiceCollection serviceBuilder, ConfigurationManager configuration)
        {
            //Database Context
            serviceBuilder.AddDbContextFactory<PostgresDbContext>();

            //Messaging Context
            serviceBuilder.Configure<KafkaConfiguration>(configuration.GetSection(nameof(KafkaConfiguration)));
            serviceBuilder.AddTransient<IEnrollmentConsumerService, EnrollmentConsumerService>();

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
