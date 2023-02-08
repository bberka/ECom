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
        [HasPermission(AdminOperationType.Announcement_Update)]
        public ActionResult<Result> Update([FromBody] Announcement data) 
        {
			var res = _announcementService.UpdateAnnouncement(data);
			return res.WithoutRv();
		}
		
		[HttpDelete]
        [HasPermission(AdminOperationType.Announcement_Delete)]

        public ActionResult<Result> Delete([FromBody] uint id)
		{
			var res = _announcementService.DeleteAnnouncement(id);
			return res.WithoutRv();
		}
		[HttpPut]
        [HasPermission(AdminOperationType.Announcement_Update)]
        public ActionResult<Result> EnableOrDisable([FromBody] uint id)
		{
			var res = _announcementService.EnableOrDisable(id);
			return res.WithoutRv();
		}

	}
}
