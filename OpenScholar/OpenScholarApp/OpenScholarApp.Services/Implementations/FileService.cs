using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OpenScholarApp.Data.Repositories.Interfaces;
using OpenScholarApp.Domain.Entities;
using OpenScholarApp.Dtos.DocumentFileDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Services.StorageServices.S3Bucket;
using OpenScholarApp.Shared.Responses;

namespace OpenScholarApp.Services.Implementations
{
    public class FileService : IFileService
    {
        private readonly IDocumentFileRepository _documentFileRepository;
        private readonly IS3FileService _s3FileService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public FileService(IDocumentFileRepository documentFileRepository, IS3FileService s3FileService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _documentFileRepository = documentFileRepository;
            _s3FileService = s3FileService;
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
                using (var stream = new MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    stream.Position = 0;
                    var fileUrl = await _s3FileService.UploadFileAsync(stream, file.FileName);
                    var documentFile = _mapper.Map<DocumentFile>(addDto);
                    documentFile.UserId = userId;
                    documentFile.FileUrl = fileUrl;
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
                    await _s3FileService.DeleteFileAsync(documentFile.FileName);
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
