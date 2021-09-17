using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210907_Demo01_OterConfigProvider
{
    public class TestController: IController
    {
        private readonly IOptionsSnapshot<Root> options;
        public TestController(IOptionsSnapshot<Root> options)
        {
            this.options = options;
        }

        public void PrintImformation()
        {
            //如果这里传入的是Root,而不进行扁平化配置就会报null
            Console.WriteLine($"邮箱地址为：{options.Value.proxy.address}" +
                $"；邮箱端口号为：{options.Value.proxy.port}");
        }
    }
}
