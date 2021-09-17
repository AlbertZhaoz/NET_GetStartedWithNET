using _210720_Demon03_ConfigServiceDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection {
    public static class ConfigServiceExtensions {
        public static void AddConfigService(this IServiceCollection services) {
            services.AddScoped<IConfigService,IniFileConfigService>();
        }
    }
}
