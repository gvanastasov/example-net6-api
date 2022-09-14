//-----------------------------------------------------------------------
// <copyright file="SubscriptionPaymentCycle.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Enums
{
    /// <summary>
    /// Describes the payment cycle for the subscription.
    /// </summary>
    public enum SubscriptionPaymentCycle
    {
        /// <summary>
        /// Subscription is paid for on monthly basis.
        /// </summary>
        Monthly,

        /// <summary>
        /// Subscription is paid for on yearly basis.
        /// </summary>
        Yearly,
    }
}