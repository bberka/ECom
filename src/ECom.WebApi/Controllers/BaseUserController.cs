using EasMe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(Policy = "UserOnly")]
    public class BaseUserController : Controller
    {
        private readonly static EasLog logger = EasLogFactory.CreateLogger(nameof(BaseUserController));
    }
}
