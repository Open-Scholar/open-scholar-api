using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.AuthorDto;
using OpenScholarApp.Dtos.BookDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Mappers
{
    public static class BookMapper
    {
        //public static BookDto ToBookDto(this Book bookDb)
        //{
        //    return new BookDto
        //    {
        //        Id = bookDb.BookId,
        //        Title = bookDb.Title,
        //        ReleaseDate = bookDb.ReleaseDate,
        //        Description = bookDb.Description,
        //        Authors = bookDb.Authors.Select(author => new AuthorDto
        //        {
        //            FirstName = author.FirstName,
        //            LastName = author.LastName,
        //            Description = author.Description,
        //            EmailAdress = author.EmailAdress
        //        }).ToList()
        //    };
        //}

        //public static Book ToBook(this AddBookDto addBookDto)
        //{
        //    return new Book
        //    {
        //        //BookId = bookDto.Id,
        //        PublisherId = addBookDto.PublisherId,
        //        Title = addBookDto.Title,
        //        ReleaseDate = addBookDto.ReleaseDate,
        //        Description = addBookDto.Description,
        //        //Authors = addBookDto.Authors,
        //        //AuthorId = bookDto.AuthorId,
        //    };
        //}

        //public static AddBookDto ToBookDto(this Book bookDb)
        //{

        //}
    }
}
