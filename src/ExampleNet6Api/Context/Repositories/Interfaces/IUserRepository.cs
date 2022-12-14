//-----------------------------------------------------------------------
// <copyright file="IUserRepository.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Repositories.Interfaces
{
    using ExampleNet6Api.Context.Models;

    /// <summary>
    /// User entity repository.
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
    }
}