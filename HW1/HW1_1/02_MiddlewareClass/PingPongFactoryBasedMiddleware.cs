using System.Text;

namespace _02_MiddlewareClass
{
    class PingPongFactoryBasedMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var responseBytes = Encoding.UTF8.GetBytes("pong");
            await context.Response.Body.WriteAsync(responseBytes);
        }
    }
}
