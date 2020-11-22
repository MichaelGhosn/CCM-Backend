using System;
using System.Threading.Tasks;
using CCM.Common.Exceptions;
using Microsoft.AspNetCore.Http;

namespace CCM.WebApi.Middlewares
{
    public class AuthorisationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorisationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            string token = context.Request.Headers["Authorization"];

            //do the checking
            if (token == null && !context.Request.Path.Value.Contains("swagger") && context.Request.Path.Value != "/api/User/authenticate" )
            {
                throw new JwtNotFoundException();
            }

            //pass request further if correct
            await _next(context);
        }
    }
}