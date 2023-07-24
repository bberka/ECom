using ECom.Domain.Aspects;
using ECom.Domain.Entities;

namespace ECom.Application.Services;

[PerformanceLoggerAspect]
[ExceptionHandlerAspect]
public class AnnouncementService : IAnnouncementService
{
  private const int MaxAnnouncementCount = 4;
  private readonly IUnitOfWork _unitOfWork;

  public AnnouncementService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public CustomResult UpdateAnnouncement(UpdateAnnouncementRequest data) {
    var dbData = _unitOfWork.AnnouncementRepository.Find(data.Id);
    if (dbData is null) return DomainResult.NotFound(nameof(Announcement));
    var isAlreadyExpired = dbData.ExpireDate < DateTime.Now;
    var isSetExpired = data.ExpireDate < DateTime.Now;
    if (isSetExpired && !isAlreadyExpired) return DomainResult.CannotSetExpired(nameof(Announcement));
    var maxCount = _unitOfWork.AnnouncementRepository.Count(x => !x.DeleteDate.HasValue && x.ExpireDate > DateTime.Now);
    //Checks equals because can not update an expired announcement without setting expire date to future
    if (maxCount >= MaxAnnouncementCount) return DomainResult.MaxCountReached(nameof(Announcement), MaxAnnouncementCount);
    dbData.Order = data.Order;
    dbData.Message = data.Message;
    dbData.UpdateDate = DateTime.UtcNow;
    dbData.ExpireDate = data.ExpireDate;
    _unitOfWork.AnnouncementRepository.Update(dbData);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAnnouncement));
    return DomainResult.OkUpdated(nameof(Announcement));
  }

  public CustomResult AddAnnouncement(AddAnnouncementRequest data) {
    var existsSameMessage = _unitOfWork.AnnouncementRepository.Any(x => x.Message == data.Message);
    if (existsSameMessage) return DomainResult.AlreadyExists(nameof(Announcement));
    var maxCount = _unitOfWork.AnnouncementRepository.Count(x => !x.DeleteDate.HasValue && x.ExpireDate > DateTime.Now);
    if (maxCount > MaxAnnouncementCount) return DomainResult.MaxCountReached(nameof(Announcement), MaxAnnouncementCount);
    _unitOfWork.AnnouncementRepository.Insert(Announcement.FromDto(data));
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddAnnouncement));
    return DomainResult.OkAdded(nameof(Announcement));
  }

  public CustomResult DeleteAnnouncement(Guid id) {
    var data = _unitOfWork.AnnouncementRepository.Find(id);
    if (data is null) return DomainResult.NotFound(nameof(Announcement));
    data.DeleteDate = DateTime.UtcNow;
    data.UpdateDate = DateTime.UtcNow;
    _unitOfWork.AnnouncementRepository.Update(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAnnouncement));
    return DomainResult.OkDeleted(nameof(Announcement));
  }

  public CustomResult RecoverAnnouncement(Guid id) {
    var data = _unitOfWork.AnnouncementRepository.Find(id);
    if (data is null) return DomainResult.NotFound(nameof(Announcement));
    data.DeleteDate = null;
    data.UpdateDate = DateTime.UtcNow;
    _unitOfWork.AnnouncementRepository.Update(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAnnouncement));
    return DomainResult.OkRecovered(nameof(Announcement));
  }

  public List<Announcement> ListAnnouncements() {
    return _unitOfWork.AnnouncementRepository.Get(x => x.ExpireDate > DateTime.Now && !x.DeleteDate.HasValue).ToList();
  }


}