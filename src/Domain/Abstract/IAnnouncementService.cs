using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface IAnnouncementService
    {
        List<Announcement> GetAnnouncements();
        Result DeleteAnnouncement(uint id);
        Result EnableOrDisable(uint id);
        Result UpdateAnnouncement(Announcement data);
    }
}
