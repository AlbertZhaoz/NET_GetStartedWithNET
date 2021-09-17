using Microsoft.Extensions.DependencyInjection;
using System;

namespace _210720_Demon02_InfectDI {
    class Program {
        static void Main(string[] args) {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<Controller>();
            services.AddScoped<ILog,LogImp>();
            services.AddScoped<IConfig,ConfigImp>();
            services.AddScoped<ICloud, CloudImp>();

            using (var sp = services.BuildServiceProvider()) {
                var controller = sp.GetRequiredService<Controller>();
                controller.Test();
            }

            Console.ReadLine();
        }
    }

    class Controller {
        private readonly ILog log;
        private readonly ICloud cloud;
        public Controller(ILog log, ICloud cloud) {
            this.log = log;
            this.cloud = cloud;
        }

        public void Test() {
            this.log.Log("开始上传");
            this.cloud.Save(".NET第一行代码", "albert.txt");
            this.log.Log("上传完毕");
        }
    }

    interface ILog {
        public void Log(string msg);
    }

    interface IConfig {
        public string GetValue(string name);
    }

    interface ICloud {
        public void Save(string content, string name);
    }

    class LogImp : ILog {
        public void Log(string msg) {
            Console.WriteLine($"日志:{msg}");
        }
    }

    class ConfigImp : IConfig {
        public string GetValue(string server) {
            return $"返回服务名为{server}";
        }
    }

    class CloudImp : ICloud {
        private readonly IConfig config;
        public CloudImp(IConfig config) {
            this.config = config;
        }
        public void Save(string content, string name) {
            string server = config.GetValue("albert_server");
            Console.WriteLine($"向服务{server}中上传的内容为{content},内容保存在{name}文件下");
        }
    }
}
