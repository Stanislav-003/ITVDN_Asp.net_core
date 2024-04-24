using System.Text;

namespace _01_PingPong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Use(async (context, next) =>
            {
                Console.WriteLine($"DEBUG: Started handling request: {context.Request.Path}");
                await next();
                Console.WriteLine($"DEBUG: Finished handling request: {context.Request.Path}");
            });

            app.Map("/ping", branch => {

                branch.Map("/one", b => b.Run(async context =>
                {
                    var responseBytes = Encoding.UTF8.GetBytes("pong - one");
                    await context.Response.Body.WriteAsync(responseBytes);
                }));

                branch.Map("/two", b => b.Run(async context =>
                {
                    var responseBytes = Encoding.UTF8.GetBytes("pong - two");
                    await context.Response.Body.WriteAsync(responseBytes);
                }));
            });

            app.Map("/hello", branch => branch.Run(async context =>
            {
                var responseBytes = Encoding.UTF8.GetBytes("Hello World!");
                await context.Response.Body.WriteAsync(responseBytes);
            }));

            app.Run();
        }
    }
}
