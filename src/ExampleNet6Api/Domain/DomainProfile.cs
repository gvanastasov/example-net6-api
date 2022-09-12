using AutoMapper;
using Context.Models;
using Domain.Responses;

namespace Domain
{
    public sealed class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}