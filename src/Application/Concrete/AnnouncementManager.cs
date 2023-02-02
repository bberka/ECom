using ECom.Application.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Infrastructure.Concrete;
using ECom.Infrastructure.Abstract;

namespace ECom.Application.Concrete
{
	public class AnnouncementManager : IAnnouncementService
	{
		private readonly IAnnouncementDal _dal;
		public AnnouncementManager(IAnnouncementDal dal)
		{
			_dal = dal;
		}
		public List<Announcement> GetList()
		{
			return _dal.GetList();
		}
		public Result UpdateAnnouncement(Announcement data)
		{
			if (!_dal.Any(x => x.Id == data.Id))
			{
				return Result.Error(1, Response.AnnouncementNotFound);
			}
			var res = _dal.Update(data);
			if (!res) return Result.Error(2, Response.DbErrorInternal);
			return Result.Success(Response.AnnouncementUpdated);
		}
		public Result DeleteAnnouncement(uint id)
		{
			if (!_dal.Any(x => x.Id == id))
			{
				return Result.Error(1, Response.AnnouncementNotFound);
			}
			var res = _dal.Delete((int)id);
			if (!res) return Result.Error(2, Response.DbErrorInternal);
			return Result.Success(Response.AnnouncementDeleted);
		}
		public Result EnableOrDisable(uint id)
		{
			var data = _dal.Find((int)id);
			if (data == null)
			{
				return Result.Error(1, Response.AnnouncementNotFound);
			}
			data.IsValid = !data.IsValid;
			var res = _dal.Update(data);
			if (res == false)
			{
				return Result.Error(2, Response.DbErrorInternal);
			}
			return Result.Success(Response.AnnouncementUpdated);
		}
	}
}
