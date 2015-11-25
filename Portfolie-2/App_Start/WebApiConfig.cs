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

            /*A request comes in. 
              System pattern matches according to the following templates of mapped routes.
              A route is a set of instructions on how to take a URI coming into a request.
              It is mapped to some code, typically a controller.
            */
            config.Routes.MapHttpRoute(
                name: "PostApi",
                routeTemplate: "api/posts/{id}/{sesUserId}",
                defaults: new { controller = "Post", id = RouteParameter.Optional, sesUserId = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "SearchApi",
                routeTemplate: "api/search/{searchString}/{sesUserId}",
                defaults: new { controller = "Search", searchString = RouteParameter.Optional, sesUserId = RouteParameter.Optional }
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
                name: "FavoriteApi",
                routeTemplate: "api/Favorites/{userId}/{postId}/{annotation}",
                defaults: new { controller = "Favorite",
                                userId = RouteParameter.Optional,
                                postId = RouteParameter.Optional,
                                annotation = RouteParameter.Optional
                                
                }
            );

            config.Routes.MapHttpRoute(
                name: "SearchHistoryApi",
                routeTemplate: "api/SearchHistory/{userId}",
                defaults: new
                {
                    controller = "SearchHistory",
                    userId = RouteParameter.Optional
                }
            );
        }
    }
}
