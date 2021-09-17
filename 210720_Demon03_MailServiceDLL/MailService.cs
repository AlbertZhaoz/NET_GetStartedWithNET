using System;
using _210720_Demon03_ConfigServiceDLL;
using _210720_Demon03_LogServiceDLL;

namespace _210720_Demon03_MailServiceDLL {
    public class MailService : IMailService {
        private readonly IConfigService config;
        private readonly ILogService log;

        public MailService(IConfigService config, ILogService log) {
            this.config = config;
            this.log = log;
        }

        public void Send(string iniPath,string body) {
            //开始发送
            Console.WriteLine("开始发送");
            //开始记录日志：开始发送
            log.LogInfo("开始发送");
            //从配置文件读取发送的邮箱信息
            string value = config.GetValue(iniPath);
            log.LogInfo(value);
            Console.WriteLine($"邮箱地址:{value}");
            //向emailAddress地址发送body
            log.LogInfo($"邮箱地址：{value},内容为{body}");
            Console.WriteLine($"邮箱地址：{value},内容为{body}");
            //发送完成
            Console.WriteLine("发送完成");
            log.LogInfo("发送完成");
        }
    }
}
