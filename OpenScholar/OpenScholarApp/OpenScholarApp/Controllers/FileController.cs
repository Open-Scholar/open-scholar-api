using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.DocumentFileDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Services.StorageServices.S3Bucket;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseController
    {
        private readonly IS3FileService _s3FileService;
        private readonly IFileService _fileService;

        public FileController(IS3FileService s3FileService, IFileService fileService)
        {
            _s3FileService = s3FileService;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _fileService.GetAllDocumentFilesAsync();
            return Response(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _fileService.GetDocumentFileByIdAsync(id);
            return Response(response);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized();

            if (file == null || file.Length == 0)
                return BadRequest("File must be provided.");

            var documentFileDto = new DocumentFileDto
            {
                FileName = file.FileName,
                UserId = userId
                // FileUrl will be set in the service after upload
            };

            var response = await _fileService.CreateDocumentFileAsync(documentFileDto, file, userId);
            return Response(response);
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var fileResponse = await _fileService.GetDocumentFileByIdAsync(id);
            if (!fileResponse.IsSuccessfull || fileResponse.Result == null)
                return NotFound();

            var stream = await _s3FileService.DownloadFileAsync(fileResponse.Result.FileName);
            if (stream == null)
                return NotFound();

            return File(stream, "application/octet-stream", fileResponse.Result.FileName);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _fileService.DeleteDocumentFileAsync(id);
            return Response(response);
        }
    }
}
