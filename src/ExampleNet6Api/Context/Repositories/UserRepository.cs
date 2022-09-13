//-----------------------------------------------------------------------
// <copyright file="UserRepository.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6ApiContext.Repositories
{
    using ExampleNet6ApiContext.Models;
    using ExampleNet6ApiContext.Repositories.Interfaces;

    /// <summary>
    /// User repository implementation.
    /// </summary>
    public sealed class UserRepository : IUserRepository
    {
        private readonly ApiContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="db">Application data context.</param>
        public UserRepository(ApiContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<User> GetUsers()
        {
            var users = this.db.Users.ToList();
            return users;
        }
    }
}