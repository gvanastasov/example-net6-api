//-----------------------------------------------------------------------
// <copyright file="SubscriptionEntityConfiguration.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Configuration
{
    using ExampleNet6Api.Context.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Configures EF <see cref="Subscription"/>.
    /// </summary>
    public sealed class SubscriptionEntityConfiguration : IEntityTypeConfiguration<Subscription>
    {
        /// <summary>
        /// Seeds fake data.
        /// </summary>
        /// <param name="builder">User entity type builder.</param>
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder
                .HasData(GenerateFakeSubscriptions());
        }

        private static IEnumerable<Subscription> GenerateFakeSubscriptions()
        {
            for (int i = 1; i <= 100; i++)
            {
                yield return new Subscription
                {
                    Id = i,
                    UserId = Faker.RandomNumber.Next(1, 10),
                };
            }
        }
    }
}