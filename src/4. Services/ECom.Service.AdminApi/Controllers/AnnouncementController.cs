using ECom.Business.Services;

namespace ECom.Service.AdminApi.Controllers;

public class AnnouncementController : AdminControllerBase
{
  [FromServices]
  public IAdminAnnouncementService AdminAnnouncementService { get; set; }

  [FromServices]
  public IAnnouncementService AnnouncementService { get; set; }

  [Endpoint("/admin/announcement/add", HttpMethodType.POST)]
  public Result Create(Request_Announcement_Add request) {
    var authId = HttpContext.GetAdminId();
    var res = AdminAnnouncementService.AddAnnouncement(request);
    LogService.AdminLog(AdminActionType.AddAnnouncement, res, authId, request);
    return res;
  }

  [Endpoint("/admin/announcement/update", HttpMethodType.POST)]
  public Result Update(Request_Announcement_Update request) {
    var authId = HttpContext.GetAdminId();
    var res = AdminAnnouncementService.UpdateAnnouncement(request);
    LogService.AdminLog(AdminActionType.UpdateAnnouncement, res, authId, request);
    return res;
  }
}