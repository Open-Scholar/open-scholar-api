namespace OpenScholarApp.Domain.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int UniversityId { get; set; }
        public University University { get; set; }
        public List<Student> Students { get; set; }
        public List<Professor> Professors { get; set;}
        public List<Topic> Topics { get; set; }
    }
}
