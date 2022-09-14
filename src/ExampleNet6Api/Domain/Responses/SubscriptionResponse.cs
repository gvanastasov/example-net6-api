//-----------------------------------------------------------------------
// <copyright file="SubscriptionResponse.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Domain.Responses
{
    /// <summary>
    /// API response model for subscriptions.
    /// </summary>
    public sealed class SubscriptionResponse
    {
        /// <summary>
        /// Gets or sets the unique subscription identifier.
        /// </summary>
        public int Id { get; set; }
    }
}