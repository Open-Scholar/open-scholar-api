﻿using OpenScholarApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Dtos.AcademicMaterialDto
{
    public class AddAcademicMaterialDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public AcademicMaterialType Type { get; set; }
    }
}