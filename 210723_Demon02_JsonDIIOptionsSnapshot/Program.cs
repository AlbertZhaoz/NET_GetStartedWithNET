using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _210723_Demon02_JsonDIIOptionsSnapshot {
    class Program {
        static void Main(string[] args) {
            var services = new ServiceCollection();
            //依赖注入，注入TestController对象和AppConfigController对象
            services.AddTestController();
            services.AddAppConfig();
            //services.AddScoped<IController, TestController>();
            //services.AddScoped<AppConfigController>();

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //此处必须将reloadOnChange设置为true，每次改变都要加载
            configurationBuilder.AddJsonFile("webconfig.json", false, true);
            var rootConfig = configurationBuilder.Build();
            var temp = rootConfig.GetSection("AppConfig");

            //这边将rootConfig根节点绑定到Root对象上
            //将rootConfig的子域对象绑定到AppConfig对象
            services.AddOptions()
                .Configure<Root>(e => rootConfig.Bind(e))
                .Configure<AppConfig>(e=>rootConfig.GetSection("AppConfig").Bind(e));
            using (var sp = services.BuildServiceProvider()) {
                //上面必须进行根节点对象绑定到Root上，不然无法将IOptionsSnapshot<Root>对象通过构造函数注入
                while (true) {
                    //如果此处不进行sp.CreateScope()，即使修改了本地的webconfig.json的内容也无效
                    using (var scope = sp.CreateScope()) {
                        scope.ServiceProvider.GetRequiredService<IController>().ReadAppConfig();
                        scope.ServiceProvider.GetService<AppConfigController>().ShowAppConfigPort();                    
                    }
                    Console.WriteLine("请按任意键继续");
                    Console.ReadKey();
                }             
            }
            //Console.ReadLine();
        }
    }
}
