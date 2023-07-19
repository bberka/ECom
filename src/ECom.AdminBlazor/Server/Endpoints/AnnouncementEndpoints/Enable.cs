namespace ECom.AdminBlazor.Server.Endpoints.AnnouncementEndpoints;

//[EndpointRoute(typeof(Enable))]
//public class Enable : EndpointBaseSync.WithRequest<uint>.WithResult<CustomResult>
//{
//  private readonly IAnnouncementService _announcementService;
//  private readonly ILogService _logService;

//  public Enable(IAnnouncementService announcementService, ILogService logService) {
//    _announcementService = announcementService;
//    _logService = logService;
//  }
//  [HttpPut]
//  [RequirePermission(AdminOperationType.AnnouncementUpdate)]
//  [EndpointSwaggerOperation(typeof(Enable),"Enables announcement")]
//  public override CustomResult Handle([FromBody] uint id)
//  {
//    var adminId = HttpContext.GetAdminId();
//    var res = _announcementService.EnableAnnouncement(id);
//    _logService.AdminLog(res, adminId, "Announcement.Enable", id);
//    return res;
//  }
//}