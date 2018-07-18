using System.Web.Mvc;

namespace Rifa.WEB.Areas.RestrictArea
{
    public class RestrictAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RestrictArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RestrictArea_default",
                "RestrictArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}