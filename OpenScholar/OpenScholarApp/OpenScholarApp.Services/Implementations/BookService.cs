using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.BookDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Services.Implementations
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        public async Task AddBook(BookDto BookDto, int userId)
        {

            Book newBook = BookDto.ToBook();
            await _bookRepository.Add(newBook);
            
            //User userDb = await _userRepository.GetById(userId);
            //if (userDb == null)
            //{
            //    Log.Logger.Error($"The user id entered {userId} was not found entered by");
            //    throw new UserNotFoundException($"User with id {userId} was not found in the database.");
            //}
            //if (string.IsNullOrEmpty(addReminderDto.ReminderTitle))
            //{
            //    throw new ReminderDataException($"Reminder Title must not be empty!");
            //}
            //if (string.IsNullOrEmpty(addReminderDto.ReminderTime))
            //{
            //    throw new ReminderDataException($"Reminder Time must not be empty!");
            //}
            //if (string.IsNullOrEmpty(addReminderDto.ReminderDate))
            //{
            //    throw new ReminderDataException($"Reminder Date must not be empty!");
            //}
            //Reminder newReminder = addReminderDto.ToReminder();
            //newReminder.UserId = userId;
            //Log.Logger.Information($"User {userDb.Username} added the reminder {newReminder.ReminderTitle}");
            //await _reminderRepository.Add(newReminder);
        }

        public Task DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BookDto>> GetAllBooks(int userId = 1)
        {
            throw new NotImplementedException();

            //List<Book> booksDb = await _bookRepository.GetAll();

            //List<BookDto> booksDto = booksDb.Where(x => x.UserId == userId).Select(s => s.ToReminderDto()).ToList();
            //return remindersDto;
        }

        public Task<BookDto> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBook(UpdateBookDto updateBookDto)
        {
            throw new NotImplementedException();
        }
    }
}
