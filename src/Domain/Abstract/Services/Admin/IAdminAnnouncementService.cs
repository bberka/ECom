using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.Admin;

public interface IAdminAnnouncementService : IAnnouncementService
{
  CustomResult DeleteAnnouncement(Guid id);
  CustomResult RecoverAnnouncement(Guid id);
  CustomResult UpdateAnnouncement(UpdateAnnouncementRequest data);
  CustomResult UpdateAnnouncementsOrder(List<Announcement> activeAnnouncements);
  CustomResult AddAnnouncement(AddAnnouncementRequest data);
  List<Announcement> ListAnnouncements();
}