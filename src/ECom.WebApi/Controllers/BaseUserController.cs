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
        protected readonly EasLog logger = EasLogFactory.CreateLogger(nameof(BaseUserController));
        protected int UserId { get => User.Id; }
        protected User User { get; private set; }
        public BaseUserController() 
        {

			User = HttpContext.Session.GetString("user").FromJsonString<User>();
#if !DEBUG
			if (User is null) throw new NotAuthorizedException();
#elif DEBUG
            User = new();
            User.Id = 1;
#endif
        }
    }
}
