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
	}
}
