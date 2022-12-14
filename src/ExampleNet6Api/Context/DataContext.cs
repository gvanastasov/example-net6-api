//-----------------------------------------------------------------------
// <copyright file="DataContext.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context
{
    using ExampleNet6Api.Context.Configuration;
    using ExampleNet6Api.Context.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Application data context.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        /// <param name="options">Configuration options.</param>
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets users dataset.
        /// </summary>
        public DbSet<User> Users => this.Set<User>();

        /// <summary>
        /// Gets subscriptions dataset.
        /// </summary>
        public DbSet<Subscription> Subscriptions => this.Set<Subscription>();

        /// <summary>
        /// Gets accounts dataset.
        /// </summary>
        public DbSet<Account> Accounts => this.Set<Account>();

        /// <summary>
        /// Callback before sets are initialized.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AccountEntityConfiguration());
        }
    }
}