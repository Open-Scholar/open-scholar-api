using Microsoft.AspNetCore.Http;
using OpenScholarApp.Dtos.DocumentFileDto;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IDocumentFileService
    {
        Task<Response<List<DocumentFileDto>>> GetAllDocumentFilesAsync();
        Task<Response<DocumentFileDto>> GetDocumentFileByIdAsync(int id);
        Task<Response> CreateDocumentFileAsync(DocumentFileDto addDto, IFormFile file, string userId);
        Task<Response> DeleteDocumentFileAsync(int id);
    }
}
