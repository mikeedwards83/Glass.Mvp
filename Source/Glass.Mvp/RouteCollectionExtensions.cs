using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace Glass.Mvp
{
    public static class RouteCollectionExtensions
    {

        public static Route MapDefault(this RouteCollection routes)
        {
            var route = MapRoute(routes, "default", "{*url}", null, null, null);
            routes.Remove(route);
            routes.Insert(0,route );
            return route;
        }

        //Taken from System.Web.Mvc.RouteCollectionExtensions
        public static Route MapRoute(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
                throw new ArgumentNullException("routes");
            if (url == null)
                throw new ArgumentNullException("url");
            Route route = new Route(url, (IRouteHandler)new MvpRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };
            if (namespaces != null && namespaces.Length > 0)
                route.DataTokens["Namespaces"] = (object)namespaces;
            routes.Add(name, (RouteBase)route);
            return route;
        }
    }
}
