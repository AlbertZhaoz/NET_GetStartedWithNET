using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210723_Demon02_JsonDIIOptionsSnapshot {
    class TestController : IController {
        public readonly IOptionsSnapshot<Root> optionsSnapshot;

        public TestController(IOptionsSnapshot<Root> optionsSnapshot) {
            this.optionsSnapshot = optionsSnapshot;
        }

        public void ReadAppConfig() {      
            Console.WriteLine(optionsSnapshot.Value.AppConfig.ServiceName);
        }

    }
}
