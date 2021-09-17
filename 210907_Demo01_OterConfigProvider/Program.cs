using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _210907_Demo01_OterConfigProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            //依赖注入 new ServiceCollection
            var services = new ServiceCollection();
            //AddScope或其他
            services.AddTestConrollerScope();
            //new ConfigurationBuilder
            var configurationBuilder = new ConfigurationBuilder();
            //传入命令行参数
            configurationBuilder.AddCommandLine(args);
            var configurationRoot = configurationBuilder.Build();

            services.AddOptions()
                .Configure<Root>(e => configurationRoot.Bind(e))
                .Configure<Proxy>(e => configurationRoot.GetSection("proxy").Bind(e));

            using (var sp =services.BuildServiceProvider())
            {
                //要特别注意，关于可选项，在IOptionsSnapshot<T>,这个T如果是根类型，
                //它里面还有其他子类型的属性，如果不进行初始设置就会报错，null类型（
                //强行在方法里面获取的话）
                sp.GetRequiredService<IController>().PrintImformation();
            }
            Console.ReadLine();
        }
    }
}
