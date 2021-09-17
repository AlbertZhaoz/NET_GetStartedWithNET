using _210908_Demo01_OtherConfigProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigControllerExtensions
    {
        public static void AddScopeConfig(this IServiceCollection servive)
        {
            servive.AddScoped<IBinderConfig, ConfigContoller>();
        }
    }
}
