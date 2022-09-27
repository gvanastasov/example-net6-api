//-----------------------------------------------------------------------
// <copyright file="SubscriptionResponse.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Domain.Responses
{
    using ExampleNet6Api.Context.Enums;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// API response model for subscriptions.
    /// </summary>
    public sealed class SubscriptionResponse
    {
        /// <summary>
        /// Gets or sets the unique subscription identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the subscription's activation date.
        /// </summary>
        public DateTime Activated { get; set; }

        /// <summary>
        /// Gets or sets the subscription's deactivation date.
        /// </summary>
        public DateTime? Deactivated { get; set; }

        /// <summary>
        /// Gets or sets subscription's current state.
        /// </summary>
        public SubscriptionState State { get; set; }

        /// <summary>
        /// Gets or sets the payment cycle for the subscription.
        /// </summary>
        public SubscriptionPaymentCycle PaymentCycle { get; set; }

        /// <summary>
        /// Gets or sets the recurring price for the subscription.
        /// </summary>
        public decimal Price { get; set; }
    }
}