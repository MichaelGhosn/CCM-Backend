using Microsoft.AspNetCore.Builder;

namespace CCM.WebApi.Middlewares
{
    public static class AuthorisationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthorisationMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorisationMiddleware>();
        }
    }
}