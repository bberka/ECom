using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers
{
    [ApiController]
    [Route("api/Admin/[controller]/[action]")]
    [Authorize(Policy = "AdminOnly")]
    public class BaseAdminController : Controller
    {

    }
}
