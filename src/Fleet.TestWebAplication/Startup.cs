
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fleet.TestWebAplication
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            this.SetUpRoutes(app);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        private void SetUpRoutes(IApplicationBuilder app)
        {
            var routeBuilder = new RouteBuilder(app);

            routeBuilder.MapGet("users", context =>
            {
                var testModule = new TestModule();
                return testModule.GetUsers(context);
            });

            routeBuilder.MapGet("users/{name:alpha}", context =>
            {
                var testModule = new TestModule();
                return testModule.GetUserProfile(context);
            });

            routeBuilder.MapPost("users", context =>
            {
                var testModule = new TestModule();
                return testModule.CreateUser(context);
            });

            routeBuilder.MapPut("users", context =>
            {
                var testModule = new TestModule();
                return testModule.UpdateUser(context);
            });

            routeBuilder.MapDelete("users/{id:int}", context =>
            {
                var testModule = new TestModule();
                return testModule.RemoveUser(context);
            });

            var routes = routeBuilder.Build();
            app.UseRouter(routes);
        }
    }
}