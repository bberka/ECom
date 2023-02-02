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
        public IActionResult Update([FromBody] Announcement data) 
        {
			var res = _announcementService.UpdateAnnouncement(data);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, $"{res.ResponseAsInt}:{res.ResponseAsString}", data.ToJsonString());
				return BadRequest(res.ToJsonString());
			}
			logger.Info(data.ToJsonString());
			return Ok(res);
		}
		
		[HttpDelete]
		public IActionResult Delete([FromBody] uint id)
		{
			var res = _announcementService.DeleteAnnouncement(id);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, $"{res.ResponseAsInt}:{res.ResponseAsString}", id);
				return BadRequest(res.ToJsonString());
			}
			logger.Info(id);
			return Ok(res);
		}
		[HttpPut]
		public IActionResult EnableOrDisable([FromBody] uint id)
		{
			var res = _announcementService.EnableOrDisable(id);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, $"{res.ResponseAsInt}:{res.ResponseAsString}", id);
				return BadRequest(res.ToJsonString());
			}
			logger.Info(id);
			return Ok(res);
		}

	}
}
