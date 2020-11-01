using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgencyMVCWebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AgencyMVCWebApp.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class DbInitializerMiddleware
    {
        private readonly RequestDelegate _next;

        public DbInitializerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, courseworkDbContext db)
        {
            if (!(httpContext.Session.Keys.Contains("starting")))
            {
                InitializeDb.Initialize(db);
                httpContext.Session.SetString("starting", "Yes");
            }
            return _next.Invoke(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DbInitializerMiddlewareExtensions
    {
        public static IApplicationBuilder UseDbInitializerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbInitializerMiddleware>();
        }
    }
}
