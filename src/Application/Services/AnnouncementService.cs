namespace ECom.Application.Services
{
	public interface IAnnouncementService : IEfEntityRepository<Announcement>
	{
		Result DeleteAnnouncement(uint id);
		Result EnableOrDisable(uint id);
		Result UpdateAnnouncement(Announcement data);
	}

	public class AnnouncementService : EfEntityRepositoryBase<Announcement, EComDbContext>, IAnnouncementService
	{
		private readonly IOptionService _service;

		public AnnouncementService(IOptionService service)
		{
			this._service = service;
		}
		public Result UpdateAnnouncement(Announcement data)
		{
			if (!Any(x => x.Id == data.Id))
			{
				return Result.Error(1, ErrCode.NotFound);
			}
			var res = Update(data);
			if (!res) return Result.Error(2, ErrCode.DbErrorInternal);
			return Result.Success(ErrCode.NotFound);
		}
		public Result DeleteAnnouncement(uint id)
		{
			if (!Any(x => x.Id == id))
			{
				return Result.Error(1, ErrCode.NotFound);
			}
			var res = Delete((int)id);
			if (!res) return Result.Error(2, ErrCode.DbErrorInternal);
			return Result.Success(ErrCode.Deleted);
		}
		public Result EnableOrDisable(uint id)
		{
			var data = Find((int)id);
			if (data == null)
			{
				return Result.Error(1, ErrCode.NotFound);
			}
			data.IsValid = !data.IsValid;
			var res = Update(data);
			if (res == false)
			{
				return Result.Error(2, ErrCode.DbErrorInternal);
			}
			return Result.Success(ErrCode.NotFound);
		}
	}
}
