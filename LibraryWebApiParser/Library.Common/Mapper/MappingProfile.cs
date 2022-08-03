
using AutoMapper;
using Library.Common.ModelsDto;
using Library.Model.Models;
using System.Security.Cryptography;
using System.Text;

namespace Library.Common.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var hmac = new HMACSHA256();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterAndLoginDto>().ReverseMap().ForMember("PasswordHash", opt => opt.MapFrom(opt => hmac.ComputeHash(Encoding.UTF8.GetBytes(opt.Password))))
    .ForMember("PasswordSalt", opt => opt.MapFrom(opt => hmac.Key)); ;
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
