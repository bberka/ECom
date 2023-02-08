using EasMe.Authorization.Filters;
using ECom.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{
    [Authorize(Roles = "Owner")]
    public class AdminController : BaseAdminController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        [EndPointAuthorizationFilter(AdminOperationType.Admin_GetOrList)]
        public ActionResult<List<Admin>> List()
        {
            var adminId = HttpContext.GetAdminId();
            return _adminService.ListOtherAdmins(adminId);
        }
    }
}
