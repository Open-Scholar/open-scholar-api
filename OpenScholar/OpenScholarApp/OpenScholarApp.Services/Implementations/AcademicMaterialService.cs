﻿using OpenScholarApp.Dtos.AcademicMaterialDto;
using OpenScholarApp.Services.Interfaces;

namespace OpenScholarApp.Services.Implementations
{
    public class AcademicMaterialService : IAcademicMaterialService
    {
        public Task Add(AddAcademicMaterialDto addDto, string userId)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AcademicMaterialDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AcademicMaterialDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(UpdateAcademicMaterialDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
