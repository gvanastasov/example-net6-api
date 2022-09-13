//-----------------------------------------------------------------------
// <copyright file="RouteConvention.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6ApiInfrastructure
{
    using Microsoft.AspNetCore.Mvc.ApplicationModels;
    using Microsoft.AspNetCore.Mvc.Routing;

    /// <summary>
    /// Application customization that applies route convention, which prefixes
    /// all routes with a custom route segment(s).
    /// </summary>
    public class RouteConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel _globalPrefix;

        /// <summary>
        /// Initializes a new instance of the <see cref="RouteConvention"/> class.
        /// </summary>
        /// <param name="routeTemplateProvider">Route template provider.</param>
        public RouteConvention(IRouteTemplateProvider routeTemplateProvider)
        {
            this._globalPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        /// <summary>
        /// Appends prefix to all routes in the application.
        /// </summary>
        /// <param name="application">Application.</param>
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var matchedSelectors = controller.Selectors
                        .Where(x => x.AttributeRouteModel != null).ToList();
                if (matchedSelectors.Any())
                {
                    foreach (var selectorModel in matchedSelectors)
                    {
                        selectorModel.AttributeRouteModel = AttributeRouteModel
                            .CombineAttributeRouteModel(
                                this._globalPrefix,
                                selectorModel.AttributeRouteModel);
                    }
                }
            }
        }
    }
}