using Aplication.Repositories;
using Infrastructure.Database;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.CourseService.DI
{
    public class DependencyRegistry
    {
        public static void RegisterDependencyInjection(IServiceCollection serviceBuilder, ConfigurationManager configuration)
        {
            serviceBuilder.AddTransient<ICourseRepository, CourseRepository>();

            serviceBuilder.AddDbContext<PostgresDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgresContext")));
        }
    }
}
