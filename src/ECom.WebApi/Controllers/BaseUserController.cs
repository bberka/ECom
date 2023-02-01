using EasMe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
#if !DEBUG
    [Authorize(Policy = "UserOnly")]
#endif
    public class BaseUserController : Controller
    {
        private readonly static EasLog logger = EasLogFactory.CreateLogger(nameof(BaseUserController));
    }
}
