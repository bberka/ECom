namespace ECom.WebApi.Controllers.AdminControllers;

public class AnnouncementController : BaseAdminController
{
  private readonly IAnnouncementService _announcementService;
  private readonly ILogService _logService;

  public AnnouncementController(
    IAnnouncementService announcementService,
    ILogService logService) {
    _announcementService = announcementService;
    _logService = logService;
  }



  [HttpDelete]
  [RequirePermission(AdminOperationType.AnnouncementDelete)]
  public ActionResult<CustomResult> Delete([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _announcementService.DeleteAnnouncement(id);
    _logService.AdminLog(res, adminId, "Announcement.Delete", id);
    return res;
  }

  [HttpPut]
  [RequirePermission(AdminOperationType.AnnouncementUpdate)]
  public ActionResult<CustomResult> Enable([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _announcementService.EnableAnnouncement(id);
    _logService.AdminLog(res, adminId, "Announcement.Update", id);
    return res;
  }
}