using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Services.Interfaces;

namespace OpenScholarApp.Services.Implementations
{
    public class DocFileService2 : IDocFileService2
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDocFileRepository _docFileRepository;

        public DocFileService2(IMapper mapper, UserManager<ApplicationUser> userManager, IDocFileRepository docFileRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _docFileRepository = docFileRepository;
        }

        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = await _docFileRepository.GetDocFileAsync(Id);

                var content = new System.IO.MemoryStream(file.FileData);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded",
                   file.FileName);

                await CopyStream(content, path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        public async Task PostFileAsync(IFormFile fileData, FileType fileType)
        {
            try
            {
                var docFile = new DocFile()
                {
                    //ID = 0,
                    FileName = fileData.FileName,
                    FileType = fileType,
                };

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    docFile.FileData = stream.ToArray();
                }
                var result = await _docFileRepository.AddDocFileAsync(docFile, fileData); //ke vidime ova

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
