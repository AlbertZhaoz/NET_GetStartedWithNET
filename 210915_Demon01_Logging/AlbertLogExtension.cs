using _210915_Demon01_Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemService;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AlbertLogExtension
    {
        public static void AddAlbertLog(this IServiceCollection service)
        {
            //service.AddScoped<IAlbertLog,EmailLog>();
            service.AddScoped<IAlbertLog,CalculateLog>();
        }
    }
}
