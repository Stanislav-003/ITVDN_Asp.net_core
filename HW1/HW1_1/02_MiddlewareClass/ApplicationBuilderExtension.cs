using Microsoft.AspNetCore.Builder;

namespace _02_MiddlewareClass
{
    static class ApplicationBuilderExtension 
    {
        public static IApplicationBuilder UsePingPongFactoryBased(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<PingPongFactoryBasedMiddleware>();
        }
        public static IApplicationBuilder UsePingPongConventional(this IApplicationBuilder app)
        {
            return app.UseMiddleware<PingPongConventionalMiddleware>();
        }
    }
}
