using OpenScholarApp.Dtos.BookDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooks();
        Task<BookDto> GetBookById(int id);
        Task AddBook(AddBookDto addBookDto, string userId);
        Task UpdateBook(UpdateBookDto updateBookDto);
        Task DeleteBook(int id);
    }
}
