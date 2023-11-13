using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenScholarApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TopicCommentController : BaseController
    {
    }
}
