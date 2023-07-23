namespace ECom.AdminWebApi.Endpoints.AnnouncementEndpoints;

[EndpointRoute(typeof(Delete))]
public class Delete : EndpointBaseSync.WithRequest<uint>.WithResult<CustomResult>
{
  private readonly IAnnouncementService _announcementService;
  private readonly ILogService _logService;

  public Delete(IAnnouncementService announcementService, ILogService logService) {
    _announcementService = announcementService;
    _logService = logService;
  }

  [HttpDelete]
  [RequirePermission(AdminPermission.ManageAnnouncements)]
  [EndpointSwaggerOperation(typeof(Delete), "Deletes announcement")]
  public override CustomResult Handle([FromBody] uint id) {
    var adminId = HttpContext.GetAdminId();
    var res = _announcementService.DeleteAnnouncement(id);
    _logService.AdminLog(res, adminId, "Announcement.Delete", id);
    return res;
  }
}