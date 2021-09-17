using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210723_Demon02_JsonDIIOptionsSnapshot {
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
}
