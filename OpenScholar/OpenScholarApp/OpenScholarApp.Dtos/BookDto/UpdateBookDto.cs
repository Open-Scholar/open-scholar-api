﻿using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Dtos.BookDto
{
    public class UpdateBookDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int? NumOfPages { get; set; }
        public string? ReleaseDate { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Author> Authors { get; set; } = new List<Author>() { };
    }
}
