
namespace Library.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt);
        public bool IsUserExists(string name);
    }
}
