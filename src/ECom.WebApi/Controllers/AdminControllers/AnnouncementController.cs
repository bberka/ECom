using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{

    public class AnnouncementController : BaseAdminController
    {
		[HttpPost]
        public IActionResult Update([FromBody] Announcement data) 
        {
			var res = AnnouncementMgr.This.UpdateAnnouncement(data);
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
			var res = AnnouncementMgr.This.DeleteAnnouncement(id);
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
			var res = AnnouncementMgr.This.EnableOrDisable(id);
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
