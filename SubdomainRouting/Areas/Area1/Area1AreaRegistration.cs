using System.Web.Mvc;

using SubdomainRouting;

namespace SubdomainRouting.Areas.Area1
{
    public class Area1AreaAreaRegistration : AreaRegistration 
	{
        public override string AreaName 
		{
            get 
			{
                return "Area1";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
		{
            context.MapSubDomainRoute(
                name: "Area1_default",
                subdomain: "subdomain1",
                // Note that "Area1" is *not* in the route url
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}