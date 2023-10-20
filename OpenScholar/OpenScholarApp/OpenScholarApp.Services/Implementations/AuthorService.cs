using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Implementations;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.AuthorDto;
using OpenScholarApp.Dtos.StudentDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.AuthorExceptions;
using OpenScholarApp.Shared.CustomExceptions.StudentExceptions;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IMapper _mapper;
        private readonly IAuthorRepository _authorRepository;
        //private readonly Boo
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorService(IMapper mapper, IAuthorRepository authorRepository, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _authorRepository = authorRepository;
            _userManager = userManager;
        }

        public async Task<Response> CreateAuthorAsync(AddAuthorDto addDto, string userId)
        {
            try
            {
                var response = new Response();
                var author = _mapper.Map<Author>(addDto);
                var user = await _userManager.FindByIdAsync(addDto.UserId);
                if (user == null)
                    return new Response<AddAuthorDto>(" User not found");

                var bookPublisher = author.Book.User;
                if (bookPublisher.Id != userId)
                    return new Response<AddAuthorDto>("You do not have permission to change the author of this book");

                author.UserId = user.Id;
                await _authorRepository.Add(author);
                response.IsSuccessfull = true;
                return response;
            }
            catch (AuthorDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while creating the student: {ex.Message}" } };
            }
        }

        public async Task<Response> DeleteAuthorAsync(int id, string userId)
        {
            try
            {
                var existingAuthor = await _authorRepository.GetByIdInt(id);

                if (existingAuthor == null)
                {
                    return new Response() { Errors = new List<string> { $"Author with Id {id} not found" }, IsSuccessfull = false };
                }

                await _authorRepository.RemoveEntirely(existingAuthor);
                return Response.Success;
            }
            catch (AuthorDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while deleting the Author {ex.Message}" } };
            }
        }

        public async Task<Response<List<AuthorDto>>> GetAllAuthorsAsync()
        {
            try
            {
                var authors = await _authorRepository.GetAllWithBookAsync();
                var authorDtos = _mapper.Map<List<AuthorDto>>(authors);
                return new Response<List<AuthorDto>>() { IsSuccessfull = true, Result = authorDtos};
            }
            catch (AuthorDataException ex)
            {
                return new Response<List<AuthorDto>>() { Errors = new List<string> { $"An error occurred while fetching all authors: {ex.Message}" }, IsSuccessfull = false };
            }
        }

        public async Task<Response<AuthorDto>> GetAuthorByIdAsync(int id)
        {
            try
            {
                var author = await _authorRepository.GetByIdInt(id);
                if (author == null)
                {
                    return new Response<AuthorDto>() { Errors = new List<string> { $"Author with Id {id} not found" }, IsSuccessfull = false };
                }

                var authorDto = _mapper.Map<AuthorDto>(author);
                return new Response<AuthorDto>() { IsSuccessfull = true, Result = authorDto};
            }
            catch (AuthorDataException ex)
            {
                return new Response<AuthorDto> { Errors = new List<string> { $"An error occurred while fetching the author {ex.Message}" } };
            }
        }

        public async Task<Response> UpdateAuthorAsync(int id, UpdateAuthorDto updateDto, string userId)
        {
            try
            {
                var response = new Response();
                var existingAuthor = await _authorRepository.GetByIdInt(id);

                if (existingAuthor == null)
                {
                    response.IsSuccessfull = false;
                    response.Errors = new List<string>() { ($"Author with ID {id} not found.") };
                    return response;
                }

                await _authorRepository.Update(existingAuthor);
                return response;
            }
            catch (AuthorDataException ex)
            {
                return new Response { Errors = new List<string> { $"An error occurred while updating the author {ex.Message}" } };
            }
        }
    }
}
