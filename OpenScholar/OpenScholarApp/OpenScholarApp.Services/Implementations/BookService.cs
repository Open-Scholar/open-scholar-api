using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.BookDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.Responses;
using OpenScholarApp.Shared.CustomExceptions.BookException;
using OpenScholarApp.Shared.CustomExceptions.UserExceptions;

namespace OpenScholarApp.Services.Implementations
{
    //public class BookService : IBookService
    //{
    //    private readonly IBookRepository _bookRepository;
    //    private readonly UserManager<ApplicationUser> _userManager;
    //    private readonly IMapper _mapper;

    //    public BookService(IBookRepository bookRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
    //    {
    //        _mapper = mapper;
    //        _userManager = userManager;
    //        _bookRepository = bookRepository;
    //    }

    //    public async Task<Response<List<BookDto>>> GetAll()
    //    {
    //        var books = await _bookRepository.GetAll();
    //        var bookDtos = _mapper.Map<List<BookDto>>(books);
    //        return Response<List<BookDto>>.(bookDtos);
    //    }

    //    public async Task<Response<BookDto>> GetById(int id)
    //    {
    //        var book = await _bookRepository.GetByIdInt(id);
    //        if (book == null)
    //        {
    //            return Response<BookDto>.Error($"Book with ID {id} not found.");
    //        }
    //        var bookDto = _mapper.Map<BookDto>(book);
    //        return Response<BookDto>.Success(bookDto);
    //    }

    //    public async Task<Response> Add(AddBookDto addBookDto, string userId)
    //    {
    //        ApplicationUser user = await _userManager.FindByIdAsync(userId.ToString());

    //        if (user == null)
    //        {
    //            return Response.Error($"User with ID {userId} was not found in the database");
    //        }

    //        if (string.IsNullOrEmpty(addBookDto.Title) || string.IsNullOrEmpty(addBookDto.ReleaseDate))
    //        {
    //            return Response.Error("Title and ReleaseDate must not be empty");
    //        }

    //        var newBook = _mapper.Map<Book>(addBookDto);
    //        await _bookRepository.Add(newBook);

    //        return Response.Success();
    //    }

    //    public async Task<Response> Update(UpdateBookDto updateBookDto)
    //    {
    //        var existingBook = await _bookRepository.GetByIdInt(updateBookDto.BookId);

    //        if (existingBook == null)
    //        {
    //            return Response.Error($"Book with ID {updateBookDto.BookId} was not found in the database");
    //        }

    //        _mapper.Map(updateBookDto, existingBook);
    //        await _bookRepository.Update(existingBook);

    //        return Response.Success();
    //    }

    //    public async Task<Response> Delete(int id)
    //    {
    //        var book = await _bookRepository.GetByIdInt(id);
    //        if (book == null)
    //        {
    //            return Response.Error($"Book with ID {id} not found.");
    //        }
    //        await _bookRepository.RemoveEntirely(book);
    //        return Response.Success();
    //    }
    //}
}
