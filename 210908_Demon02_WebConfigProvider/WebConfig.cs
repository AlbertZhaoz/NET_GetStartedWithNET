using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210908_Demon02_WebConfigProvider {
    public class WebConfig {
        public ConnectStrings Albert1 { get; set; }
        public ConnectStrings Albert2 { get; set; }
        public Config Config { get; set; }
    }

    public class ConnectStrings {
        public string ConnectString { get; set; }
        public string providerName { get; set; }
    }

    public class Config {
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string age { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Proxy proxy { get; set; }
    }

    public class Proxy {
        /// <summary>
        /// 
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string port { get; set; }
    }
}
