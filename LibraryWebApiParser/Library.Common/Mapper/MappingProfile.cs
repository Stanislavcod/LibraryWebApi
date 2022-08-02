
using AutoMapper;
using Library.Common.ModelsDto;
using Library.Model.Models;

namespace Library.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterAndLoginDto>().ReverseMap();
            CreateMap<List<User>,List<UserDto>>().ReverseMap();
        }
    }
}
