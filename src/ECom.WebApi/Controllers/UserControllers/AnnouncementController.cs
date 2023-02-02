using ECom.Application.Abstract;
using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{

    public class AnnouncementController : BaseUserController
    {
        private readonly IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService= announcementService;  
        }
        [HttpGet]
        public IActionResult List()
        {
            var res = _announcementService.GetList();
			logger.Info();
			return Ok(res.ToJsonString());
        }


	}
}
