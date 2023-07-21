using ECom.Domain.Entities;

namespace ECom.Application.Services;

public class AnnouncementService : IAnnouncementService
{
  private readonly IUnitOfWork _unitOfWork;

  public AnnouncementService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public CustomResult UpdateAnnouncement(UpdateAnnouncementRequest data) {
    var dbData = _unitOfWork.AnnouncementRepository.GetById(data.Id);
    if (dbData is null) return DomainResult.NotFound(nameof(Announcement));
    dbData.Order = data.Order;
    dbData.Message = data.Message;
    _unitOfWork.AnnouncementRepository.Update(dbData);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAnnouncement));
    return DomainResult.OkUpdated(nameof(Announcement));
  }

  public CustomResult AddAnnouncement(AddAnnouncementRequest data) {
    var existsSameMessage = _unitOfWork.AnnouncementRepository.Any(x => x.Message == data.Message);
    if (existsSameMessage) return DomainResult.AlreadyExists(nameof(Announcement));
    _unitOfWork.AnnouncementRepository.Insert(Announcement.FromDto(data));
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddAnnouncement));
    return DomainResult.OkAdded(nameof(Announcement));
  }

  public CustomResult DeleteAnnouncement(Guid id) {
    var data = _unitOfWork.AnnouncementRepository.GetById(id);
    if (data is null) return DomainResult.NotFound(nameof(Announcement));
    data.DeleteDate = DateTime.UtcNow;
    data.UpdateDate = DateTime.UtcNow;
    _unitOfWork.AnnouncementRepository.Update(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAnnouncement));
    return DomainResult.OkDeleted(nameof(Announcement));
  }

  public CustomResult RecoverAnnouncement(Guid id) {
    var data = _unitOfWork.AnnouncementRepository.GetById(id);
    if (data is null) return DomainResult.NotFound(nameof(Announcement));
    data.DeleteDate = null;
    data.UpdateDate = DateTime.UtcNow;
    _unitOfWork.AnnouncementRepository.Update(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAnnouncement));
    return DomainResult.OkRecovered(nameof(Announcement));
  }

  public List<Announcement> ListAnnouncements() {
    return _unitOfWork.AnnouncementRepository.Get().ToList();
  }


}