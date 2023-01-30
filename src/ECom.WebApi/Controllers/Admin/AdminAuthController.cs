using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Admin
{
    [ApiController]
    [Route("api/Admin/[controller]/[action]")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            return Ok();
        }
    }
}
