using System;
using Microsoft.Extensions.Options;

namespace _210908_Demon02_WebConfigProvider
{
    public class ConfigContoller : IBinderConfig
    {
        private readonly IOptionsSnapshot<WebConfig> options;

        //DI by ctor.
        public ConfigContoller(IOptionsSnapshot<WebConfig> options)
        {
            this.options = options;
        }

        //options.Value = new Config()
        public void SendEmail()
        {
            Console.WriteLine(
                $"向名字为{options.Value.Config.name}" +
                $"年龄为{options.Value.Config.age},发送电子邮件" +
                $"邮箱地址为{options.Value.Config.proxy.address}" +
                $"邮箱端口号为{options.Value.Config.proxy.port}");
        }
    }
}
