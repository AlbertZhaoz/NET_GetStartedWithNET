using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Json;
using SystemService;
using Exceptionless;

namespace _210915_Demon01_Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var service = new ServiceCollection();
            //前往官方注册exceptionless.com
            ExceptionlessClient.Default.Startup("up5uzK6h92iGTN6ZAXNkiVecefPRWFLuwp45Chfd");
            //设置记录日志等级
            ExceptionlessClient.Default.Configuration.SetDefaultMinLogLevel(Exceptionless.Logging.LogLevel.Trace);
            service.AddLogging(e=> {
                //e.AddConsole();//Console Provider 保存日志到控制台下，这边执行的操作就是ConfigurationBuilder.Addxxx()。
                //e.AddEventLog();//EventLog Provider 保存日志到Windows平台下的EventViewer下。
                //e.AddNLog();//NLog Provider，保存日志到文件中，日志文件保存路径在配置文件中设置。
                //设置日志最低的输出级别，Critical>Error>Warning>Information>Debug>Trace。
                //e.SetMinimumLevel(LogLevel.Trace);
                //Serilog使用
                Log.Logger = new LoggerConfiguration().MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.Console(new JsonFormatter())
                .WriteTo.Exceptionless()//集中化日志服务Exceptionless
                .CreateLogger();
                e.AddSerilog();
                });
            service.AddAlbertLog();//扩展方法

            using (var sp = service.BuildServiceProvider())
            {
                for (int i = 0; i < 1; i++)
                {
                    sp.GetRequiredService<IAlbertLog>().InitData();
                    sp.GetRequiredService<IAlbertLog>().OperateDataError();
                }                
            }
        }
    }
}
