namespace OpenScholarApp.Domain.Entities
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Faculty>? Faculties { get; set; } = new List<Faculty>();
        public List<Student>? Students { get; set; }
        public List<Professor> Professors { get; set; }
    }
}
