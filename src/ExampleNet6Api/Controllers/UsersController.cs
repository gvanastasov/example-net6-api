//-----------------------------------------------------------------------
// <copyright file="UsersController.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Controllers
{
    using AutoMapper;

    using ExampleNet6Api.Context;
    using ExampleNet6Api.Context.Repositories.Interfaces;
    using ExampleNet6Api.Domain.Responses;

    using Microsoft.AspNetCore.Mvc;

    using static ExampleNet6ApiInfrastructure.ApiMeta.Documentation;
    using static ExampleNet6ApiInfrastructure.ApiMeta.Versions;

    /// <summary>
    /// Controller for user related requests.
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = v1)]
    [ApiVersion(v1_0)]
    [Route("v1.0/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit of work.</param>
        /// <param name="mapper">Mapper.</param>
        public UsersController(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        /// <summary>
        /// GET: /users
        /// handles users read query.
        /// </summary>
        /// <returns>A collection of all users.</returns>
        [HttpGet("")]
        public IEnumerable<UserResponse> Get()
        {
            var users = this._unitOfWork.UserRepository.GetAll();
            return this._mapper.Map<IEnumerable<UserResponse>>(users);
        }

        /// <summary>
        /// GET: /users/{id}
        /// handles user with specified id read query.
        /// </summary>
        /// <param name="id">User unique identifier.</param>
        /// <returns>User based on id.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(string id)
        {
            var user = this._unitOfWork.UserRepository.GetByID(id);

            if (user == null)
            {
                return this.NotFound();
            }

            var response = this._mapper.Map<UserResponse>(user);
            return this.Ok(response);
        }
    }
}