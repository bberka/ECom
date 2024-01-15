using ECom.Foundation.Static;

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
    if (dbData is null)
      return DomResults.x_is_not_found("announcement");
    var isAlreadyExpired = dbData.ExpireDate < DateTime.Now;
    var isSetExpired = data.ExpireDate < DateTime.Now;
    if (isSetExpired && !isAlreadyExpired)
      return DomResults.x_already_expired("announcement");
    var maxCount = _unitOfWork.Announcements.Count(x => x.ExpireDate > DateTime.Now);
    //Checks equals because can not update an expired announcement without setting expire date to future
    if (maxCount >= StaticValues.MAX_ANNOUNCEMENT_COUNT)
      return DomResults.max_count_reached(StaticValues.MAX_ANNOUNCEMENT_COUNT);
    var contentAsDictionary = data.Contents.ToDictionary(x => x.CultureType, x => x.Text);
    var contentId = Guid.NewGuid();
    var contentResult = _contentService.AddOrUpdateContents(contentId, contentAsDictionary);
    if (!contentResult.Status) return contentResult;
    dbData.Order = data.Order;
    dbData.ContentId = contentId;
    dbData.UpdateDate = DateTime.UtcNow;
    dbData.ExpireDate = data.ExpireDate;
    _unitOfWork.Announcements.Update(dbData);
    var res = _unitOfWork.Save();
    if (!res)
      return DomResults.db_internal_error(nameof(UpdateAnnouncement));
    return DomResults.x_is_updated_successfully("announcement");
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
    if (!res)
      return DomResults.db_internal_error(nameof(UpdateAnnouncementsOrder));
    return DomResults.x_is_updated_successfully("announcements");
  }

  public Result AddAnnouncement(Request_Announcement_Add data) {
    data.EnsureNotNull();
    data.ExpireDate.EnsureNotNull();
    data.Order.EnsureNotNull();
    // data.Content.EnsureOneElementAndNotNull();
    //TODO: This check necessary ? 
    // var existsSameMessage = _unitOfWork.Announcements.Any(x => x.ContentId == data.Key);
    // if (existsSameMessage) return DomResults.x_already_exists(nameof(Announcement));
    var totalAnnouncementCount = _unitOfWork.Announcements.Count(x => x.ExpireDate > DateTime.Now);
    if (totalAnnouncementCount > StaticValues.MAX_ANNOUNCEMENT_COUNT)
      return DomResults.max_count_reached(StaticValues.MAX_ANNOUNCEMENT_COUNT);
    throw new NotImplementedException();
    // var contentAsDictionary = data.Content.ToDictionary(x => x.CultureType, x => x.Message);
    // var contentId = Guid.NewGuid();
    // var contentResult = _contentService.AddOrUpdateContents(contentId, contentAsDictionary);
    // if (!contentResult.Status) return contentResult;
    // var announcement = new Announcement {
    //   Id = Guid.NewGuid(),
    //   ContentId = contentId,
    //   ExpireDate = data.ExpireDate,
    //   Order = data.Order,
    //   RegisterDate = DateTime.Now,
    // };
    // _unitOfWork.Announcements.Add(announcement);
    // var res = _unitOfWork.Save();
    // if (!res)
    //   return DomResults.db_internal_error(nameof(AddAnnouncement));
    //
    // return DomResults.x_is_added_successfully("announcement");
  }


  public Result DeleteAnnouncement(Guid id) {
    var data = _unitOfWork.Announcements.Find(id);
    if (data is null)
      return DomResults.x_is_not_found("announcement");
    _unitOfWork.Announcements.Remove(data);
    var res = _unitOfWork.Save();
    if (!res)
      return DomResults.db_internal_error(nameof(DeleteAnnouncement));
    return DomResults.x_is_deleted_successfully("announcement");
  }
}