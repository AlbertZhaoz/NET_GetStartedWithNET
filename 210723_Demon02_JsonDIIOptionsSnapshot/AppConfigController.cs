using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _210723_Demon02_JsonDIIOptionsSnapshot {
    public class AppConfigController {
        public readonly IOptionsSnapshot<AppConfig> optionsSnapshot;

        public AppConfigController(IOptionsSnapshot<AppConfig> optionsSnapshot) {
            this.optionsSnapshot = optionsSnapshot;
        }

        public void ShowAppConfigPort() {
            Console.WriteLine(this.optionsSnapshot.Value.Port);
        }

    }
}
