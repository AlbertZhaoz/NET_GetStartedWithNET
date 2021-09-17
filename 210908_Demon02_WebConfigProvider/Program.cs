using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _210908_Demon02_WebConfigProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceCollection();
            service.AddScopeConfig();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddFxConfig("web.config");
            var root = builder.Build();

            service.AddOptions().Configure<WebConfig>(e => root.Bind(e));

            using (var sp = service.BuildServiceProvider())
            {
                sp.GetRequiredService<IBinderConfig>().SendEmail();
            }
        }
    }
}
