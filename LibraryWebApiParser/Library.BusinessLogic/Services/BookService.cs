
using AutoMapper;
using Book.Parser;
using Library.BusinessLogic.Interfaces;
using Library.Common.ModelsDto;
using Library.Model.DataBaseContext;
using Library.Model.Models;

namespace Library.BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly Parser _parser;
        private readonly IMapper _mapper;

        public BookService(Parser parser,ApplicationContext applicationContext, IMapper mapper)
        {
            _parser = parser;
            _applicationContext = applicationContext;
            _mapper = mapper;
        }
        public IEnumerable<BookDto> Get()
        {
            var book = _applicationContext.Books.ToList();
            var bookDto = _mapper.Map<List<BookDto>>(book);
            return bookDto;
        }

        public void AddAll()
        {
            var bookList = _parser.GetBook();

            foreach (var book in bookList)
            {
                BookDto bookDto = new();
                bookDto.Title = book;
                var mapBook = _mapper.Map<BookDto>(book);
            }
        }
    }
}
