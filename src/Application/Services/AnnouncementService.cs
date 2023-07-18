using ECom.Domain;
using ECom.Domain.DTOs.AnnouncementDto;

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
    dbData.IsValid = data.IsValid;
    _unitOfWork.AnnouncementRepository.Update(dbData);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAnnouncement));
    return DomainResult.OkUpdated(nameof(Announcement));
  }

  public CustomResult AddAnnouncement(AddAnnouncementRequest data) {
    var existsSameMessage = _unitOfWork.AnnouncementRepository.Any(x => x.Message == data.Message);
    if (existsSameMessage) return DomainResult.AlreadyExists(nameof(Announcement));
    _unitOfWork.AnnouncementRepository.Insert(data.ToEntity());
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddAnnouncement));
    return DomainResult.OkAdded(nameof(Announcement));
  }

  public CustomResult DeleteAnnouncement(uint id) {
    if (!_unitOfWork.AnnouncementRepository.Any(x => x.Id == id)) return DomainResult.NotFound(nameof(Announcement));
    _unitOfWork.AnnouncementRepository.Delete((int)id);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAnnouncement));
    return DomainResult.OkDeleted(nameof(Announcement));
  }

  public CustomResult EnableAnnouncement(uint id) {
    var data = _unitOfWork.AnnouncementRepository.GetById((int)id);
    if (data is null) return DomainResult.NotFound(nameof(Announcement));
    if(data.IsValid) return DomainResult.AlreadyEnabled(nameof(Announcement));
    data.IsValid = true;
    _unitOfWork.AnnouncementRepository.Update(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(EnableAnnouncement));
    return DomainResult.OkUpdated(nameof(Announcement));
  }
  public CustomResult DisableAnnouncement(uint id) {
    var data = _unitOfWork.AnnouncementRepository.GetById((int)id);
    if (data is null) return DomainResult.NotFound(nameof(Announcement));
    if(!data.IsValid) return DomainResult.AlreadyDisabled(nameof(Announcement));
    data.IsValid = false;
    _unitOfWork.AnnouncementRepository.Update(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DisableAnnouncement));
    return DomainResult.OkUpdated(nameof(Announcement));
  }

  public List<Announcement> ListAnnouncements() {
    return _unitOfWork.AnnouncementRepository.Get().ToList();
  }
}