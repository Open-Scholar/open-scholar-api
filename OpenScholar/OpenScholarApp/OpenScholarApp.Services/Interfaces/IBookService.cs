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
        Task<List<BookDto>> GetAllReminders(int userId);
        Task<BookDto> GetReminderById(int id);
        Task AddReminder(AddBookDto addBookDto, int userId);
        Task UpdateBook(UpdateBookDto updateBookDto);
        Task DeleteBook(int id);
    }
}
