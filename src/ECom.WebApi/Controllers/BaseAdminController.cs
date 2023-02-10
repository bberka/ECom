using EasMe.Logging;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace ECom.WebApi.Controllers
{
    [ApiController]
    [Route("api/Admin/[controller]/[action]")]
    [Authorize(Policy = "AdminOnly")]
    public class BaseAdminController : Controller
    {
        //protected readonly EasLog logger = EasLogFactory.CreateLogger(nameof(BaseAdminController));

	}
}
