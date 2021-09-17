using _210723_Demon02_JsonDIIOptionsSnapshot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection {
    public static class TestControllerExtensions {
        public static void AddTestController(this IServiceCollection service) {
            service.AddScoped<IController, TestController>();
        }
    }
}
