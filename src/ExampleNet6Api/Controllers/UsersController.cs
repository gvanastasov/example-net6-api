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
        /// handles user read related requestions.
        /// </summary>
        /// <returns>A collection of all users.</returns>
        [HttpGet("")]
        public IEnumerable<UserResponse> Get()
        {
            var users = this._unitOfWork.UserRepository.GetAll();
            return this._mapper.Map<IEnumerable<UserResponse>>(users);
        }
    }
}