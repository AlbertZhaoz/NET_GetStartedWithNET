using _210720_Demon03_MailServiceDLL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection {
    public static class MailServiceExtensions {
        public static void AddMailService(this IServiceCollection services) {
            services.AddScoped<IMailService,MailService>();
        }
    }
}
