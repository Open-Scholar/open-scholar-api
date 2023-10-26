using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
                var user = await _userManager.FindByIdAsync(addDto.UserId);
                if (user == null)
                    throw new BookStoreDataException("BookStore not found");

                if (user.IsProfileCreated == true)
                    return new Response<AddStudentDto>("Account already exists");

                if (user.AccountType != AccountType.BookStore)
                    return new Response<AddStudentDto>("You can only create Book Store account type");

                bookStore.User = user;
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

        public async Task<Response<BookStoreDto>> GetBookStoreByIdAsync(int id)
        {
            try
            {
                var bookStore = await _bookStoreRepository.GetByIdInt(id);
                if (bookStore == null)
                {
                    return new Response<BookStoreDto>() { Errors = new List<string> { $"BookStore with Id {id} not found" }, IsSuccessfull = false };
                }

                var bookStoreDto = _mapper.Map<BookStoreDto>(bookStore);
                return new Response<BookStoreDto>() { IsSuccessfull = true, Result = bookStoreDto };
            }
            catch (BookStoreDataException ex)
            {
                return new Response<BookStoreDto> { Errors = new List<string> { $"An error occurred while fetching the Book Store {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateBookStoreAsync(int id, UpdateBookStoreDto updateDto)
        {
            try
            {
                var response = new Response();
                var existingBookStore = await _bookStoreRepository.GetByIdInt(id);

                if (existingBookStore == null)
                {
                    response.IsSuccessfull = false;
                    response.Errors = new List<string>() { ($"Book Store with ID {id} not found.") };
                    return response;
                }

                await _bookStoreRepository.Update(existingBookStore);
                return response;
            }
            catch (BookStoreDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the Book Store {ex.Message}" } };
            }
        }
    }
}
