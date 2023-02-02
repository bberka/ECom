using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{

    public class AnnouncementController : BaseUserController
    {
        [HttpGet]
        public IActionResult List()
        {
            var res = AnnouncementMgr.This.GetList();
			logger.Info();
			return Ok(res.ToJsonString());
        }


	}
}
