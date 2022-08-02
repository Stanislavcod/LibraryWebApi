
using Library.Common.ModelsDto;

namespace Library.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(RegisterAndLoginDto registerAndLogin);
        public bool IsUserExists(string name);
    }
}
