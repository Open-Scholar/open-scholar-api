using OpenScholarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Dtos.SubjectDto
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string CreatorId { get; set; } = string.Empty;
        public string SubjectName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int? EKSTCredits { get; set; }
        [AllowNull]
        public Faculty Faculty { get; set; }
    }
}
