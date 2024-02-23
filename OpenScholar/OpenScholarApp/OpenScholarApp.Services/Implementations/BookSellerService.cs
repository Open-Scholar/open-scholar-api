using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.BookSellerDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.BookSellerExceptions;
using OpenScholarApp.Shared.CustomExceptions.BookStoreExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class BookSellerService : IBookSellerService
    {
        private readonly IBookSellerRepository _bookSellerRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookSellerService(IBookSellerRepository bookSellerRepository, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _bookSellerRepository = bookSellerRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response> CreateBookSellerAsync(AddBookSellerDto addDto, string userId)
        {
            try
            {
                var response = new Response();
                var bookSeller = _mapper.Map<BookSeller>(addDto);
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                    return new Response("BookSeller not found!");

                if (user.IsProfileCreated == true)
                    return new Response<AddBookSellerDto>("Account already exists");

                if (user.AccountType != AccountType.BookSeller)
                    return new Response<AddBookSellerDto>("You can only create BookSeller account type");

                bookSeller.User = user;
                bookSeller.ApplicationUserId = userId;
                await _bookSellerRepository.Add(bookSeller);
                user.IsProfileCreated = true;
                await _userManager.UpdateAsync(user);
                response.IsSuccessfull = true;
                return response;
            }
            catch (BookSellerDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the Book Seller: {ex.Message}" } };
            }
        }

        public async Task<Response> DeleteBookSellerAsync(int id)
        {
            try
            {
                var existingBookSeller = await _bookSellerRepository.GetByIdInt(id);
                if (existingBookSeller == null)
                    return new Response() { Errors = new List<string> { $"Book Seller with Id {id} not found" }, IsSuccessfull = false };

                await _bookSellerRepository.RemoveEntirely(existingBookSeller);
                return Response.Success;
            }
            catch (BookSellerDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the Book Seller {ex.Message}" } };
            }
        }

        public async Task<Response<List<BookSellerDto>>> GetAllBookSellersAsync()
        {
            try
            {
                var bookSellers = await _bookSellerRepository.GetAllWithUserAsync();
                var bookSellersDtos = _mapper.Map<List<BookSellerDto>>(bookSellers);
                return new Response<List<BookSellerDto>>() { IsSuccessfull = true, Result = bookSellersDtos };
            }
            catch (BookStoreDataException ex)
            {
                return new Response<List<BookSellerDto>>() { Errors = new List<string> { $"An error occurred while fetching all Book Sellers: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<BookSellerDto>> GetBookSellerAsync(string userId)
        {
            try
            {
                var bookSeller = await _bookSellerRepository.GetByUserIdAsync(userId);
                if (bookSeller == null)
                    return new Response<BookSellerDto>() { Errors = new List<string> { $"Book Seller account not found" }, IsSuccessfull = false };

                var bookSellerDto = _mapper.Map<BookSellerDto>(bookSeller);
                return new Response<BookSellerDto>() { IsSuccessfull = true, Result = bookSellerDto };
            }
            catch (BookSellerDataException ex)
            {
                return new Response<BookSellerDto> { Errors = new List<string> { $"An error occurred while fetching the Book Seller {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateBookSellerAsync(string userId, UpdateBookSellerDto updateBookSellerDto)
        {
            try
            {
                var existingBookSeller = await _bookSellerRepository.GetByUserIdAsync(userId);
                if (existingBookSeller == null)
                    return new Response("Account not found!");

                var updatedBookSeller = _mapper.Map(updateBookSellerDto, existingBookSeller);
                await _bookSellerRepository.Update(updatedBookSeller);
                return new Response<UpdateBookSellerDto> { IsSuccessfull = true, Result = updateBookSellerDto };
            }
            catch (BookSellerDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the Book Seller {ex.Message}" } };
            }
        }
    }
}
