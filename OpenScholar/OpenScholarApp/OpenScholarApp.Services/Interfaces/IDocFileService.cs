using OpenScholarApp.Dtos.PdfFileDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IDocFileService
    {
        Task<int> AddDocFileAsync(DocFileDto docFileDto, string userId);
        Task<DocFileDto> GetDocFileAsync(int fileId, string userId);
        Task<List<DocFileDto>> GetAllDocFilesAsync();
        Task<bool> DeleteDocFileAsync(int fileId);
    }
}
