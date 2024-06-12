using Aplication.Interfaces.Repositories;
using Core.CourseService.Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.Database;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.CourseService.DI
{
    public class DependencyRegistry
    {
        public static void RegisterDependencyInjection(IServiceCollection serviceBuilder, ConfigurationManager configuration)
        {
            serviceBuilder.AddTransient<ICourseRepository, CourseRepository>();
            serviceBuilder.AddTransient<IStudentRepository, StudentRepository>();

            serviceBuilder.AddDbContext<PostgresDbContext>();
        }
    }
}
