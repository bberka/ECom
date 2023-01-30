using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/User/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "User_Bearer")]
    public class BaseUserController : Controller
    {

    }
}
