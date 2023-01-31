using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers
{
    [ApiController]
    [Route("api/User/[controller]/[action]")]
    [Authorize(Policy = "UserOnly")]
    public class BaseUserController : Controller
    {

    }
}
