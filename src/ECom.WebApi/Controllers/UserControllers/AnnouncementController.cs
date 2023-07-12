using Microsoft.AspNetCore.Authorization;

namespace ECom.WebApi.Controllers.UserControllers;

[AllowAnonymous]
public class AnnouncementController : BaseUserController
{
  private readonly IAnnouncementService _announcementService;

  public AnnouncementController(IAnnouncementService announcementService) {
    _announcementService = announcementService;
  }

  [HttpGet]
  [ResponseCache(Duration = 60)]
  public ActionResult<List<Announcement>> List() {
    return _announcementService.ListAnnouncements();
  }
}