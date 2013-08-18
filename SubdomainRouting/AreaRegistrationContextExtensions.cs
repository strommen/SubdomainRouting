using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SubdomainRouting
{
    public static class AreaRegistrationContextExtensions
    {
        private class SubDomainRoute : Route
        {
            private readonly string area;
            private readonly string subdomain;

            public SubDomainRoute(string area, string subdomain, string url, IRouteHandler routeHandler)
                : base(url, routeHandler)
            {
                this.area = area;
                this.subdomain = subdomain;
            }

            public override RouteData GetRouteData(HttpContextBase httpContext)
            {
                var url = httpContext.Request.Headers["HOST"];

                if (url.StartsWith(this.subdomain + "."))
                {
                    var route = base.GetRouteData(httpContext);

                    // The route URLs do not include the area, so we have to add it to these dictionaries ourselves.
                    route.Values["area"] = this.area;
                    route.DataTokens["area"] = this.area;

                    // As a convenience for other code to check the subdomain if necessary, it to the DataTokens dictionary
                    route.DataTokens["subdomain"] = this.subdomain;

                    return route;
                }
                else
                {
                    return null;
                }
            }
        }

        public static Route MapSubDomainRoute(this AreaRegistrationContext context, string name, string subdomain, string url, object defaults, object constraints = null)
        {
            Route route = new SubDomainRoute(context.AreaName, subdomain, url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints)
            };

            route.DataTokens = new RouteValueDictionary();
            route.DataTokens["area"] = context.AreaName;
            route.DataTokens["namespaces"] = context.Namespaces.ToArray();
            context.Routes.Add(name, route);

            return route;
        }
    }
}