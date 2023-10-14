﻿using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Dtos.ProfessorDto
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int? PhoneNumber { get; set; }
        public string? BirthDate { get; set; }
        public string? Description { get; set; }
    }
}
