using Microsoft.AspNetCore.Http;
using OpenScholarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
