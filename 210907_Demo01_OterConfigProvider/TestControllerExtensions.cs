using _210907_Demo01_OterConfigProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TestControllerExtensions
    {
        public static void AddTestConrollerScope(this IServiceCollection services)
        {
            services.AddScoped<IController, TestController>();
        }
    }
}
    
