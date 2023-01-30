using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.User
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
