
using Library.Common.ModelsDto;

namespace Library.BusinessLogic.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDto> Get();
        void AddAll();
    }
}
