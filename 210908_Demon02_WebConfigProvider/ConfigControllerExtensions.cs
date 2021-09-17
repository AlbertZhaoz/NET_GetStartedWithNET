using _210908_Demon02_WebConfigProvider;

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
