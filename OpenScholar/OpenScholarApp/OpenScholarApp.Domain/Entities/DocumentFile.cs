using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Domain.Entities
{
    public class DocumentFile
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public FileType FileType {  get; set; }
        public ApplicationUser? User { get; set; }
    }
}
