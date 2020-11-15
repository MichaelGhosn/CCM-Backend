using System.Configuration;
using CCM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CCM.WebApi.Extensions
{
    public static class DBContextService
    {
        internal static void AddCcmDbContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ccmContext>(opt =>  opt.UseMySQL(configuration.GetConnectionString("DefaultConnection")));
           
        }
    }
}