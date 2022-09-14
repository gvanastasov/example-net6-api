//-----------------------------------------------------------------------
// <copyright file="UserResponse.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Domain.Responses
{
    /// <summary>
    /// API response model for users.
    /// </summary>
    public sealed class UserResponse
    {
        /// <summary>
        /// Gets or sets the unique user identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets user's first name.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets user's last name.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets user's registration email.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether user's profile state is active.
        /// Data is kept for specific timespan compliant with GDRP, before
        /// completelly erased from the system.
        /// </summary>
        public bool IsActive { get; set; }
    }
}