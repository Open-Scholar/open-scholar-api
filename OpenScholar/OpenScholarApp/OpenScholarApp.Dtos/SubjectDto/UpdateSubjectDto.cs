using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Dtos.SubjectDto
{
    public class UpdateSubjectDto
    {
        public int Id { get; set; }
        public string CreatorId { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int? EKSTCredits { get; set; }
    }
}
