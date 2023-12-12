using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OpenScholarApp.Data.Context;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;

namespace OpenScholarApp.Data.Repositories.Implementations
{
    public class DocFileRepository : IDocFileRepository
    {

        private readonly OpenScholarDbContext _context;

        public DocFileRepository(OpenScholarDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddDocFileAsync(DocFile docFile, IFormFile docFileContent)
        {
            using (var stream = docFileContent.OpenReadStream())
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                docFile.FileData = memoryStream.ToArray();
            }

            _context.DocFiles.Add(docFile);
            await _context.SaveChangesAsync();
            return docFile.Id;
        }

        public async Task<DocFile> GetDocFileAsync(int fileId)
        {
            return await _context.DocFiles.FindAsync(fileId);
        }

        public async Task<List<DocFile>> GetAllDocFilesAsync()
        {
            return await _context.DocFiles.ToListAsync();
        }

        public async Task<bool> DeleteDocFileAsync(int fileId)
        {
            var docFile = await _context.DocFiles.FindAsync(fileId);
            if (docFile != null)
            {
                _context.DocFiles.Remove(docFile);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
