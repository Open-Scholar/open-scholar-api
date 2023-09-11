namespace OpenScholarApp.Dtos.UniversityDto
{
    public class AddUniversityDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string EmailAdress { get; set; } = string.Empty;
        public string WebAdress { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
