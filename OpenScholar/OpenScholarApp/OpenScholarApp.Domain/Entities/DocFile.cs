using OpenScholarApp.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class DocFile
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public byte[] FileData { get; set; }
        public FileType FileType { get; set; }
        [ForeignKey("id")]
        public ApplicationUser User { get; set; }
    }
}
