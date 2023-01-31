using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{

    public class HomeController : BaseUserController
    {
        [HttpGet]
        public IActionResult Status()
        {
            return Ok("YES!");
        }
    }
}
