//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Repositories
{
    using ExampleNet6Api.Context.Models;
    using ExampleNet6Api.Context.Repositories.Interfaces;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// User repository implementation.
    /// </summary>
    public sealed class UserRepository : IUserRepository
    {
        private readonly DataContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="db">Application data context.</param>
        public UserRepository(DataContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<User> GetUsers()
        {
            var users = this.db.Users.Include(x => x.Subscriptions).ToList();
            return users;
        }
    }
}