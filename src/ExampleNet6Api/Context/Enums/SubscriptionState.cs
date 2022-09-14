//-----------------------------------------------------------------------
// <copyright file="SubscriptionState.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Context.Enums
{
    /// <summary>
    /// Subscription state.
    /// </summary>
    public enum SubscriptionState
    {
        /// <summary>
        /// Default state of subscription.
        /// </summary>
        Active,

        /// <summary>
        /// Temporary suspended, due to technical (ex. payment failure) or user
        /// decision based reason.
        /// </summary>
        Suspended,

        /// <summary>
        /// Permanently canceled.
        /// </summary>
        Canceled,
    }
}