
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Fleet.TestWebAplication
{
    public class TestModule
    {
        public Task GetUsers(HttpContext context)
        {
            return context.Response.WriteAsync("user");
        }
        public Task GetUserProfile(HttpContext context)
        {
            var name = context.GetRouteValue("name");
            return context.Response.WriteAsync($"Hi, {name}!");
        }

        public Task CreateUser(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status201Created;
            return context.Response.WriteAsync("user has been created");
        }

        public Task UpdateUser(HttpContext context)
        {
            return context.Response.WriteAsync("user has been updated");
        }
    }
}