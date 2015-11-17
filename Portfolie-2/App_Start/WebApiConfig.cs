using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Portfolie_2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "PostApi",
                routeTemplate: "api/posts/{id}",
                defaults: new { controller = "Post", id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "SearchApi",
                routeTemplate: "api/search/{inputString}",
                defaults: new { controller = "Search", inputString = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "UserApi",
                routeTemplate: "api/users/{id}",
                defaults: new { controller = "User", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "CommentApi",
                routeTemplate: "api/comments/{id}",
                defaults: new { controller = "Comment", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "TagApi",
                routeTemplate: "api/tags/{id}",
                defaults: new { controller = "Tag", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "TiApi",
                routeTemplate: "api/ti/{tid}",
                defaults: new { controller = "Ti", tid = RouteParameter.Optional }
            );
        }
    }
}
