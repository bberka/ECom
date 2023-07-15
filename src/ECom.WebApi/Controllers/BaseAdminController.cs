using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Controllers;

//[ApiController]
//[Route("api/Admin/[controller]/[action]")]
//[Authorize(Policy = "AdminOnly")]
////[ApiExplorerSettings(GroupName = "Admin")]
public class BaseAdminController : Controller
{
  //protected readonly EasLog logger = EasLogFactory.CreateLogger(nameof(BaseAdminController));
}