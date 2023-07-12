namespace ECom.Domain.Abstract;

public interface IAnnouncementService
{
  List<Announcement> ListAnnouncements();
  Result DeleteAnnouncement(uint id);
  Result EnableOrDisable(uint id);
  Result UpdateAnnouncement(Announcement data);
  Result AddAnnouncement(Announcement data);
}