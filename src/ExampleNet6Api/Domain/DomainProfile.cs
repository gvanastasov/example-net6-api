using AutoMapper;
using example_net6_api.Context.Models;
using example_net6_api.Domain.Responses;

namespace example_net6_api.Domain
{
    public sealed class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}