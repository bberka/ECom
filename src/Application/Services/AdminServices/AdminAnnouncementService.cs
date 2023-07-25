using ECom.Application.Services.BaseServices;
using ECom.Domain.Abstract.Services.Admin;
using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Aspects;
using ECom.Domain.Entities;

namespace ECom.Application.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminAnnouncementService : AnnouncementService, IAdminAnnouncementService, IAnnouncementService
{
  public AdminAnnouncementService(IUnitOfWork unitOfWork) : base(unitOfWork) {

  }
  public CustomResult UpdateAnnouncement(UpdateAnnouncementRequest data) {
    var dbData = UnitOfWork.AnnouncementRepository.Find(data.Id);
    if (dbData is null) return DomainResult.NotFound(nameof(Announcement));
    var isAlreadyExpired = dbData.ExpireDate < DateTime.Now;
    var isSetExpired = data.ExpireDate < DateTime.Now;
    if (isSetExpired && !isAlreadyExpired) return DomainResult.CannotSetExpired(nameof(Announcement));
    var maxCount = UnitOfWork.AnnouncementRepository.Count(x => !x.DeleteDate.HasValue && x.ExpireDate > DateTime.Now);
    //Checks equals because can not update an expired announcement without setting expire date to future
    if (maxCount >= MaxAnnouncementCount) return DomainResult.MaxCountReached(nameof(Announcement), MaxAnnouncementCount);
    dbData.Order = data.Order;
    dbData.Message = data.Message;
    dbData.UpdateDate = DateTime.UtcNow;
    dbData.ExpireDate = data.ExpireDate;
    UnitOfWork.AnnouncementRepository.Update(dbData);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAnnouncement));
    return DomainResult.OkUpdated(nameof(Announcement));
  }

  public CustomResult UpdateAnnouncementsOrder(List<Announcement> activeAnnouncements) {
    foreach (var item in activeAnnouncements) {
      var dbData = UnitOfWork.AnnouncementRepository.Find(item.Id);
      if (dbData is null) return DomainResult.NotFound(nameof(Announcement));
      dbData.Order = item.Order;
      dbData.UpdateDate = DateTime.UtcNow;
      UnitOfWork.AnnouncementRepository.Update(dbData);
    }
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAnnouncementsOrder));
    return DomainResult.OkUpdated(nameof(Announcement));
    
  }

  public CustomResult AddAnnouncement(AddAnnouncementRequest data) {
    var existsSameMessage = UnitOfWork.AnnouncementRepository.Any(x => x.Message == data.Message);
    if (existsSameMessage) return DomainResult.AlreadyExists(nameof(Announcement));
    var maxCount = UnitOfWork.AnnouncementRepository.Count(x => !x.DeleteDate.HasValue && x.ExpireDate > DateTime.Now);
    if (maxCount > MaxAnnouncementCount) return DomainResult.MaxCountReached(nameof(Announcement), MaxAnnouncementCount);
    UnitOfWork.AnnouncementRepository.Insert(Announcement.FromDto(data));
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddAnnouncement));
    return DomainResult.OkAdded(nameof(Announcement));
  }

  public List<Announcement> ListAnnouncements() {
    return UnitOfWork.AnnouncementRepository.Get(x => x.ExpireDate > DateTime.Now && !x.DeleteDate.HasValue).ToList();
  }

  public CustomResult DeleteAnnouncement(Guid id) {
    var data = UnitOfWork.AnnouncementRepository.Find(id);
    if (data is null) return DomainResult.NotFound(nameof(Announcement));
    data.DeleteDate = DateTime.UtcNow;
    data.UpdateDate = DateTime.UtcNow;
    UnitOfWork.AnnouncementRepository.Update(data);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAnnouncement));
    return DomainResult.OkDeleted(nameof(Announcement));
  }

  public CustomResult RecoverAnnouncement(Guid id) {
    var data = UnitOfWork.AnnouncementRepository.Find(id);
    if (data is null) return DomainResult.NotFound(nameof(Announcement));
    data.DeleteDate = null;
    data.UpdateDate = DateTime.UtcNow;
    UnitOfWork.AnnouncementRepository.Update(data);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAnnouncement));
    return DomainResult.OkRecovered(nameof(Announcement));
  }
}