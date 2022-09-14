//-----------------------------------------------------------------------
// <copyright file="User.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Models
{
    using System.Globalization;

    using ExampleNet6Api.Infrastructure;

    /// <summary>
    /// User data model.
    /// </summary>
    public class User
    {
        private ICollection<Subscription>? _subscriptions;

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
        /// Gets or sets user's owned subscriptions.
        /// </summary>
        public virtual ICollection<Subscription> Subscriptions
        {
            get =>
                this._subscriptions
                ?? throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        ErrorMessages.UninitializedProperty,
                        nameof(this.Subscriptions)));
            set => this._subscriptions = value;
        }
    }
}