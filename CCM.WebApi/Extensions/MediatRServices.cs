using System;
using System.Reflection;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace CCM.WebApi.Extensions
{
    public static class MediatRServices
    {
        internal static void AddMediatRServices(this IServiceCollection services)
        {

            // services.AddMediatR(typeof(  ).GetTypeInfo().Assembly);

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            // services.AddMediatR(Assembly.GetExecutingAssembly());

        }
    }
}