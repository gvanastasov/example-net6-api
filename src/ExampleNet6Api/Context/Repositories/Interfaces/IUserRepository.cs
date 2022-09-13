//-----------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6ApiContext.Repositories.Interfaces
{
    using ExampleNet6ApiContext.Models;

    /// <summary>
    /// User repository.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>List of users.</returns>
        public List<User> GetUsers();
    }
}