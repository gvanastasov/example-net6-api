//-----------------------------------------------------------------------
// <copyright file="SubscriptionEntityConfiguration.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Configuration
{
    using ExampleNet6Api.Context.Enums;
    using ExampleNet6Api.Context.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Configures EF <see cref="Subscription"/>.
    /// </summary>
    public sealed class SubscriptionEntityConfiguration : IEntityTypeConfiguration<Subscription>
    {
        private const decimal MonthlySubscriptionPrice = 99.0m;

        private static decimal YearlySubscriptionPrice
        {
            get => MonthlySubscriptionPrice * 12;
        }

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
                var state = Faker.Enum.Random<SubscriptionState>();
                var activated = Faker.RandomNumber.Next(5, 100);
                var paymentCycle = Faker.Enum.Random<SubscriptionPaymentCycle>();

                yield return new Subscription
                {
                    Id = i,
                    UserId = Faker.RandomNumber.Next(1, 10),
                    Activated = DateTime.Now.AddDays(-activated),
                    Deactivated = state == SubscriptionState.Active
                        ? null
                        : DateTime.Now.AddDays(-Faker.RandomNumber.Next(1, activated - 1)),
                    PaymentCycle = paymentCycle,
                    State = state,
                    Price = paymentCycle == SubscriptionPaymentCycle.Monthly
                        ? MonthlySubscriptionPrice
                        : YearlySubscriptionPrice,
                };
            }
        }
    }
}