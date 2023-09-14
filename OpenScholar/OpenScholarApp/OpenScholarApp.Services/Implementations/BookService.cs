using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.BookDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.BookException;
using OpenScholarApp.Shared.CustomExceptions.UserExceptions;

namespace OpenScholarApp.Services.Implementations
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _bookRepository = bookRepository;
        }


        public async Task Add(AddBookDto addBookDto, string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new UserNotFoundException($"user with id {userId} was not found in the Database");
            }
            if(string.IsNullOrEmpty(addBookDto.Title))
            {
                throw new BookDataException($"Field {addBookDto.Title} must not be empty");
            }
            if (string.IsNullOrEmpty(addBookDto.ReleaseDate))
            {
                throw new BookDataException($"Field {addBookDto.ReleaseDate} must not be empty");
            }
            if (string.IsNullOrEmpty(addBookDto.Title))
            {
                throw new BookDataException($"Field {addBookDto.Title} must not be empty");
            }
            if (string.IsNullOrEmpty(addBookDto.Title))
            {
                throw new BookDataException($"Field {addBookDto.Title} must not be empty");
            }
            var newBook = _mapper.Map<Book>(addBookDto);
            await _bookRepository.Add(newBook);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookDto>> GetAll()
        {
            throw new NotImplementedException();

            //List<Book> booksDb = await _bookRepository.GetAll();

            //List<BookDto> booksDto = booksDb.Where(x => x.UserId == userId).Select(s => s.ToReminderDto()).ToList();
            //return remindersDto;
        }

        public Task<BookDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateBookDto updateBookDto)
        {
            throw new NotImplementedException();
        }
    }
}
