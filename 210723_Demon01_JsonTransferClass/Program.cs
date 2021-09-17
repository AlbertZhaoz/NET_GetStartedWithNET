using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace _210723_Demon01_JsonTransferClass {
    class Program {
        static void Main(string[] args) {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("webconfig.json", false, true);
            var configurationRoot = configurationBuilder.Build();
                  
            //绑定一个对象来进行转换
            Root root = configurationRoot.Get<Root>();
            AppConfig appConfig = configurationRoot.GetSection("AppConfig").Get<AppConfig>();
            Console.WriteLine(appConfig.DbConnection);

            Console.ReadLine();
        }
    }

    public class AppConfig {
        /// <summary>
        /// 
        /// </summary>
        public string DbConnection { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EnableTrace { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> IpWhiteList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ServiceName { get; set; }
    }

    public class StudentItem {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int age { get; set; }
    }

    public class TeacherItem {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int age { get; set; }
    }

    public class Root {
        /// <summary>
        /// 
        /// </summary>
        public AppConfig AppConfig { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<StudentItem> Student { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TeacherItem> Teacher { get; set; }
    }
}
