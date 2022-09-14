//-----------------------------------------------------------------------
// <copyright file="ErrorMessages.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6Api.Infrastructure
{
    /// <summary>
    /// Error template messages.
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// Error message thrown usually when accessing a
        /// property that is not initialized by the context,
        /// for example navigational properties.
        /// </summary>
        public const string UninitializedProperty = "Uninitialized property: {0}";
    }
}