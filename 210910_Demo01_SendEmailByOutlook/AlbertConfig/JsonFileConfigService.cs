using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace _210910_Demo01_SendEmailByOutlook.AlbertConfig
{
    public class JsonFileConfigService:IConfigService
    {
        public void EntityToFile()
        {
            var mailBodyEntity = new MailBodyEntity()
            {
                MailBodyType = "Plain",
                MailTextBody = "Hi everyone,this mail is a test mail from albertzhao.",
                Body = "xxxx",
                Recipients = new List<string>() {"2506747342@qq.com","164831638@qq.com"},
                Sender = "AlbertZhao",
                SenderAddress = "szdxzhy@outlook.com",
                Subject = "TestMailKit"
            };
            var sendSereverConfigurationEntity = new SendServerConfigurationEntity()
            {
                SmtpHost = "smtp-mail.outlook.com",
                SmtpPort = 587,
                IsSsl = true,
                SenderAccount = "szdxzhy@outlook.com",
                SenderPassword = "xxx"
            };
            string mailBodyEntityStr = JsonConvert.SerializeObject(mailBodyEntity);
            string sendSereverConfigurationEntityStr = JsonConvert.SerializeObject(sendSereverConfigurationEntity);
            string EntityMailKitRoot = "{\"MailBodyEntity\":" + mailBodyEntityStr + ","
                                       + "\"SendServerConfigurationEntity\":" + sendSereverConfigurationEntityStr
                                       + "}";
            SaveToJsonFile(EntityMailKitRoot);
        }
        
        public static void SaveToJsonFile(string content)
        {
            try
            {
                var configDir = AppDomain.CurrentDomain.BaseDirectory + "DocumentConfig/";
                if (!Directory.Exists(configDir)) Directory.CreateDirectory(configDir);
                var mailConfigPath = configDir  + "mailconfig.json";
                if (File.Exists(mailConfigPath)) File.Delete(mailConfigPath);
                var fs = File.Create(mailConfigPath);
                fs.Close();
                File.WriteAllTextAsync(mailConfigPath,content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public string GetValue(string file)
        {
            return "";
        }
    }
}