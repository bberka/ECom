using ECom.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers
{
    [ApiController]
    [Route("api/Admin/[controller]/[action]")]

    [AdminAuthFilter]
	public class BaseAdminController : Controller
    {
        protected readonly EasLog logger = EasLogFactory.CreateLogger(nameof(BaseAdminController));

	}
}
