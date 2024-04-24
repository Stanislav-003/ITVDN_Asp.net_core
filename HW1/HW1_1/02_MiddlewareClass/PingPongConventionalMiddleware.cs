using System.Text;

namespace _02_MiddlewareClass
{
    public class PingPongConventionalMiddleware
    {
        private readonly RequestDelegate _next;

        public PingPongConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var responseBytes = Encoding.UTF8.GetBytes("pong");
            await context.Response.Body.WriteAsync(responseBytes);
        }
    }
}
