using OpenScholarApp.Dtos.SubjectDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Services.Implementations
{
    public class SubjectService : ISubjectService
    {
        public Task<Response> CreateSubjectAsync(AddSubjectDto addDto, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteSubjectAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<SubjectDto>>> GetAllSubjectsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<SubjectDto>> GetSubjectByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateSubjectAsync(int id, UpdateSubjectDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
