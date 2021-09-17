using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using SystemService;

namespace _210915_Demon01_Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceCollection();
            service.AddLogging(e=> {
                //e.AddConsole();//Console Provider 保存日志到控制台下，这边执行的操作就是ConfigurationBuilder.Addxxx()。
                //e.AddEventLog();//EventLog Provider 保存日志到Windows平台下的EventViewer下。
                e.AddNLog();//NLog Provider，保存日志到文件中，日志文件保存路径在配置文件中设置。
                //设置日志最低的输出级别，Critical>Error>Warning>Information>Debug>Trace。
                //e.SetMinimumLevel(LogLevel.Trace);
                });
            service.AddAlbertLog();//扩展方法

            using (var sp = service.BuildServiceProvider())
            {
                for (int i = 0; i < 10000; i++)
                {
                    sp.GetRequiredService<IAlbertLog>().InitData();
                    sp.GetRequiredService<IAlbertLog>().OperateDataError();
                }                
            }
        }
    }
}
