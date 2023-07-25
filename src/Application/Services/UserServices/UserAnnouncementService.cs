using ECom.Application.Services.BaseServices;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.User;

namespace ECom.Application.Services.UserServices;

public class UserAnnouncementService : AnnouncementService,IUserAnnouncementService
{
  public UserAnnouncementService(IUnitOfWork unitOfWork) : base(unitOfWork) {
  }

  public List<AnnouncementDto> ListAnnouncements() {
    return UnitOfWork.AnnouncementRepository
      .Get(x => x.ExpireDate > DateTime.Now)
      .Select(x => new AnnouncementDto() {
        Message = x.Message,
        Order = x.Order
      })
      .ToList();
  }

}