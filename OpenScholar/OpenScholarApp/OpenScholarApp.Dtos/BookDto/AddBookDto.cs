﻿using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Dtos.BookDto
{
    public class AddBookDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
