using Microsoft.AspNetCore.Http;
using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Dtos.PdfFileDto
{
    public class DocFileDto
    {
        public string FileName { get; set; }
        public IFormFile FileDetails { get; set; }
        public FileType FileType { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
