//-----------------------------------------------------------------------
// <copyright file="UserEntityConfiguration.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Configuration
{
    using ExampleNet6Api.Context.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Configures EF <see cref="User"/>.
    /// </summary>
    public sealed class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Seeds fake data.
        /// </summary>
        /// <param name="builder">User entity type builder.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasData(GenerateFakeUsers());
        }

        private static IEnumerable<User> GenerateFakeUsers()
        {
            for (int i = 1; i <= 10; i++)
            {
                yield return new User
                {
                    Id = i,
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                };
            }
        }
    }
}