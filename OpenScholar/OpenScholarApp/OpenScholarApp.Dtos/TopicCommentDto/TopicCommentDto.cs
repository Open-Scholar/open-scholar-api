using OpenScholarApp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Dtos.TopicCommentDto
{
    public class TopicCommentDto
    {
        public int Id { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? UpdatedAt { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser User { get; set; }
        [ForeignKey("Id")]
        public Topic Topic { get; set; }
    }
}
