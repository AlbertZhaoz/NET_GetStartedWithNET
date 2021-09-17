using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace _210908_Demo01_OtherConfigProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            //new collection container
            var services = new ServiceCollection();
            services.AddScopeConfig();
            //ConfigurationBuilder
            var configBuilder = new ConfigurationBuilder();
            //如果使用带参数的，如configBuilder.AddEnvironmentVariables("Albert_"）
            //则需要在环境变量中添加前缀，防止修改全局的环境变量
            configBuilder.AddEnvironmentVariables();
            //将从环境变量中拿到的东西变成根节点对象
            var configurationRoot = configBuilder.Build();

            //将config绑定到根节点，将proxy绑定到proxy类上
            services.AddOptions().Configure<Config>(e => configurationRoot.Bind(e))
                .Configure<Proxy>(e => configurationRoot.GetSection("proxy").Bind(e));

            using (var sp = services.BuildServiceProvider())
            {
                sp.GetRequiredService<IBinderConfig>().SendEmail();
            }
            Console.ReadLine();
        }
    }
}
