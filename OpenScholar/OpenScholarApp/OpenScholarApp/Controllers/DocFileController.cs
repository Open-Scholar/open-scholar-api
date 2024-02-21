using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.PdfFileDto;
using OpenScholarApp.Services.Interfaces;
using System.Security.Claims;

//namespace OpenScholarApp.Controllers
//{
//    [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DocFileController : BaseController
//    {
//        private readonly IDocFileService _docFileService;

//        public DocFileController(IDocFileService docFileService)
//        {
//            _docFileService = docFileService;
//        }

//        [HttpPost("upload")]
//        public async Task<IActionResult> UploadDocFile([FromForm] DocFileDto docFileDto)
//        {
//            try
//            {
//                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
//                var fileId = await _docFileService.AddDocFileAsync(docFileDto , userId);
//                return Ok(new { FileId = fileId });
//            }
//            catch (ArgumentException ex)
//            {
//                return BadRequest(ex.Message);
//            }
//            catch (ApplicationException ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpGet("get/{fileId}")]
//        public async Task<IActionResult> GetDocFile(int fileId)
//        {
//            try
//            {
//                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                
//                var docFile = await _docFileService.GetDocFileAsync(fileId, userId);

//                if (docFile == null)
//                {
//                    return NotFound("File not found.");
//                }

//                // Convert IFormFile to byte[]
//                byte[] fileContents;
//                using (var stream = docFile.FileDetails.OpenReadStream())
//                using (var memoryStream = new MemoryStream())
//                {
//                    await stream.CopyToAsync(memoryStream);
//                    fileContents = memoryStream.ToArray();
//                }

//                return File(fileContents, "application/pdf", docFile.FileName);
//            }
//            catch (ApplicationException ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpGet("getAll")]
//        public async Task<IActionResult> GetAllDocFiles()
//        {
//            try
//            {
//                var docFiles = await _docFileService.GetAllDocFilesAsync();
//                return Ok(docFiles);
//            }
//            catch (ApplicationException ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpDelete("delete/{fileId}")]
//        public async Task<IActionResult> DeleteDocFile(int fileId)
//        {
//            try
//            {
//                var success = await _docFileService.DeleteDocFileAsync(fileId);

//                if (success)
//                {
//                    return Ok("File deleted successfully.");
//                }
//                else
//                {
//                    return NotFound("File not found.");
//                }
//            }
//            catch (ApplicationException ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }
//    }
//}
