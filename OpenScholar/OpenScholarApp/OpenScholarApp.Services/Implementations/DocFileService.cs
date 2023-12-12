using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.PdfFileDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Shared.CustomExceptions.DocFile;

namespace OpenScholarApp.Services.Implementations
{
    public class DocFileService : IDocFileService
    {
        private readonly IDocFileRepository _docFileRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public DocFileService(IDocFileRepository docFileRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _docFileRepository = docFileRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<int> AddDocFileAsync(DocFileDto docFileDto, string userId)
        {
            try
            {
                var docFile = _mapper.Map<DocFile>(docFileDto);
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                    throw new DocFileDataException("User not found while uploading the document");
                docFile.User = user;

                if (docFileDto.FileDetails == null)
                    throw new ArgumentException("File content is required.");

                if (docFile.FileType == FileType.PDF || docFile.FileType == FileType.DOCX)
                {
                    using (var stream = docFileDto.FileDetails.OpenReadStream())
                    using (var memoryStream = new MemoryStream())
                    {
                        await stream.CopyToAsync(memoryStream);
                        docFile.FileData = memoryStream.ToArray();
                    }

                    return await _docFileRepository.AddDocFileAsync(docFile, docFileDto.FileDetails);
                }
                else
                {
                    throw new DocFileDataException("Unsupported file type. Only PDF or DocX files are allowed.");
                }
            }
            catch (Exception ex)
            {
                throw new DocFileDataException($"Error adding document file: {ex.Message}");
            }
        }

        public async Task<DocFileDto> GetDocFileAsync(int fileId, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new DocFileDataException("You are not authorised to use this, please log in");

            var docFile = await _docFileRepository.GetDocFileAsync(fileId);

            if (docFile == null)
            {
                throw new DocFileNotFoundException("Document file not found.");
            }

            var docFileDto = _mapper.Map<DocFileDto>(docFile);
            //docFileDto.FileDetails = new Microsoft.AspNetCore.Http.FormFile(new MemoryStream(docFile.FileData), 0, docFile.FileData.Length, "File", docFile.FileName);

            return docFileDto;
        }

        public async Task<List<DocFileDto>> GetAllDocFilesAsync()
        {
            var docFiles = await _docFileRepository.GetAllDocFilesAsync();
            return _mapper.Map<List<DocFileDto>>(docFiles);
        }

        public async Task<bool> DeleteDocFileAsync(int fileId)
        {
            var docFile = await _docFileRepository.GetDocFileAsync(fileId);

            if (docFile == null)
            {
                return false;
            }

            return await _docFileRepository.DeleteDocFileAsync(fileId);
        }
    }
}
