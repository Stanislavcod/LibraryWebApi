
using Library.Common.ModelsDto;
using Library.Model.Models;

namespace Library.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        UserDto Get(int id);
        IEnumerable<UserDto> Get();
        void Deleted (int id);
        void Update(UserDto user);
        User Get(string name);
    }
}
