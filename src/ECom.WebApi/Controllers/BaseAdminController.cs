using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers
{
    [ApiController]
    [Route("api/Admin/[controller]/[action]")]
#if !DEBUG
    [Authorize(Policy = "AdminOnly")]
#endif
	public class BaseAdminController : Controller
    {
        protected readonly EasLog logger = EasLogFactory.CreateLogger(nameof(BaseAdminController));
		protected Admin AuthAdmin { get; set; }
		protected int AuthAdminId { get => AuthAdmin.Id; }
		public BaseAdminController()
        {
			AuthAdmin = HttpContext.Session.GetString("admin").FromJsonString<Admin>();
#if !DEBUG
			if (AuthAdmin is null) throw new NotAuthorizedException();
#elif DEBUG
			AuthAdmin = new();
			AuthAdmin.Id = 1;
#endif
		}
	}
}
