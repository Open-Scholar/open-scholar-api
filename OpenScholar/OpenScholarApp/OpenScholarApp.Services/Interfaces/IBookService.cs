using OpenScholarApp.Dtos.BookDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooks(int userId);
        Task<BookDto> GetBookById(int id);
        Task AddBook(BookDto addBookDto, int userId);
        Task UpdateBook(UpdateBookDto updateBookDto);
        Task DeleteBook(int id);
    }
}
