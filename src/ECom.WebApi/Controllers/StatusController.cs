using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class StatusController : Controller
    {
        [HttpGet]
        [Route("/Status")]
        public IActionResult Status()
        {
            return Ok("YES!");
        }

	}
}
