//-----------------------------------------------------------------------
// <copyright file="AccountEntityConfiguration.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Configuration
{
    using ExampleNet6Api.Context.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Configures EF <see cref="Account"/>.
    /// </summary>
    public sealed class AccountEntityConfiguration : IEntityTypeConfiguration<Account>
    {
        /// <summary>
        /// Seeds fake data.
        /// </summary>
        /// <param name="builder">User entity type builder.</param>
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasData(GenerateFakeAccounts());
        }

        private static IEnumerable<Account> GenerateFakeAccounts()
        {
            for (int i = 1; i <= 10; i++)
            {
                yield return new Account
                {
                    Id = i,
                    Number = Guid.NewGuid().ToString(),
                    UserId = i,
                };
            }
        }
    }
}