using ECom.Domain.Results;

namespace ECom.Application.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Result UpdateAnnouncement(Announcement data)
        {
            if (!_unitOfWork.AnnouncementRepository.Any(x => x.Id == data.Id))
            {
                return DomainResult.Announcement.NotFoundResult(1);
            }
            _unitOfWork.AnnouncementRepository.Update(data);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.Announcement.UpdateSuccessResult();
        }
        public Result AddAnnouncement(Announcement data)
        {
            _unitOfWork.AnnouncementRepository.Add(data);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            return DomainResult.Announcement.AddSuccessResult();
        }
        public Result DeleteAnnouncement(uint id)
        {
            if (!_unitOfWork.AnnouncementRepository.Any(x => x.Id == id))
            {
                return DomainResult.Announcement.NotFoundResult(1);
            }
            _unitOfWork.AnnouncementRepository.Delete((int)id);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);

            }
            return DomainResult.Announcement.DeleteSuccessResult();
        }
        public Result EnableOrDisable(uint id)
        {
            var data = _unitOfWork.AnnouncementRepository.Find((int)id);
            if (data is null)
            {
                return DomainResult.Announcement.NotFoundResult(1);
            }
            data.IsValid = !data.IsValid;
            _unitOfWork.AnnouncementRepository.Update(data);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.Announcement.UpdateSuccessResult();
        }
        public List<Announcement> ListAnnouncements()
        {
            return _unitOfWork.AnnouncementRepository.GetList();
        }
    }
}
