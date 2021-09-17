using _210910_Demo01_SendEmailByOutlook;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MailServiceExtensions
    {
        public static void AddMailService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMailService, MailService>();
        }
    }
}