using AutoMapper;
using TriMania.Application.UserContext.Queries.ListUsers;
using TriMania.Domain.User;

namespace TriMania.Application.Mappings
{
    public class UserRegistrationToUserMappingProfile : Profile
    {
        public UserRegistrationToUserMappingProfile()
        {
            _ = CreateMap<UserDto, User>().ReverseMap();
            _ = CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}