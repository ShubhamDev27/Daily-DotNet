using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
namespace MVCdemo1
{
    public class CustomMiddlewareDemo : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello from Custom Middleware");

            await next(context);
        }
    }
}
