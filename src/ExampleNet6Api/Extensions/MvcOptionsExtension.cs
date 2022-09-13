//-----------------------------------------------------------------------
// <copyright file="MvcOptionsExtension.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6ApiExtensions
{
    using ExampleNet6ApiInfrastructure;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;

    /// <summary>
    /// Extension to MVC middleware.
    /// </summary>
    public static class MvcOptionsExtension
    {
        /// <summary>
        /// Prepends a global route prefix.
        /// </summary>
        /// <param name="options">Current instance of <see cref="MvcOptions"/>.</param>
        /// <param name="routeAttribute">Route segments to prepend.</param>
        public static void UseGlobalRoutePrefix(
            this MvcOptions options, IRouteTemplateProvider routeAttribute)
        {
            options.Conventions.Insert(
                0,
                new RouteConvention(
                    routeAttribute));
        }
    }
}