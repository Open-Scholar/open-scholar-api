namespace OpenScholarApp.Dtos.UniversityDto
{
    public class UniversityDto
    {
        public int UniversityId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string EmailAdress { get; set; }
        public string WebAdress { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
