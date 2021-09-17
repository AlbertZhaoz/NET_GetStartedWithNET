using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace _210908_Demo01_OtherConfigProvider
{
    public class ConfigContoller : IBinderConfig
    {
        private readonly IOptionsSnapshot<Config> options;

        //DI by ctor.
        public ConfigContoller(IOptionsSnapshot<Config> options)
        {
            this.options = options;
        }

        //options.Value = new Config()
        public void SendEmail()
        {
            Console.WriteLine(
                $"向名字为{options.Value.name}" +
                $"年龄为{options.Value.age},发送电子邮件" +
                $"邮箱地址为{options.Value.proxy.address}" +
                $"邮箱端口号为{options.Value.proxy.port}");
        }
    }
}
