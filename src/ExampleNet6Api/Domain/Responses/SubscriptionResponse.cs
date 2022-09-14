//-----------------------------------------------------------------------
// <copyright file="SubscriptionResponse.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Domain.Responses
{
    using System.Text.Json.Serialization;
    using ExampleNet6Api.Context.Enums;

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
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime Activated { get; set; }

        /// <summary>
        /// Gets or sets the subscription's deactivation date.
        /// </summary>
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? Deactivated { get; set; }

        /// <summary>
        /// Gets or sets subscription's current state.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SubscriptionState State { get; set; }

        /// <summary>
        /// Gets or sets the payment cycle for the subscription.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SubscriptionPaymentCycle PaymentCycle { get; set; }

        /// <summary>
        /// Gets or sets the recurring price for the subscription.
        /// </summary>
        public decimal Price { get; set; }
    }
}