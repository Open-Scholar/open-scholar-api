using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenScholarApp.Dtos.PdfFileDto;
using OpenScholarApp.Services.Interfaces;

//namespace OpenScholarApp.Controllers
//{
//    [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DocFileTwoController : ControllerBase
//    {
//        private readonly IDocFileService2 _documentService;

//        public DocFileTwoController(IDocFileService2 documentService)
//        {
//            _documentService = documentService;
//        }

//        [HttpPost]
//        public async Task<ActionResult> PostSingleFile([FromForm] DocFileDto fileDetails)
//        {
//            if (fileDetails == null)
//            {
//                return BadRequest();
//            }

//            try
//            {
//                await _documentService.PostFileAsync(fileDetails.FileDetails, fileDetails.FileType);
//                return Ok();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        [HttpGet]
//        public async Task<ActionResult> DownloadFile(int id)
//        {
//            if (id < 1)
//            {
//                return BadRequest();
//            }

//            try
//            {
//                await _documentService.DownloadFileById(id);
//                return Ok();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}
