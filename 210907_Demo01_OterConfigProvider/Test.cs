using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210907_Demo01_OterConfigProvider
{
    public class Root
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
}
