namespace OpenScholarApp.Dtos.FacultyDto
{
    public class UpdateFacultyDto
    {
        public int FacultyId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string EmailAdress { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        //public University? University { get; set; }
    }
}
