using AutoMapper;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.BookRatingDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.BookRatingExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Services.Implementations
{
    //public class BookRatingService : IBookRatingService
    //{
    //    private readonly IBookRatingRepository _bookRatingRepository;
    //    private readonly IMapper _mapper;

    //    public BookRatingService(IBookRatingRepository bookRatingRepository, IMapper mapper)
    //    {
    //        _bookRatingRepository = bookRatingRepository;
    //        _mapper = mapper;
    //    }

    //    public async Task<List<BookRatingDto>> GetAll()
    //    {
    //        var bookRatings = await _bookRatingRepository.GetAll();
    //        return _mapper.Map<List<BookRatingDto>>(bookRatings);
    //    }

    //    public async Task<BookRatingDto> GetById(int id)
    //    {
    //        var bookRating = await _bookRatingRepository.GetById(id);
    //        if (bookRating == null)
    //        {
    //            throw new BookRatingNotFoundException($"BookRating with ID {id} not found.");
    //        }
    //        return _mapper.Map<BookRatingDto>(bookRating);
    //    }

    //    public async Task Add(AddBookRatingDto addDto, string userId)
    //    {
    //        // Ensure that the user can rate a book only once (you may need additional logic here).
    //        var existingRating = await _bookRatingRepository.GetByUserIdAndBookIdAsync(userId, addDto.BookId);
    //        if (existingRating != null)
    //        {
    //            throw new BookRatingInvalidOperationException("User has already rated this book.");
    //        }

    //        var bookRating = _mapper.Map<BookRating>(addDto);
    //        bookRating.UserId = userId;
    //        bookRating.RatedOn = DateTimeOffset.UtcNow;

    //        await _bookRatingRepository.AddAsync(bookRating);
    //        await _bookRatingRepository.SaveChangesAsync();
    //    }

    //    public async Task Update(UpdateBookRatingDto updateDto)
    //    {
    //        var bookRating = await _bookRatingRepository.GetById(updateDto.Id);
    //        if (bookRating == null)
    //        {
    //            throw new BookRatingNotFoundException($"BookRating with ID {updateDto.Id} not found.");
    //        }

    //        // Perform any necessary validation or business logic for updating a rating.
    //        // For example, you can check if the user is allowed to update their own rating.

    //        // Update the rating properties.
    //        bookRating.RatingStars = updateDto.RatingStars;
    //        bookRating.Review = updateDto.Review;

    //        await _bookRatingRepository.SaveChangesAsync();
    //    }

    //    public async Task Delete(int id)
    //    {
    //        var bookRating = await _bookRatingRepository.GetById(id);
    //        if (bookRating == null)
    //        {
    //            throw new BookRatingNotFoundException($"BookRating with ID {id} not found.");
    //        }

    //        // Perform any necessary authorization checks (e.g., if the user is allowed to delete this rating).

    //        _bookRatingRepository.Remove(bookRating);
    //        await _bookRatingRepository.SaveChangesAsync();
    //    }
    //}
}
