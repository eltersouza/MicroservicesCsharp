using Worker.FinanceService.DI;

namespace Worker.FinanceService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            DependencyRegistry.RegisterDependencyInjection(builder.Services, builder.Configuration);

            builder.Services.AddHostedService<Worker>();

            var host = builder.Build();
            host.Run();
        }
    }
}