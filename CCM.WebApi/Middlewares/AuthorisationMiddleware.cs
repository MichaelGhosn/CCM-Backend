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
            if (token == null && !context.Request.Path.Value.Contains("swagger") && context.Request.Path.Value != "/api/Users/authenticate" )
            {
                throw new JwtNotFoundException();
            }
            
            // TODO: check that I am the issuer of the token and that it is valid

            //pass request further if correct
            await _next(context);
        }
    }
}