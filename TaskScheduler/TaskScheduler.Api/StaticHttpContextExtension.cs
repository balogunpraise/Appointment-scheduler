using System.Web;

namespace TaskScheduler.Api
{
    public static class StaticHttpContextExtension
    {
        public static void AddCustomHttpContextAccessor(this IServiceCollection service) 
        { 
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static IApplicationBuilder UseStaticHttpContext(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            System.Web.HttpContext.Configure(httpContextAccessor);
            return app;
        }
    }
}
