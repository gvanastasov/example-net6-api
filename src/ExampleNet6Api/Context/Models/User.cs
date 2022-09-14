//-----------------------------------------------------------------------
// <copyright file="User.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using ExampleNet6Api.Infrastructure;

    /// <summary>
    /// User data model.
    /// </summary>
    public class User
    {
        private ICollection<Subscription>? _subscriptions;

        private Account? _account;

        /// <summary>
        /// Gets or sets the unique user identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets user's first name.
        /// </summary>
        [Required]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Gets or sets user's last name.
        /// </summary>
        [Required]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Gets or sets user's registration email.
        /// </summary>
        [Required]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value indicating whether user's profile state is active.
        /// Data is kept for specific timespan compliant with GDRP, before
        /// completelly erased from the system.
        /// </summary>
        public bool IsActive { get; set; }

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

        /// <summary>
        /// Gets or sets user's billing account.
        /// </summary>
        public virtual Account Account
        {
            get =>
                this._account
                ?? throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        ErrorMessages.UninitializedProperty,
                        nameof(this.Account)));
            set => this._account = value;
        }
    }
}