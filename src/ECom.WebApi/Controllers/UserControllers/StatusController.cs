using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{

    public class StatusController : BaseUserController
    {
        [HttpGet]
        [Route("/Status")]
        public IActionResult Status()
        {
            return Ok("YES!");
        }
    }
}
