using ECom.Domain.Results;

namespace ECom.Application.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IEfEntityRepository<Announcement> _announcementRepo;

        public AnnouncementService(IEfEntityRepository<Announcement> announcementRepo)
        {
            this._announcementRepo = announcementRepo;
        }
        public Result UpdateAnnouncement(Announcement data)
        {
            if (!_announcementRepo.Any(x => x.Id == data.Id))
            {
                return DomainResult.Announcement.NotFoundResult(1);
            }
            var res = _announcementRepo.Update(data);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.Announcement.UpdateSuccessResult();
        }

        public Result AddAnnouncement(Announcement data)
        {
            var res = _announcementRepo.Add(data);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            return DomainResult.Announcement.AddSuccessResult();
        }

        public Result DeleteAnnouncement(uint id)
        {
            if (!_announcementRepo.Any(x => x.Id == id))
            {
                return DomainResult.Announcement.NotFoundResult(1);
            }
            var res = _announcementRepo.Delete((int)id);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);

            }
            return DomainResult.Announcement.DeleteSuccessResult();
        }
        public Result EnableOrDisable(uint id)
        {
            var data = _announcementRepo.Find((int)id);
            if (data is null)
            {
                return DomainResult.Announcement.NotFoundResult(1);
            }
            data.IsValid = !data.IsValid;
            var res = _announcementRepo.Update(data);
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(2);
            }
            return DomainResult.Announcement.UpdateSuccessResult();
        }

        public List<Announcement> GetAnnouncements()
        {
            return _announcementRepo.GetList();
        }
    }
}
