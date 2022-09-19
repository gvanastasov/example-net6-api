//-----------------------------------------------------------------------
// <copyright file="ISubscriptionRepository.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Repositories.Interfaces
{
    using ExampleNet6Api.Context.Models;

    /// <summary>
    /// Subscription entity repository.
    /// </summary>
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
    }
}