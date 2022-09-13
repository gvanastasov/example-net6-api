//-----------------------------------------------------------------------
// <copyright file="ApiMeta.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6ApiInfrastructure
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// API meta data.
    /// </summary>
    [SuppressMessage(
        "Naming",
        "CA1707:Identifiers should not contain underscores.",
        Justification = "Need a delimiter for version constants naming.")]
    [SuppressMessage(
        "Naming",
        "SA1303:The name of a constant C# field should begin with an upper-case letter.",
        Justification = "Better readability on version abbrs.")]
    [SuppressMessage(
        "Naming",
        "SA1310:A field name in C# contains an underscore.",
        Justification = "Better readability on version abbrs.")]
    public static class ApiMeta
    {
        /// <summary>
        /// Versioning meta.
        /// </summary>
        public static class Versions
        {
            /// <summary>
            /// Version 1.0.
            /// </summary>
            public const string v1_0 = "1.0";
        }

        /// <summary>
        /// Documentation meta.
        /// </summary>
        public static class Documentation
        {
            /// <summary>
            /// Version one.
            /// </summary>
            public const string v1 = "v1";
        }
    }
}