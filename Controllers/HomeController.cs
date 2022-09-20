using Microsoft.AspNetCore.Mvc;

namespace Manager.Controllers
{

    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {

        [HttpGet(" ")]
        public IActionResult Index()
        {
            return Ok("OK");
        }
    }
}
