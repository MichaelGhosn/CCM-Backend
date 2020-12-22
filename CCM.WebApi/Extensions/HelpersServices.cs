using CCM.Common.Security;
using CCM.Common.Security.Encryption;
using CCM.Common.Security.Tokenizer;
using CCM.Infrastructure.Calendar;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CCM.WebApi.Extensions
{
    public static class HelpersServices
    {
        internal static void AddHelpersServices(this IServiceCollection services)
        {
            services.AddTransient<IHash, BCryptHash>();
            services.AddSingleton<TokenGenerator, JWTTokenGenerator>();
            services.AddScoped<ICalendar, GoogleCalendar>();
        }
    }
}