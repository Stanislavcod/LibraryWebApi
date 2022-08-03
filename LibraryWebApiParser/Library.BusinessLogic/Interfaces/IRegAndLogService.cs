

using Library.Common.ModelsDto;

namespace Library.BusinessLogic.Interfaces
{
    public interface IRegAndLogService
    {
        bool Register(RegisterAndLoginDto registerDto);
        UserDto Login(RegisterAndLoginDto loginDto);
    }
}
