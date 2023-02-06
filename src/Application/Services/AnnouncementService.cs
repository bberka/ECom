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
                return Result.Error(1, ErrorCode.NotFound, nameof(Announcement));
            }
            var res = _announcementRepo.Update(data);
            if (!res)
            {
                return Result.DbInternal(2);
            }
            return Result.Success();
        }
        public Result DeleteAnnouncement(uint id)
        {
            if (!_announcementRepo.Any(x => x.Id == id))
            {
                return Result.Error(1, ErrorCode.NotFound, nameof(Announcement));
            }
            var res = _announcementRepo.Delete((int)id);
            if (!res)
            {
                return Result.DbInternal(2);
            }
            return Result.Success();
        }
        public Result EnableOrDisable(uint id)
        {
            var data = _announcementRepo.Find((int)id);
            if (data is null)
            {
                return Result.Error(1, ErrorCode.NotFound, nameof(Announcement));
            }
            data.IsValid = !data.IsValid;
            var res = _announcementRepo.Update(data);
            if (!res)
            {
                return Result.DbInternal(2);
            }
            return Result.Success();
        }

        public List<Announcement> GetAnnouncements()
        {
            return _announcementRepo.GetList();
        }
    }
}
