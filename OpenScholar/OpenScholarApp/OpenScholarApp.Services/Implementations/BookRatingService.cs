using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.BookDto;
using OpenScholarApp.Dtos.BookRatingDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.BookException;
using OpenScholarApp.Shared.CustomExceptions.BookRatingExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class BookRatingService : IBookRatingService
    {
        private readonly IBookRatingRepository _bookRatingRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IBookRepository _BookRepository;

        public BookRatingService(IBookRepository bookRepository, IBookRatingRepository bookRatingRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _bookRatingRepository = bookRatingRepository;
            _BookRepository = bookRepository;
        }

        public async Task<Response<List<BookRatingDto>>> GetAllBookRatingsAsync()
        {
            try
            {
                var bookRatings = await _bookRatingRepository.GetAllWithUserAndBookAsync();
                var bookDtos = _mapper.Map<List<BookRatingDto>>(bookRatings);
                return new Response<List<BookRatingDto>>(bookDtos);
            }
            catch (BookRatingDataException e)
            {
                return new Response<List<BookRatingDto>> { Errors = new List<string> { $"An error occurred while fetching the Book Rating {e.Message}" } };
            }
        }

        public async Task<Response<BookRatingDto>> GetBookRatingByIdAsync(int id)
        {
            try
            {
                var bookRating = await _bookRatingRepository.GetByIdInt(id);
                if (bookRating == null)
                {
                    return new Response<BookRatingDto>() { Errors = new List<string> { $"Book Rating with Id {id} not found" }, IsSuccessfull = false };
                }
                var bookRatingDto = _mapper.Map<BookRatingDto>(bookRating);
                return new Response<BookRatingDto>() { IsSuccessfull = true, Result = bookRatingDto };
            }
            catch (BookNotFoundException e)
            {
                return new Response<BookRatingDto> { Errors = new List<string> { $"An error occurred while fetching the Book Rating {e.Message}" } };
            }
        }

        public async Task<Response> CreateBookRatingAsync(AddBookRatingDto addBookRatingDto, string userId, int bookId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(addBookRatingDto.UserId);
                var book = await _BookRepository.GetByIdInt(bookId);
                if (user == null)
                    return new Response() { Errors = new List<string> { $"User with ID {userId} was not found in the database" }, IsSuccessfull = false };

                var bookRating = _mapper.Map<BookRating>(addBookRatingDto);
                bookRating.User = user;
                bookRating.Book = book;
                await _bookRatingRepository.Add(bookRating);
                return new Response<AddBookRatingDto>($"Rating Successfully added: {bookRating}");
            }
            catch (BookDataException e)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the book: {e.Message}" } };
            }
        }

        public async Task<Response> UpdateBookRatingAsync(UpdateBookRatingDto updateDto, int id, int bookId)
        {
            try
            {
                var response = new Response();
                var existingBookRating = await _bookRatingRepository.GetByIdInt(id);

                if (existingBookRating == null)
                {
                    response.IsSuccessfull = false;
                    response.Errors = new List<string>() { ($"Book with ID {id} not found.") };
                    return response;
                }

                await _bookRatingRepository.Update(existingBookRating);
                return response;
            }
            catch (BookRatingDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the Book {ex.Message}" } };
            }
        }

        public async Task<Response> DeleteBookRatingAsync(int id)
        {
            try
            {
                var bookRating = await _bookRatingRepository.GetByIdInt(id);
                if (bookRating == null)
                {
                    return new Response() { Errors = new List<string> { $"Book with Id {id} not found" }, IsSuccessfull = false };
                }
                await _bookRatingRepository.RemoveEntirely(bookRating);
                return Response.Success;
            }
            catch (BookRatingDataException e)
            {
                return new Response { Errors = new List<string> { $"An error occurred while Deleting the book: {e.Message}" } };
            }

        }

       
    }
}
