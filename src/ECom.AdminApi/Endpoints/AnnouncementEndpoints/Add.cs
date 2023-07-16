

namespace ECom.AdminApi.Endpoints.AnnouncementEndpoints;

[EndpointRoute(typeof(Add))]
public class Add : EndpointBaseSync.WithRequest<Announcement>.WithResult<CustomResult>
{
  private readonly IAnnouncementService _announcementService;
  private readonly ILogService _logService;

  public Add(IAnnouncementService announcementService,ILogService logService) {
    _announcementService = announcementService;
    _logService = logService;
  }
  [HttpPost]
  [RequirePermission(AdminOperationType.AnnouncementAdd)]
  [EndpointSwaggerOperation(typeof(Add),"Adds announcement")]
  public override CustomResult Handle(Announcement request) {
    var adminId = HttpContext.GetAdminId();
    var res = _announcementService.UpdateAnnouncement(request);
    _logService.AdminLog(res, adminId, "Announcement.Add", request.ToJsonString());
    return res;
  }
}