namespace _02_MiddlewareClass
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Map("/ping", branch => {
                branch.UseMiddleware<PingPongConventionalMiddleware>();
                //branch.UseMiddleware<PingPongFactoryBasedMiddleware>();
                //branch.UsePingPongFactoryBased(); 
                //branch.UsePingPongConventional(); 
            });

            app.Run();
        }
    }
}
