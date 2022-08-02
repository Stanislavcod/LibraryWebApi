
using AutoMapper;
using Library.BusinessLogic.Interfaces;
using Library.Common.ModelsDto;
using Library.Model.DataBaseContext;
using Library.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationContext _context;

        public UserService(IMapper mapper, ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public UserDto Get(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var userDto = _mapper.Map<User, UserDto>(user);
            return userDto;
        }
        public IEnumerable<UserDto> Get()
        {
            var users = _context.Users.AsNoTracking().ToList();
            var usersDto = _mapper.Map<List<User>,List<UserDto>>(users);
            return usersDto;
        }
        public void Deleted(int id)
        {
            var user = _context.Users.FirstOrDefault(x=> x.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public void Update(UserDto userDto)
        {
            _mapper.Map<UserDto>(userDto);
            _context.SaveChanges();
        }
        public User Get(string name) =>
            _context.Users.FirstOrDefault(u => u.Name == name.ToLower())!;
    }
}
