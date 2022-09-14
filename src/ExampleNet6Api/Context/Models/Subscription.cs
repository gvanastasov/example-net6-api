//-----------------------------------------------------------------------
// <copyright file="Subscription.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Models
{
    using System.Globalization;

    using ExampleNet6Api.Infrastructure;

    /// <summary>
    /// Subscription data model.
    /// </summary>
    public class Subscription
    {
        private User? _user;

        /// <summary>
        /// Gets or sets the unique subscription identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets foreign key for owner reference.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the owner of this subscription.
        /// </summary>
        public virtual User User
        {
            get =>
                this._user
                ?? throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        ErrorMessages.UninitializedProperty,
                        nameof(this.User)));
            set => this._user = value;
        }
    }
}