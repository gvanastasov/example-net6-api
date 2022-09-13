//-----------------------------------------------------------------------
// <copyright file="UsersController.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6ApiControllers
{
    using AutoMapper;
    using ExampleNet6ApiContext.Repositories.Interfaces;
    using ExampleNet6ApiDomain.Responses;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="userRepository">User repository.</param>
        /// <param name="mapper">Mapper.</param>
        public UsersController(
            IUserRepository userRepository,
            IMapper mapper)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// GET request handler for route /users.
        /// </summary>
        /// <returns>A collection of all users.</returns>
        [HttpGet("")]
        public IEnumerable<UserResponse> Get()
        {
            var users = this._userRepository.GetUsers();
            return this._mapper.Map<IEnumerable<UserResponse>>(users);
        }
    }
}