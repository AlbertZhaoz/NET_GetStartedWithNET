using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210908_Demo01_OtherConfigProvider
{
    public class Proxy
    {
        /// <summary>
        /// 
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string port { get; set; }
    }

    public class Config
    {
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

}
