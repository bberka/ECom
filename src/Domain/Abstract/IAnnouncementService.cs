namespace ECom.Domain.Abstract;

public interface IAnnouncementService
{
  List<Announcement> ListAnnouncements();
  CustomResult DeleteAnnouncement(uint id);
  CustomResult EnableAnnouncement(uint id);
  CustomResult DisableAnnouncement(uint id);
  CustomResult UpdateAnnouncement(Announcement data);
  CustomResult AddAnnouncement(Announcement data);
}