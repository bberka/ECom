using ECom.Application.Services.BaseServices;
using ECom.Domain.Aspects;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Entities;

namespace ECom.Application.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminAnnouncementService : AnnouncementService, IAdminAnnouncementService, IAnnouncementService
{
  public AdminAnnouncementService(IUnitOfWork unitOfWork) : base(unitOfWork) {

  }
  public CustomResult UpdateAnnouncement(UpdateAnnouncementRequest data) {
    var dbData = UnitOfWork.Announcements.Find(data.Id);
    if (dbData is null) return DomainResult.NotFound(nameof(Announcement));
    var isAlreadyExpired = dbData.ExpireDate < DateTime.Now;
    var isSetExpired = data.ExpireDate < DateTime.Now;
    if (isSetExpired && !isAlreadyExpired) return DomainResult.CannotSetExpired(nameof(Announcement));
    var maxCount = UnitOfWork.Announcements.Count(x =>  x.ExpireDate > DateTime.Now);
    //Checks equals because can not update an expired announcement without setting expire date to future
    if (maxCount >= MaxAnnouncementCount) return DomainResult.MaxCountReached(nameof(Announcement), MaxAnnouncementCount);
    dbData.Order = data.Order;
    dbData.Message = data.Message;
    dbData.UpdateDate = DateTime.UtcNow;
    dbData.ExpireDate = data.ExpireDate;
    UnitOfWork.Announcements.Update(dbData);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAnnouncement));
    return DomainResult.OkUpdated(nameof(Announcement));
  }

  public CustomResult UpdateAnnouncementsOrder(List<Announcement> activeAnnouncements) {
    foreach (var item in activeAnnouncements) {
      var dbData = UnitOfWork.Announcements.Find(item.Id);
      if (dbData is null) return DomainResult.NotFound(nameof(Announcement));
      dbData.Order = item.Order;
      dbData.UpdateDate = DateTime.UtcNow;
      UnitOfWork.Announcements.Update(dbData);
    }
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAnnouncementsOrder));
    return DomainResult.OkUpdated(nameof(Announcement));
    
  }

  public CustomResult AddAnnouncement(AnnouncementAddRequestDto data) {
    var existsSameMessage = UnitOfWork.Announcements.Any(x => x.Message == data.Message);
    if (existsSameMessage) return DomainResult.AlreadyExists(nameof(Announcement));
    var maxCount = UnitOfWork.Announcements.Count(x => x.ExpireDate > DateTime.Now);
    if (maxCount > MaxAnnouncementCount) return DomainResult.MaxCountReached(nameof(Announcement), MaxAnnouncementCount);
    UnitOfWork.Announcements.Add(Announcement.FromDto(data));
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddAnnouncement));
    return DomainResult.OkAdded(nameof(Announcement));
  }

  public List<Announcement> ListAnnouncements() {
    return UnitOfWork.Announcements.Where(x => x.ExpireDate > DateTime.Now).ToList();
  }

  public CustomResult DeleteAnnouncement(Guid id) {
    var data = UnitOfWork.Announcements.Find(id);
    if (data is null) return DomainResult.NotFound(nameof(Announcement));
    UnitOfWork.Announcements.Remove(data);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAnnouncement));
    return DomainResult.OkDeleted(nameof(Announcement));
  }

 
}