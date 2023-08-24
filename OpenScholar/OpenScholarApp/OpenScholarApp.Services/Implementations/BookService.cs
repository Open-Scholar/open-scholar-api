using OpenScholarApp.Dtos.BookDto;
using OpenScholarApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Services.Implementations
{
    public class BookService : IBookService
    {
        public Task AddReminder(AddBookDto addBookDto, int userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookDto>> GetAllReminders(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetReminderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBook(UpdateBookDto updateBookDto)
        {
            throw new NotImplementedException();
        }
    }
}
