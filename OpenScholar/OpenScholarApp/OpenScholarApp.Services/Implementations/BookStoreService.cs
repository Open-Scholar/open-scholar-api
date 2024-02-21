using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Implementations;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.BookStoreDto;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.BookStoreExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class BookStoreService : IBookStoreService
    {
        private readonly IBookStoreRepository _bookStoreRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookStoreService(IBookStoreRepository bookStoreRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _bookStoreRepository = bookStoreRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response> CreateBookStoreAsync(AddBookStoreDto addDto, string userId)
        {
            try
            {
                var response = new Response();
                var bookStore = _mapper.Map<BookStore>(addDto);
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    throw new BookStoreDataException("BookStore not found");

                if (user.IsProfileCreated == true)
                    return new Response<AddBookStoreDto>("Account already exists");

                if (user.AccountType != AccountType.BookStore)
                    return new Response<AddBookStoreDto>("You can only create Book Store account type");

                bookStore.User = user;
                bookStore.ApplicationUserId = userId;
                await _bookStoreRepository.Add(bookStore);
                user.IsProfileCreated = true;
                await _userManager.UpdateAsync(user);
                response.IsSuccessfull = true;
                return response;
            }
            catch (BookStoreDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the book store: {ex.Message}" } };
            }
        }

        public async Task<Response> DeleteBookStoreAsync(int id)
        {
            try
            {
                var existingBookStore = await _bookStoreRepository.GetByIdInt(id);

                if (existingBookStore == null)
                {
                    return new Response() { Errors = new List<string> { $"Book Store with Id {id} not found" }, IsSuccessfull = false };
                }

                await _bookStoreRepository.RemoveEntirely(existingBookStore);
                return Response.Success;
            }
            catch (BookStoreDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the Book Store {ex.Message}" } };
            }
        }

        public async Task<Response<List<BookStoreDto>>> GetAllBookStoresAsync()
        {
            try
            {
                var bookStores = await _bookStoreRepository.GetAllWithUserAsync();
                var bookStoresDtos = _mapper.Map<List<BookStoreDto>>(bookStores);
                return new Response<List<BookStoreDto>>() { IsSuccessfull = true, Result = bookStoresDtos };
            }
            catch (BookStoreDataException ex)
            {
                return new Response<List<BookStoreDto>>() { Errors = new List<string> { $"An error occurred while fetching all BookStores: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<BookStoreDto>> GetBookStoreAsync(string userId)
        {
            try
            {
                var bookStore = await _bookStoreRepository.GetByUserIdAsync(userId);
                if (bookStore == null)
                {
                    return new Response<BookStoreDto>() { Errors = new List<string> { $"Bookstore account not found" }, IsSuccessfull = false };
                }

                var bookStoreDto = _mapper.Map<BookStoreDto>(bookStore);
                return new Response<BookStoreDto>() { IsSuccessfull = true, Result = bookStoreDto };
            }
            catch (BookStoreDataException ex)
            {
                return new Response<BookStoreDto> { Errors = new List<string> { $"An error occurred while fetching the Book Store {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateBookStoreAsync(string userId, UpdateBookStoreDto updateBookStoreDto)
        {
            try
            {
                var existingBookStore = await _bookStoreRepository.GetByUserIdAsync(userId);

                if (existingBookStore == null)
                {
                    return new Response("BookStore not found!");
                }
                var updatedProfessor = _mapper.Map(updateBookStoreDto, existingBookStore);

                var result = _bookStoreRepository.Update(updatedProfessor);
                return new Response<UpdateBookStoreDto> { IsSuccessfull = true, Result = updateBookStoreDto };
            }
            catch (BookStoreDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the Book Store {ex.Message}" } };
            }
        }
    }
}
