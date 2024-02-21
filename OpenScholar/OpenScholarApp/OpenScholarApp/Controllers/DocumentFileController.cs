using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.DocumentFileDto;
using OpenScholarApp.Services.Interfaces;
using OpenScholarApp.Services.StorageServices;
using System.Security.Claims;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentFileController : BaseController
    {
        private readonly IDocumentFileService _documentFileService;
        private readonly IBlobService _blobStorageService;

        public DocumentFileController(IDocumentFileService documentFileService, IBlobService blobService)
        {
            _documentFileService = documentFileService;
            _blobStorageService = blobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _documentFileService.GetAllDocumentFilesAsync();
            return Response(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _documentFileService.GetDocumentFileByIdAsync(id);
            return Response(response);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return Unauthorized();
            }

            if (file == null || file.Length == 0)
            {
                return BadRequest("File must be provided.");
            }

            var documentFileDto = new DocumentFileDto
            {
                FileName = file.FileName,
                UserId = userId
                // FileUrl will be set in the service after upload
            };

            var response = await _documentFileService.CreateDocumentFileAsync(documentFileDto, file, userId);
            return Response(response);
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> Download(int id)
        {
            var fileResponse = await _documentFileService.GetDocumentFileByIdAsync(id);
            if (!fileResponse.IsSuccessfull || fileResponse.Result == null)
            {
                return NotFound();
            }

            var stream = await _blobStorageService.DownloadFileAsync(fileResponse.Result.FileName);
            if (stream == null)
            {
                return NotFound();
            }

            return File(stream, "application/octet-stream", fileResponse.Result.FileName);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _documentFileService.DeleteDocumentFileAsync(id);
            return Response(response);
        }

    }
}
