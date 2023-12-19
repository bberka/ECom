namespace ECom.Business.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminAnnouncementService : IAdminAnnouncementService
{
  private readonly IAdminRoleService _adminRoleService;
  private readonly IContentService _contentService;
  private readonly IUnitOfWork _unitOfWork;

  public AdminAnnouncementService(IUnitOfWork unitOfWork,
                                  IContentService contentService,
                                  IAdminRoleService adminRoleService) {
    _unitOfWork = unitOfWork;
    _contentService = contentService;
    _adminRoleService = adminRoleService;
  }

  public Result UpdateAnnouncement(Request_Announcement_Update data) {
    data.EnsureNotNull();
    data.ExpireDate.EnsureNotNull();
    data.Id.EnsureNotNull();
    data.Order.EnsureNotNull();
    data.Contents.EnsureOneElementAndNotNull();
    var dbData = _unitOfWork.Announcements.Find(data.Id);
    if (dbData is null) return DefResult.NotFound(nameof(Announcement));
    var isAlreadyExpired = dbData.ExpireDate < DateTime.Now;
    var isSetExpired = data.ExpireDate < DateTime.Now;
    if (isSetExpired && !isAlreadyExpired) return DefResult.CannotSetExpired(nameof(Announcement));
    var maxCount = _unitOfWork.Announcements.Count(x => x.ExpireDate > DateTime.Now);
    //Checks equals because can not update an expired announcement without setting expire date to future
    if (maxCount >= ConstantContainer.MaxAnnouncementCount) return DefResult.MaxCountReached(nameof(Announcement), ConstantContainer.MaxAnnouncementCount);
    var contentAsDictionary = data.Contents.ToDictionary(x => x.Language, x => x.Message);
    var contentId = Guid.NewGuid();
    var contentResult = _contentService.AddOrUpdateContents(contentId, contentAsDictionary);
    if (!contentResult.Status) return contentResult;
    dbData.Order = data.Order;
    dbData.ContentId = contentId;
    dbData.UpdateDate = DateTime.UtcNow;
    dbData.ExpireDate = data.ExpireDate;
    _unitOfWork.Announcements.Update(dbData);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError("update_announcement");
    return DefResult.OkUpdated("announcement");
  }

  public Result UpdateAnnouncementsOrder(List<NestableListElementDto> activeAnnouncements) {
    activeAnnouncements.EnsureNotNull();
    var idList = activeAnnouncements.Select(x => Guid.Parse(x.Id)).ToArray();
    var dbAnnouncements = _unitOfWork.Announcements.Where(x => idList.Contains(x.Id)).ToList();
    for (var i = 0; i < activeAnnouncements.Count; i++) {
      var item = activeAnnouncements[i];
      var dbData = dbAnnouncements.FirstOrDefault(x => x.Id == Guid.Parse(item.Id));
      if (dbData is null) continue;
      dbData.Order = i;
      dbData.UpdateDate = DateTime.Now;
      _unitOfWork.Announcements.Update(dbData);
    }

    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdateAnnouncementsOrder));
    return DefResult.OkUpdated(nameof(Announcement));
  }

  public Result AddAnnouncement(Request_Announcement_Add data) {
    data.EnsureNotNull();
    data.ExpireDate.EnsureNotNull();
    data.Order.EnsureNotNull();
    data.Contents.EnsureOneElementAndNotNull();
    //TODO: This check necessary ? 
    // var existsSameMessage = _unitOfWork.Announcements.Any(x => x.ContentId == data.Message);
    // if (existsSameMessage) return DefResult.AlreadyExists(nameof(Announcement));
    var totalAnnouncementCount = _unitOfWork.Announcements.Count(x => x.ExpireDate > DateTime.Now);
    if (totalAnnouncementCount > ConstantContainer.MaxAnnouncementCount)
      return DefResult.MaxCountReached(nameof(Announcement), ConstantContainer.MaxAnnouncementCount);
    var contentAsDictionary = data.Contents.ToDictionary(x => x.Language, x => x.Message);
    var contentId = Guid.NewGuid();
    var contentResult = _contentService.AddOrUpdateContents(contentId, contentAsDictionary);
    if (!contentResult.Status) return contentResult;
    var announcement = new Announcement {
      Id = Guid.NewGuid(),
      ContentId = contentId,
      ExpireDate = data.ExpireDate,
      Order = data.Order,
      RegisterDate = DateTime.Now,
    };
    _unitOfWork.Announcements.Add(announcement);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(AddAnnouncement));
    return DefResult.OkAdded(nameof(Announcement));
  }


  public Result DeleteAnnouncement(Guid id) {
    var data = _unitOfWork.Announcements.Find(id);
    if (data is null) return DefResult.NotFound(nameof(Announcement));
    _unitOfWork.Announcements.Remove(data);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(DeleteAnnouncement));
    return DefResult.OkDeleted(nameof(Announcement));
  }
}