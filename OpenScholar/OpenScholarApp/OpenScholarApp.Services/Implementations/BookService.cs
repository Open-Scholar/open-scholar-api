using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.BookDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.BookException;
using OpenScholarApp.Shared.Responses;

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

        public async Task<Response<List<BookDto>>> GetAllBookAsync()
        {
            try
            {
                var books = await _bookRepository.GetAll();
                var bookDtos = _mapper.Map<List<BookDto>>(books);
                return new Response<List<BookDto>>(bookDtos);
            }
            catch (BookNotFoundException e)
            {
                return new Response<List<BookDto>> { Errors = new List<string> { $"An error occurred while fetching the book {e.Message}" } };
            }
        }

        public async Task<Response<BookDto>> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await _bookRepository.GetByIdInt(id);
                if (book == null)
                {
                    return new Response<BookDto>() { Errors = new List<string> { $"Book with Id {id} not found" }, IsSuccessfull = false };
                }
                var bookDto = _mapper.Map<BookDto>(book);
                return new Response<BookDto>() { IsSuccessfull = true, Result = bookDto };
            }
            catch (BookNotFoundException e)
            {
                return new Response<BookDto> { Errors = new List<string> { $"An error occurred while fetching the book {e.Message}" } };
            }
        }

        public async Task<Response> CreateBookAsync(AddBookDto addBookDto, string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(addBookDto.UserId);
                if (user == null)
                    return new Response() { Errors = new List<string> { $"User with ID {userId} was not found in the database"}, IsSuccessfull = false };

                if(user.AccountType != AccountType.Student 
                    || user.AccountType != AccountType.Faculty 
                    || user.AccountType != AccountType.BookSeller 
                    || user.AccountType != AccountType.BookStore 
                    || user.AccountType != AccountType.Professor
                    || user.AccountType != AccountType.SuperAdmin)
                    return new Response<AddBookDto>("Your account type cannot add a book");

                if (string.IsNullOrWhiteSpace(addBookDto.Title) || string.IsNullOrWhiteSpace(addBookDto.ReleaseDate))
                {
                    return new Response<AddBookDto>("Titles must not be empty");
                }

                var book = _mapper.Map<Book>(addBookDto);
                book.User = user;
                await _bookRepository.Add(book);


                return new Response<AddBookDto>($"Book Successfully added: {book}");
                
            }
            catch (BookDataException e)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the book: {e.Message}" } };
            }
        }

        public async Task<Response> UpdateBookAsync(int id, UpdateBookDto updateBookDto)
        {
            try
            {
                var response = new Response();
                var existingBook = await _bookRepository.GetByIdInt(id);

                if (existingBook == null)
                {
                    response.IsSuccessfull = false;
                    response.Errors = new List<string>() { ($"Book with ID {id} not found.") };
                    return response;
                }

                await _bookRepository.Update(existingBook);
                return response;
            }
            catch (BookDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the Book {ex.Message}" } };
            }
        }

        public async Task<Response> DeleteBookAsync(int id)
        {
            try
            {
                var book = await _bookRepository.GetByIdInt(id);
                if (book == null)
                {
                    return new Response() { Errors = new List<string> { $"Book with Id {id} not found" }, IsSuccessfull = false };
                }
                await _bookRepository.RemoveEntirely(book);
                return Response.Success;
            }
            catch (BookDataException e)
            {
                return new Response { Errors = new List<string> { $"An error occurred while Deleting the book: {e.Message}" } };
            }
            
        }
    }
}
