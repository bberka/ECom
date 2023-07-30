using ECom.Shared.Abstract.Services.Base;

namespace ECom.Shared.Abstract.Services.User;

public interface IUserAnnouncementService : IAnnouncementService
{
    List<AnnouncementDto> ListAnnouncements();

}