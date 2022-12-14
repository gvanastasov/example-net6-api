//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Repositories
{
    using ExampleNet6Api.Context.Models;
    using ExampleNet6Api.Context.Repositories.Interfaces;

    /// <summary>
    /// User repository implementation.
    /// </summary>
    public sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">Data context.</param>
        public UserRepository(DataContext context)
            : base(context)
        {
        }
    }
}