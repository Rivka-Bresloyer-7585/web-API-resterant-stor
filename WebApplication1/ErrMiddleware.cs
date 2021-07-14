using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace myProject
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ErrMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        //זה הפונקציה שנקראת שאנו פונים לשרת
        public async Task Invoke(HttpContext httpContext,ILogger<ErrMiddleware> logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = 500;
                logger.LogError(ex.Message,ex.StackTrace);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class errMiddlewareExtensions
    {
        public static IApplicationBuilder UserMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrMiddleware>();
        }
    }
}
