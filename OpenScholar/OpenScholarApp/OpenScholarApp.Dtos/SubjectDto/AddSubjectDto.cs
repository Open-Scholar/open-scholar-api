namespace OpenScholarApp.Dtos.SubjectDto
{
    public class AddSubjectDto
    {
        public string UserId { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int? EKSTCredits { get; set; }
    }
}
