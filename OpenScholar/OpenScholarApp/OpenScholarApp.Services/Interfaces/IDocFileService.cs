using OpenScholarApp.Dtos.PdfFileDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IDocFileService
    {
        Task<int> AddDocFileAsync(DocFileDto docFileDto);
        Task<DocFileDto> GetDocFileAsync(int fileId);
        Task<List<DocFileDto>> GetAllDocFilesAsync();
        Task<bool> DeleteDocFileAsync(int fileId);
    }
}
