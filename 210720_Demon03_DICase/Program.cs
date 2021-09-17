using _210720_Demon03_ConfigServiceDLL;
using _210720_Demon03_LogServiceDLL;
using _210720_Demon03_MailServiceDLL;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DICase {
    class Program {
        static void Main(string[] args) {
            string iniPath = AppDomain.CurrentDomain.BaseDirectory + "Config.ini";
            ServiceCollection serviceCollection = new ServiceCollection();
            //第一种写法,一一绑定,这种写法需要开放TxtLogService的权限public
            //serviceCollection.AddScoped<IMailService, MailService>();
            //serviceCollection.AddScoped<ILogService, TxtLogService>();           
            //serviceCollection.AddScoped<IConfigService, IniFileConfigService>();
            //第二种写法，扩展方法来屏蔽类，不需要我来绑定，开发框架的人已经帮忙绑定好了,无需开放权限
            serviceCollection.AddMailService();
            serviceCollection.AddLogService();
            serviceCollection.AddConfigService();

            using (var sp = serviceCollection.BuildServiceProvider()) {
                var mail = sp.GetRequiredService<IMailService>();
                mail.Send(iniPath, "Hello,I'm albertzhao");
            }
        }
    }
}
