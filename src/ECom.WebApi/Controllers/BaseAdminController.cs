using EasMe.Logging;
using Microsoft.AspNetCore.Authorization;

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
