using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;

namespace _211101_Demo01_ScaffoldDbContext
{
    internal class Program
    {
        private static ServiceCollection service = new ServiceCollection();

        static void Main(string[] args)
        {
            //依赖注入
            service.AddAlbertLogExtension();
            service.AddScoped<AlbertBookContext>();
            service.AddLogging(e => {
                Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console(new JsonFormatter())
                .CreateLogger();
                e.AddSerilog();
            });
        }
    }
}
