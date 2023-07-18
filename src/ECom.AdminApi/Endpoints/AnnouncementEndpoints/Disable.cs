namespace ECom.AdminApi.Endpoints.AnnouncementEndpoints;

//[EndpointRoute(typeof(Disable))]
//public class Disable : EndpointBaseSync.WithRequest<uint>.WithResult<CustomResult>
//{
//  private readonly IAnnouncementService _announcementService;
//  private readonly ILogService _logService;

//  public Disable(IAnnouncementService announcementService, ILogService logService) {
//    _announcementService = announcementService;
//    _logService = logService;
//  }
//  [HttpPut]
//  [RequirePermission(AdminOperationType.AnnouncementUpdate)]
//  [EndpointSwaggerOperation(typeof(Disable), "Disables announcement")]
//  public override CustomResult Handle([FromBody] uint id) {
//    var adminId = HttpContext.GetAdminId();
//    var res = _announcementService.DisableAnnouncement(id);
//    _logService.AdminLog(res, adminId, "Announcement.Disable", id);
//    return res;
//  }
//}