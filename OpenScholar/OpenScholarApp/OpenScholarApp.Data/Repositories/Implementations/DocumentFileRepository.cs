using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class DocumentFileRepository : IDocumentFileRepository
    {
        private readonly OpenScholarDbContext _openScholarDbContext;

        public DocumentFileRepository(OpenScholarDbContext openScholarDbContext)
        {
            _openScholarDbContext = openScholarDbContext;
        }

        public async Task<int> AddDocumentFileAsync(DocumentFile documentFile)
        {
            await _openScholarDbContext.DocumentFiles.AddAsync(documentFile);
            await _openScholarDbContext.SaveChangesAsync();
            return documentFile.Id;
        }

        public async Task<bool> DeleteDocumentFileAsync(int fileId)
        {
            var documentFile = await _openScholarDbContext.DocumentFiles.FindAsync(fileId);

            if(documentFile != null)
            {
            _openScholarDbContext.DocumentFiles.Remove(documentFile);
            await _openScholarDbContext.SaveChangesAsync();
            return true;
            }
            return false;
        }

        public async Task<List<DocumentFile>> GetAllDocumentFilesAsync()
        {
            return await _openScholarDbContext.DocumentFiles.ToListAsync();
        }

        public async Task<DocumentFile> GetDocumentFileAsync(int fileId)
        {
            return await _openScholarDbContext.DocumentFiles.FindAsync(fileId);
        }
    }
}
