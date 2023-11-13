using Microsoft.AspNetCore.Http;
using OpenScholarApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenScholarApp.Data.Repositories.Interfaces
{
    public interface IDocFileRepository
    {
        Task<int> AddDocFileAsync(DocFile pdfFile, IFormFile pdfFileContent);
        Task<DocFile> GetDocFileAsync(int fileId);
        Task<List<DocFile>> GetAllDocFilesAsync();
        Task<bool> DeleteDocFileAsync(int fileId);
    }
}
