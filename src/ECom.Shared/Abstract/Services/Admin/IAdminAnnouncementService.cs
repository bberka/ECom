using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Admin;

public interface IAdminAnnouncementService : IAnnouncementService
{
  CustomResult DeleteAnnouncement(Guid id);
  CustomResult UpdateAnnouncement(UpdateAnnouncementRequest data);
  CustomResult UpdateAnnouncementsOrder(List<Announcement> activeAnnouncements);
  CustomResult AddAnnouncement(AnnouncementAddRequestDto data);
  List<Announcement> ListAnnouncements();
}