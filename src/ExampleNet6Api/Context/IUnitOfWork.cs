//-----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context
{
    using ExampleNet6Api.Context.Repositories.Interfaces;

    /// <summary>
    /// Main entry point for context interaction, that ensure
    /// a single database context instance is used.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets user repository.
        /// </summary>
        IUserRepository UserRepository { get; }

        /// <summary>
        /// Gets subscription repository.
        /// </summary>
        ISubscriptionRepository SubscriptionRepository { get; }

        /// <summary>
        /// Saves changes to data context, aka. transaction submit.
        /// </summary>
        void Save();
    }
}