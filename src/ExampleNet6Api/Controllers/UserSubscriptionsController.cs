//-----------------------------------------------------------------------
// <copyright file="UserSubscriptionsController.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Controllers
{
    using AutoMapper;

    using ExampleNet6Api.Context;
    using ExampleNet6Api.Context.Models;
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
    [Route("v1.0/users/{userId}/subscriptions")]
    public sealed class UserSubscriptionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserSubscriptionsController"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit of work.</param>
        /// <param name="mapper">Mapper.</param>
        public UserSubscriptionsController(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        /// <summary>
        /// GET: /users/{userId}/subscriptions
        /// handles user's subscription read query.
        /// </summary>
        /// <param name="userId">User unique identifier.</param>
        /// <returns>A collection of user related subscriptions.</returns>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SubscriptionResponse>))]
        public IEnumerable<SubscriptionResponse> Get([FromRoute]int userId)
        {
            var subscriptions = this.GetUserSubscriptions(userId);
            return this._mapper
                .Map<IEnumerable<SubscriptionResponse>>(subscriptions);
        }

        /// <summary>
        /// GET: /users/{userId}/subscriptions/{subscriptionId}
        /// handles user's specific subscription read query.
        /// </summary>
        /// <param name="userId">User unique identifier.</param>
        /// <param name="subscriptionId">Subscription unique identifier.</param>
        /// <returns>A specific user subscription.</returns>
        [HttpGet("{subscriptionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubscriptionResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get([FromRoute]int userId, [FromRoute]int subscriptionId)
        {
            var subscription = this.GetUserSubscriptions(userId)
                .FirstOrDefault(x => x.Id == subscriptionId);

            if (subscription == null)
            {
                return this.NotFound();
            }

            var response = this._mapper.Map<SubscriptionResponse>(subscription);
            return this.Ok(response);
        }

        private IEnumerable<Subscription> GetUserSubscriptions(int userId)
        {
            return this._unitOfWork
                            .SubscriptionRepository
                                .GetAll(x => x.UserId == userId);
        }
    }
}