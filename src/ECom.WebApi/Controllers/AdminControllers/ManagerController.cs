using EasMe.Authorization.Filters;
using ECom.Domain.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{
    [Authorize(Roles = "Owner")]
    public class ManagerController : BaseAdminController
    {
        private readonly IAdminService _adminService;

        public ManagerController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        [HasPermission(AdminOperationType.Admin_GetOrList)]
        public ActionResult<List<Admin>> List()
        {
            var adminId = HttpContext.GetAdminId();
            return _adminService.ListOtherAdmins(adminId);
        }
        [HttpPost]
        [HasPermission(AdminOperationType.Admin_Update)]
        public ActionResult<Result> EnableOrDisable([FromBody] int adminId)
        {
            var authorizedAdminId = HttpContext.GetAdminId();
            return _adminService.EnableOrDisableAdmin(authorizedAdminId, adminId).WithoutRv();
        }
        [HttpDelete]
        [HasPermission(AdminOperationType.Admin_Delete)]
        public ActionResult<Result> Delete([FromBody] int adminId)
        {
            var authorizedAdminId = HttpContext.GetAdminId();
            return _adminService.DeleteAdmin(authorizedAdminId, adminId).WithoutRv();
        }
        [HttpPost]
        [HasPermission(AdminOperationType.Admin_Add)]
        public ActionResult<Result> Add([FromBody] AddAdminRequestModel model)
        {
            var res = _adminService.AddAdmin(model);
            return res.WithoutRv();
        }


    }
}
