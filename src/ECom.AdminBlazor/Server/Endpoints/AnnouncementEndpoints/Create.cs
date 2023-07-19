namespace ECom.AdminBlazor.Server.Endpoints.AnnouncementEndpoints;

[EndpointRoute(typeof(Create))]
public class Create : EndpointBaseSync.WithRequest<AddAnnouncementRequest>.WithResult<CustomResult>
{
  private readonly IAnnouncementService _announcementService;
  private readonly ILogService _logService;

  public Create(IAnnouncementService announcementService, ILogService logService) {
    _announcementService = announcementService;
    _logService = logService;
  }

  [HttpPost]
  [RequirePermission(AdminOperationType.AnnouncementAdd)]
  [EndpointSwaggerOperation(typeof(Create), "Adds announcement")]
  public override CustomResult Handle(AddAnnouncementRequest request) {
    var adminId = HttpContext.GetAdminId();
    var res = _announcementService.AddAnnouncement(request);
    _logService.AdminLog(res, adminId, "Announcement.Create", request.ToJsonString());
    return res;
  }
}