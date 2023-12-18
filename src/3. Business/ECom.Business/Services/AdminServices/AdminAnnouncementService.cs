namespace ECom.Business.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminAnnouncementService : IAdminAnnouncementService
{
  private readonly IUnitOfWork _unitOfWork;

  public AdminAnnouncementService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public Result UpdateAnnouncement(Request_Announcement_Update data) {
    var dbData = _unitOfWork.Announcements.Find(data.Id);
    if (dbData is null) return DefResult.NotFound(nameof(Announcement));
    var isAlreadyExpired = dbData.ExpireDate < DateTime.Now;
    var isSetExpired = data.ExpireDate < DateTime.Now;
    if (isSetExpired && !isAlreadyExpired) return DefResult.CannotSetExpired(nameof(Announcement));
    var maxCount = _unitOfWork.Announcements.Count(x => x.ExpireDate > DateTime.Now);
    //Checks equals because can not update an expired announcement without setting expire date to future
    if (maxCount >= ConstantContainer.MaxAnnouncementCount) return DefResult.MaxCountReached(nameof(Announcement), ConstantContainer.MaxAnnouncementCount);
    dbData.Order = data.Order;
    dbData.Message = data.Message;
    dbData.UpdateDate = DateTime.UtcNow;
    dbData.ExpireDate = data.ExpireDate;
    _unitOfWork.Announcements.Update(dbData);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdateAnnouncement));
    return DefResult.OkUpdated(nameof(Announcement));
  }

  public Result UpdateAnnouncementsOrder(List<NestableListElementDto> activeAnnouncements) {
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
    var existsSameMessage = _unitOfWork.Announcements.Any(x => x.Message == data.Message);
    if (existsSameMessage) return DefResult.AlreadyExists(nameof(Announcement));
    var maxCount = _unitOfWork.Announcements.Count(x => x.ExpireDate > DateTime.Now);
    if (maxCount > ConstantContainer.MaxAnnouncementCount) return DefResult.MaxCountReached(nameof(Announcement), ConstantContainer.MaxAnnouncementCount);
    _unitOfWork.Announcements.Add(Announcement.FromDto(data));
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