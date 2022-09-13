//-----------------------------------------------------------------------
// <copyright file="DomainProfile.cs" company="n/a">
//  No rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace ExampleNet6ApiDomain
{
    using AutoMapper;
    using ExampleNet6ApiContext.Models;
    using ExampleNet6ApiDomain.Responses;

    /// <summary>
    /// Mapping register for domain models.
    /// </summary>
    public sealed class DomainProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainProfile"/> class.
        /// </summary>
        public DomainProfile()
        {
            this.CreateMap<User, UserResponse>();
        }
    }
}