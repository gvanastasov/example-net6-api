//-----------------------------------------------------------------------
// <copyright file="SubscriptionRepository.cs" company="n/a">
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
    public sealed class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionRepository"/> class.
        /// </summary>
        /// <param name="context">Data context.</param>
        public SubscriptionRepository(DataContext context)
            : base(context)
        {
        }
    }
}