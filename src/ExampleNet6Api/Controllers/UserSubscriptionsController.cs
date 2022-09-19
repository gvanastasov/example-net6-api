//-----------------------------------------------------------------------
// <copyright file="UserSubscriptionsController.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Controllers
{
    using AutoMapper;

    using ExampleNet6Api.Context.Repositories.Interfaces;
    using ExampleNet6Api.Domain.Responses;

    using Microsoft.AspNetCore.Mvc;

    using static ExampleNet6ApiInfrastructure.ApiMeta.Documentation;
    using static ExampleNet6ApiInfrastructure.ApiMeta.Versions;

     /// <summary>
    /// Controller for subscription related requests.
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = v1)]
    [ApiVersion(v1_0)]
    [Route("v1.0/users/{id}")]
    public sealed class UserSubscriptionsController : ControllerBase
    {
    }
}