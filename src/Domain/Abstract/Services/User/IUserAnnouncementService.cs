using ECom.Domain.Abstract.Services.Base;

namespace ECom.Domain.Abstract.Services.User;

public interface IUserAnnouncementService : IAnnouncementService
{
    List<AnnouncementDto> ListAnnouncements();

}