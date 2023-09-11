using OpenScholarApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Dtos.AcademicMaterialDto
{
    public class AcademicMaterialDto
    {
        public int AcademicMaterialId { get; set; }
        public int PublisherId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public AcademicMaterialType Type { get; set; } = AcademicMaterialType.Other;
    }
}
