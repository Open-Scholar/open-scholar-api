using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.DocumentFileDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Services.StorageServices;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class DocumentFileService : IDocumentFileService
    {

        private readonly IDocumentFileRepository _documentFileRepository;
        private readonly IBlobService _blobStorageService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public DocumentFileService(IDocumentFileRepository documentFileRepository, IBlobService blobStorageService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _documentFileRepository = documentFileRepository;
            _blobStorageService = blobStorageService;
            _mapper = mapper;
            _userManager = userManager;

        }

        public async Task<Response<List<DocumentFileDto>>> GetAllDocumentFilesAsync()
        {
            try
            {
                var documentFiles = await _documentFileRepository.GetAllDocumentFilesAsync();
                var dtos = _mapper.Map<List<DocumentFileDto>>(documentFiles);
                return new Response<List<DocumentFileDto>>(dtos);
            }
            catch (Exception ex)
            {
                return new Response<List<DocumentFileDto>>(new List<string> { ex.Message });
            }
        }

        public async Task<Response<DocumentFileDto>> GetDocumentFileByIdAsync(int id)
        {
            try
            {
                var documentFile = await _documentFileRepository.GetDocumentFileAsync(id);
                if (documentFile == null)
                    return new Response<DocumentFileDto>(new List<string> { "Document file not found." });

                var dto = _mapper.Map<DocumentFileDto>(documentFile);
                return new Response<DocumentFileDto>(dto);
            }
            catch (Exception ex)
            {
                return new Response<DocumentFileDto>(new List<string> { ex.Message });
            }
        }

        public async Task<Response> CreateDocumentFileAsync(DocumentFileDto addDto, IFormFile file, string userId)
        {
            try
            {
                // Create a new MemoryStream
                using (var stream = new MemoryStream())
                {
                    // Copy the contents of the file into the stream
                    await file.CopyToAsync(stream);

                    // Reset the position of the stream to the beginning
                    stream.Position = 0;

                    // Upload the file stream to Azure Blob Storage
                    var fileUrl = await _blobStorageService.UploadFileAsync(stream, file.FileName);
                    var documentFile = _mapper.Map<DocumentFile>(addDto);
                    documentFile.UserId = userId; // Set UserId separately as it's not in DTO
                    documentFile.FileUrl = fileUrl;

                    // Save the document file record to the database
                    await _documentFileRepository.AddDocumentFileAsync(documentFile);
                }
                return Response.Success;
            }
            catch (Exception ex)
            {
                return new Response(new List<string> { ex.Message });
            }
        }

        public async Task<Response> DeleteDocumentFileAsync(int id)
        {
            try
            {
                var documentFile = await _documentFileRepository.GetDocumentFileAsync(id);
                if (documentFile != null)
                {
                    await _blobStorageService.DeleteFileAsync(documentFile.FileName);
                    await _documentFileRepository.DeleteDocumentFileAsync(id);
                    return Response.Success;
                }
                return new Response(new List<string> { "Document file not found." });
            }
            catch (Exception ex)
            {
                return new Response(new List<string> { ex.Message });
            }
        }
    }
}
