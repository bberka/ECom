using EasMe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
	public class BaseUserController : Controller
    {
        protected readonly EasLog logger = EasLogFactory.CreateLogger(nameof(BaseUserController));

        
    }
}
