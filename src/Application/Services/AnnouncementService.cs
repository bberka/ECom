namespace ECom.Application.Services
{
	public interface IAnnouncementService 
	{
		List<Announcement> GetAnnouncements();
		Result DeleteAnnouncement(uint id);
		Result EnableOrDisable(uint id);
		Result UpdateAnnouncement(Announcement data);
	}

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
				return Result.Error(1, ErrCode.NotFound);
			}
			var res = _announcementRepo.Update(data);
			if (!res) return Result.Error(2, ErrCode.DbErrorInternal);
			return Result.Success(ErrCode.NotFound);
		}
		public Result DeleteAnnouncement(uint id)
		{
			if (!_announcementRepo.Any(x => x.Id == id))
			{
				return Result.Error(1, ErrCode.NotFound);
			}
			var res = _announcementRepo.Delete((int)id);
			if (!res) return Result.Error(2, ErrCode.DbErrorInternal);
			return Result.Success(ErrCode.Deleted);
		}
		public Result EnableOrDisable(uint id)
		{
			var data = _announcementRepo.Find((int)id);
			if (data == null)
			{
				return Result.Error(1, ErrCode.NotFound);
			}
			data.IsValid = !data.IsValid;
			var res = _announcementRepo.Update(data);
			if (res == false)
			{
				return Result.Error(2, ErrCode.DbErrorInternal);
			}
			return Result.Success(ErrCode.NotFound);
		}

		public List<Announcement> GetAnnouncements()
		{
			return _announcementRepo.GetList();
		}
	}
}
