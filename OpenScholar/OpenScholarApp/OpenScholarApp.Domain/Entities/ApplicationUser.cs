using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Domain.Enums;

namespace OpenScholarApp.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        public AccountType AccountType { get; set; }
        public bool IsAccountVerified { get; set; } = false;
        public bool IsProfileCreated { get; set; } = false;
        public string PhotoUrl { get; set; } = string.Empty;

        //ACCOUNT TYPES
        public List<Student>? Students { get; set; } = new List<Student>();
        public List<Professor>? Professors { get; set; } = new List<Professor>();
        public List<FacultyAcc>? Faculty { get; set;} = new List<FacultyAcc>();
        public List<UniversityAcc>? University { get; set; } = new List<UniversityAcc>();
        public List<BookStore>? BookStores { get; set; } = new List<BookStore>();
        public List<BookSeller>? BookSellers { get; set; } = new List<BookSeller>();

        //ITEMS
        public List<Topic>? Topics { get; set; } = new List<Topic>();
        public List<TopicComment> TopicComments { get; set; } = new List<TopicComment>();
        public List<TopicLike> TopicLikes { get; set; } = new List<TopicLike>();
        public List<TopicCommentLike> TopicCommentLikes { get; set; } = new List<TopicCommentLike>();
    }
}
