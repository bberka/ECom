using EasMe.Authorization.Filters;
using ECom.Domain.Constants;
using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{

    public class AnnouncementController : BaseAdminController
    {
		private readonly IAnnouncementService _announcementService;
		public AnnouncementController(IAnnouncementService announcementService)
		{
			_announcementService = announcementService;
		}
		[HttpPost]
        [EndPointAuthorizationFilter(AdminOperationType.Announcement_Update)]
        public ActionResult<Result> Update([FromBody] Announcement data) 
        {
			var res = _announcementService.UpdateAnnouncement(data);
			logger.Info(data.ToJsonString());
			return res;
		}
		
		[HttpDelete]
        [EndPointAuthorizationFilter(AdminOperationType.Announcement_Delete)]

        public ActionResult<Result> Delete([FromBody] uint id)
		{
			var res = _announcementService.DeleteAnnouncement(id);
			return res;
		}
		[HttpPut]
        [EndPointAuthorizationFilter(AdminOperationType.Announcement_EnableOrDisable)]
        public ActionResult<Result> EnableOrDisable([FromBody] uint id)
		{
			var res = _announcementService.EnableOrDisable(id);
			logger.Info(id);
			return res;
		}

	}
}
