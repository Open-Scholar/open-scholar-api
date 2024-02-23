using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IDocumentFileRepository
    {
        Task<int> AddDocumentFileAsync(DocumentFile documentFile);
        Task<DocumentFile> GetDocumentFileAsync(int fileId);
        Task<List<DocumentFile>> GetAllDocumentFilesAsync();
        Task<bool> DeleteDocumentFileAsync(int fileId);
    }
}
