using _210908_Demon02_WebConfigProvider;

namespace Microsoft.Extensions.Configuration
{
    public  static class FxConfigExtensions
    {
        public static void AddFxConfig(this IConfigurationBuilder builder, string path)
        {
            builder.Add(new FxConfigSource() {Path = path});
        }
    }
}