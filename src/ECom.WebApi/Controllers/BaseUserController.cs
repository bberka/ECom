using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(Policy = "UserOnly")]
[ApiExplorerSettings(GroupName = "User")]
public class BaseUserController : Controller
{
}