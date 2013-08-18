using System.Web.Mvc;

namespace SubdomainRouting.Areas.Area2
{
    public class Area2AreaAreaRegistration : AreaRegistration 
	{
        public override string AreaName 
		{
            get 
			{
                return "Area2";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
		{
            context.MapSubDomainRoute(
                name: "Area2_default",
                subdomain: "subdomain2",
                // Note that "Area2" is *not* in the route url
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}