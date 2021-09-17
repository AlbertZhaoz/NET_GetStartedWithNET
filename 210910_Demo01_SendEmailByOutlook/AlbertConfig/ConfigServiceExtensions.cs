using System;
using System.Collections.Generic;
using System.Text;
using _210910_Demo01_SendEmailByOutlook.AlbertConfig;

namespace Microsoft.Extensions.DependencyInjection {
    public static class ConfigServiceExtensions {
        public static void AddConfigService(this IServiceCollection services) {
            services.AddScoped<IConfigService,IniFileConfigService>();
        }
    }
}
