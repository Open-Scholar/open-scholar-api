using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Dtos.DocumentFileDto
{
    public class DocumentFileDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public FileType FileType { get; set; }
    }
}
