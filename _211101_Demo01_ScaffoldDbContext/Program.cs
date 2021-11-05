using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Formatting.Json;
using Microsoft.Extensions.Logging;

namespace _211101_Demo01_ScaffoldDbContext
{
    internal class Program
    {
        private static ServiceCollection service = new ServiceCollection();

        static void Main(string[] args)
        {
            //依赖注入
            service.AddScoped<ILoggerFactory>(e=>new LoggerFactory());
            //service.AddLogging(e => {
            //    Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
            //    .Enrich.FromLogContext()
            //    .WriteTo.Console(new JsonFormatter())
            //    .CreateLogger();
            //    e.AddSerilog();
            //});          
        }
    }
}
