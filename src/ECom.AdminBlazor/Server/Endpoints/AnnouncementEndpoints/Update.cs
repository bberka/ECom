namespace ECom.AdminBlazor.Server.Endpoints.AnnouncementEndpoints;

[EndpointRoute(typeof(Update))]
public class Update : EndpointBaseSync.WithRequest<UpdateAnnouncementRequest>.WithResult<CustomResult>
{
  private readonly IAnnouncementService _announcementService;
  private readonly ILogService _logService;

  public Update(IAnnouncementService announcementService, ILogService logService) {
    _announcementService = announcementService;
    _logService = logService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.AnnouncementUpdate)]
  [EndpointSwaggerOperation(typeof(Update), "Updates announcement")]
  public override CustomResult Handle(UpdateAnnouncementRequest request) {
    var adminId = HttpContext.GetAdminId();
    var res = _announcementService.UpdateAnnouncement(request);
    _logService.AdminLog(res, adminId, "Announcement.Update", request.ToJsonString());
    return res;
  }
}