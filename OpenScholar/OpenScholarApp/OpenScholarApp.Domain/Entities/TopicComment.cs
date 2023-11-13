using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenScholarApp.Domain.Entities
{
    public class TopicComment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Comment { get; set; } = string.Empty;

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? UpdatedAt { get; set; }

        // Change the foreign key property to match the data type of ApplicationUser's Id
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        // Add the UserId property as a foreign key
        public string UserId { get; set; }

        [ForeignKey("Id")]
        public Topic? Topic { get; set; }
    }
}
