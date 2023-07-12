namespace ECom.Application.Services;

public class AnnouncementService : IAnnouncementService
{
  private readonly IUnitOfWork _unitOfWork;

  public AnnouncementService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public Result UpdateAnnouncement(Announcement data) {
    if (!_unitOfWork.AnnouncementRepository.Any(x => x.Id == data.Id))
      return DomainResult.Announcement.NotFoundResult();
    _unitOfWork.AnnouncementRepository.Update(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Announcement.UpdateSuccessResult();
  }

  public Result AddAnnouncement(Announcement data) {
    _unitOfWork.AnnouncementRepository.Insert(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Announcement.AddSuccessResult();
  }

  public Result DeleteAnnouncement(uint id) {
    if (!_unitOfWork.AnnouncementRepository.Any(x => x.Id == id)) return DomainResult.Announcement.NotFoundResult();
    _unitOfWork.AnnouncementRepository.Delete((int)id);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Announcement.DeleteSuccessResult();
  }

  public Result EnableOrDisable(uint id) {
    var data = _unitOfWork.AnnouncementRepository.GetById((int)id);
    if (data is null) return DomainResult.Announcement.NotFoundResult();
    data.IsValid = !data.IsValid;
    _unitOfWork.AnnouncementRepository.Update(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Announcement.UpdateSuccessResult();
  }

  public List<Announcement> ListAnnouncements() {
    return _unitOfWork.AnnouncementRepository.Get().ToList();
  }
}