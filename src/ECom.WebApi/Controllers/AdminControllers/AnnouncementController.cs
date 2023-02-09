using EasMe.Authorization.Filters;
using ECom.Domain.Constants;
using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{

    public class AnnouncementController : BaseAdminController
    {
		private readonly IAnnouncementService _announcementService;
        private readonly ILogService _logService;

        public AnnouncementController(
            IAnnouncementService announcementService,
            ILogService logService)
        {
            _announcementService = announcementService;
            _logService = logService;
        }
		[HttpPost]
        [HasPermission(AdminOperationType.Announcement_Update)]
        public ActionResult<Result> Update([FromBody] Announcement data)
        {
            var adminId = HttpContext.GetAdminId();
			var res = _announcementService.UpdateAnnouncement(data);
		    _logService.AdminLog(res,adminId,"Announcement.Update",data.ToJsonString());
			return res.WithoutRv();
		}
		[HttpDelete]
        [HasPermission(AdminOperationType.Announcement_Delete)]

        public ActionResult<Result> Delete([FromBody] uint id)
		{
			var adminId = HttpContext.GetAdminId();
            var res = _announcementService.DeleteAnnouncement(id);
		    _logService.AdminLog(res,adminId,"Announcement.Delete",id);
            return res.WithoutRv();
		}
		[HttpPut]
        [HasPermission(AdminOperationType.Announcement_Update)]
        public ActionResult<Result> EnableOrDisable([FromBody] uint id)
		{
            var adminId = HttpContext.GetAdminId();
            var res = _announcementService.EnableOrDisable(id);
		    _logService.AdminLog(res,adminId,"Announcement.Update",id);
            return res.WithoutRv();
		}

	}
}
