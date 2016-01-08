using System.Web.Http;

namespace FourthWall.Server
{
    public class Routes
    {
        public static void Register(HttpRouteCollection target)
        {
            target.MapHttpRoute("Home", "", new {controller = "Home", action = "index"}, new {});
            target.MapHttpRoute("Content", "Content/{*path}", new {controller = "Content", action = "index"}, new {});
            target.MapHttpRoute("Default", "{controller}/{action}", new {controller = "Home", action = "index"}, new {});
        }
    }
}