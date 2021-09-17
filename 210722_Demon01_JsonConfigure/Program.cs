using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _210722_Demon01_JsonConfigure {
    class Program {
        static void Main(string[] args) {
            //固定操作，先new一个ConfigurationBuilder对象，AddJsonFile()方法，对象.Build()
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("webconfig.json", true, true);
            IConfigurationRoot configurationRoot = configurationBuilder.Build();

            AppConfig appConfig = new AppConfig();
            //取子范围的一个元素值
            appConfig.DbConnection = configurationRoot["AppConfig:DbConnection"];
            //取子范围元素值的第二种写法，先获得一个域，域下面的["DbConnection"]
            appConfig.EnableTrace = configurationRoot.GetSection("AppConfig")["EnableTrace"];
            //取数组的写法 取AppConfig:IpWhiteList的全部子元素，选取子元素中的value
            appConfig.IpWhiteList = configurationRoot.GetSection("AppConfig:IpWhiteList").GetChildren().Select(x=>x.Value);
            foreach (var item in appConfig.IpWhiteList) {
                Console.WriteLine(item);
            }

            Student student = new Student();          
            var value = configurationRoot["Student:0:name"];
            Console.WriteLine(value.ToString()); 
            
            Console.ReadLine();
        }
    }

    class AppConfig {
        public string DbConnection { get; set; }
        public string EnableTrace { get; set; }
        public IEnumerable<string> IpWhiteList { get; set; }
    }

    class Student {
        public string Name { get; set; }
        public string Age { get; set; }
    }
}
