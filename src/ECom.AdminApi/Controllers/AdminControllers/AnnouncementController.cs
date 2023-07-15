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

  [HttpPost]
  [RequirePermission(AdminOperationType.Announcement_Update)]
  public ActionResult<Result> Update([FromBody] Announcement data) {
    var adminId = HttpContext.GetAdminId();
    var res = _announcementService.UpdateAnnouncement(data);
    _logService.AdminLog(res, adminId, "Announcement.Update", data.ToJsonString());
    return res.ToActionResult();
  }

  [HttpDelete]
  [RequirePermission(AdminOperationType.Announcement_Delete)]
  public ActionResult<Result> Delete([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _announcementService.DeleteAnnouncement(id);
    _logService.AdminLog(res, adminId, "Announcement.Delete", id);
    return res.ToActionResult();
  }

  [HttpPut]
  [RequirePermission(AdminOperationType.Announcement_Update)]
  public ActionResult<Result> EnableOrDisable([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _announcementService.EnableOrDisable(id);
    _logService.AdminLog(res, adminId, "Announcement.Update", id);
    return res.ToActionResult();
  }
}