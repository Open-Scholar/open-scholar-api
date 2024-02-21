using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OpenScholarApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoNothingController : BaseController
    {
        [HttpGet("ajdeee")]
        public ActionResult Get()
        {
            throw new NotImplementedException();
        }

    }
}
