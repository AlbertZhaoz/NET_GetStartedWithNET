using _210720_Demon03_LogServiceDLL;
using System;
using System.Collections.Generic;
using System.Text;

//这里需要注意此处的namespace和DI的相同
namespace Microsoft.Extensions.DependencyInjection {
    public static class LogServiceExtensions {
        public static void AddLogService(this IServiceCollection services) {
            services.AddScoped<ILogService,TxtLogService>();
        }
    }
}
