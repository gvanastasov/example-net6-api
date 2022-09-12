using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Extensions
{
    public static class MvcOptionsExtension 
    {
        public static void UseGlobalRoutePrefix (this MvcOptions options, IRouteTemplateProvider routeAttribute) 
        {
            options.Conventions.Insert (0, new RouteConvention (routeAttribute));
        }
    }
}