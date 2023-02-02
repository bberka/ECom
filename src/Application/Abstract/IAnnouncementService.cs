using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Abstract
{
	public interface IAnnouncementService 
	{
		public Result UpdateAnnouncement(Announcement data);
		public Result DeleteAnnouncement(uint id);
		public Result EnableOrDisable(uint id);
		public List<Announcement> GetList();
	}
}
