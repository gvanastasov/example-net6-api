using example_net6_api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace example_net6_api.Extensions
{
    public static class MvcOptionsExtension 
    {
        public static void UseGlobalRoutePrefix (this MvcOptions options, IRouteTemplateProvider routeAttribute) 
        {
            options.Conventions.Insert (0, new RouteConvention (routeAttribute));
        }
    }
}