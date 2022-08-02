
using Library.Common.ModelsDto;
using Library.Model.Models;

namespace Library.BusinessLogic.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(int id);
    }
}
