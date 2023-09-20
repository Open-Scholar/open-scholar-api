namespace OpenScholarApp.Dtos.SubjectDto
{
    public class UpdateSubjectDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int? EKSTCredits { get; set; }
    }
}
