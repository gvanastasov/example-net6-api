//-----------------------------------------------------------------------
// <copyright file="User.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Models
{
    /// <summary>
    /// User data model.
    /// </summary>
    public class User
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
    }
}