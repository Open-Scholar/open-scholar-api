﻿using OpenScholarApp.Domain.Entities;
using System.Text.Json.Serialization;

namespace OpenScholarApp.Dtos.BookDto
{
    public class AddBookDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int? NumOfPages { get; set; }
        public string? ReleaseDate { get; set; } = string.Empty;
        public string? Description { get; set; }
        [JsonIgnore]
        public List<Author> Authors { get; set; } = new List<Author>() { };
    }
}
