using OpenScholarApp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Dtos.BookSellerDto
{
    public class AddBookSellerDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
