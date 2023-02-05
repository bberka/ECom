namespace ECom.Application.Services
{
	public class AnnouncementService : IAnnouncementService
	{
		private readonly IEfEntityRepository<Announcement> _announcementRepo;

		public AnnouncementService(IEfEntityRepository<Announcement>  announcementRepo)
		{
			this._announcementRepo = announcementRepo;
		}
		public Result UpdateAnnouncement(Announcement data)
		{
			if (!_announcementRepo.Any(x => x.Id == data.Id))
			{
				throw new NotFoundException(nameof(Announcement));
			}
			var res = _announcementRepo.Update(data);
			if (!res) throw new DbInternalException(nameof(UpdateAnnouncement));
			return Result.Success(ErrCode.NotFound);
		}
		public Result DeleteAnnouncement(uint id)
		{
			if (!_announcementRepo.Any(x => x.Id == id)) throw new NotFoundException(nameof(Announcement));
            var res = _announcementRepo.Delete((int)id);
            if (!res) throw new DbInternalException(nameof(DeleteAnnouncement));
			return Result.Success(ErrCode.Deleted);
		}
		public Result EnableOrDisable(uint id)
		{
			var data = _announcementRepo.Find((int)id);
			if (data is null) throw new NotFoundException(nameof(Announcement));
			data.IsValid = !data.IsValid;
			var res = _announcementRepo.Update(data);
            if (!res) throw new DbInternalException(nameof(EnableOrDisable));
			return Result.Success(ErrCode.NotFound);
		}

		public List<Announcement> GetAnnouncements()
		{
			return _announcementRepo.GetList();
		}
	}
}
