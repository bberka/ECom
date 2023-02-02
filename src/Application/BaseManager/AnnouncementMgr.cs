using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.BaseManager
{
	public class AnnouncementMgr : EfEntityRepositoryBase<Announcement, EComDbContext>
	{

		private AnnouncementMgr() { }
		public static AnnouncementMgr This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static AnnouncementMgr? Instance;

		public Result UpdateAnnouncement(Announcement data)
		{
			if (!Any(x => x.Id == data.Id))
			{
				return Result.Error(1, Response.AnnouncementNotFound);
			}
			var res = Update(data);
			if (!res) return Result.Error(2, Response.DbErrorInternal);
			return Result.Success(Response.AnnouncementUpdated);
		}
		public Result DeleteAnnouncement(uint id)
		{
			if (!Any(x => x.Id == id))
			{
				return Result.Error(1, Response.AnnouncementNotFound);
			}
			var res = Delete((int)id);
			if (!res) return Result.Error(2, Response.DbErrorInternal);
			return Result.Success(Response.AnnouncementDeleted);
		}
		public Result EnableOrDisable(uint id)
		{
			var data = Find((int)id);
			if (data == null)
			{
				return Result.Error(1, Response.AnnouncementNotFound);
			}
			data.IsValid = !data.IsValid;
			var res = Update(data);
			if (res == false)
			{
				return Result.Error(2, Response.DbErrorInternal);
			}
			return Result.Success(Response.AnnouncementUpdated);
		}
	}
}
