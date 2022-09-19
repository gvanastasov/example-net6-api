//-----------------------------------------------------------------------
// <copyright file="UnitOfWork.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context
{
    using ExampleNet6Api.Context.Repositories;
    using ExampleNet6Api.Context.Repositories.Interfaces;

    /// <summary>
    /// Main entry point for context interaction, that ensure
    /// a single database context instance is used.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataContext _context;
        private bool disposed;
        private IUserRepository? _userRepository;
        private ISubscriptionRepository? _subscriptionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">Data context.</param>
        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets user repository.
        /// </summary>
        public IUserRepository UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(this._context);
                }

                return this._userRepository;
            }
        }

        /// <summary>
        /// Gets subscription repository.
        /// </summary>
        public ISubscriptionRepository SubscriptionRepository
        {
            get
            {
                if (this._subscriptionRepository == null)
                {
                    this._subscriptionRepository = new SubscriptionRepository(this._context);
                }

                return this._subscriptionRepository;
            }
        }

        /// <summary>
        /// Saves changes to data context, aka. transaction submit.
        /// </summary>
        public void Save()
        {
            this._context.SaveChanges();
        }

        /// <summary>
        /// Callback when releasing this instance allocated resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Ensure that context's release of resources, happens before
        /// we destroy/release this instance.
        /// </summary>
        /// <param name="disposing">Flag for current object resource allocation state.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}