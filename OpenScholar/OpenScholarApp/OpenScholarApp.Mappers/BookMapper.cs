using OpenScholarApp.Domain.Entities;
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
        public static BookDto ToBookDto(this Book bookDb)
        {
            return new BookDto
            {
                Id = bookDb.Id,
                Title = bookDb.Title,
                ReleaseDate = bookDb.ReleaseDate,
                Description = bookDb.Description,
                Authors = bookDb.Authors,
                AuthorId = bookDb.AuthorId,
            };
        }

        public static Book ToBook(this BookDto bookDto)
        {
            return new Book
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                ReleaseDate = bookDto.ReleaseDate,
                Description = bookDto.Description,
                Authors = bookDto.Authors. Authors,
                AuthorId = bookDto.AuthorId,
            };
        }
    }
}
