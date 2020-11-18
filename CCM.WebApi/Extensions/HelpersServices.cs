using CCM.Common.Security;
using CCM.Common.Security.Encryption;
using Microsoft.Extensions.DependencyInjection;

namespace CCM.WebApi.Extensions
{
    public static class HelpersServices
    {
        internal static void AddHelpersServices(this IServiceCollection services)
        {
            services.AddTransient<IHash, BCryptHash>();
        }
    }
}