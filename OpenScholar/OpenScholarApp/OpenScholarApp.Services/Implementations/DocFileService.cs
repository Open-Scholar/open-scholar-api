using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Domain.Enums;
using OpenScholarApp.Dtos.PdfFileDto;
using OpenScholarApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<int> AddDocFileAsync(DocFileDto docFileDto)
        {
            try
            {
                var docFile = _mapper.Map<DocFile>(docFileDto);

                if (docFileDto.FileDetails == null)
                {
                    throw new ArgumentException("File content is required.");
                }

                if (docFile.FileType == FileType.PDF)
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
                    throw new ArgumentException("Unsupported file type. Only PDF files are allowed.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error adding document file: {ex.Message}");
            }
        }

        public async Task<DocFileDto> GetDocFileAsync(int fileId)
        {
            var docFile = await _docFileRepository.GetDocFileAsync(fileId);

            if (docFile == null)
            {
                throw new ApplicationException("Document file not found.");
            }

            return _mapper.Map<DocFileDto>(docFile);
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
