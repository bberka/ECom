using ECom.Application.Services.BaseServices;
using ECom.Domain.Abstract.Services.User;
using ECom.Domain.Entities;

namespace ECom.Application.Services.UserServices;

public class UserAnnouncementService : AnnouncementService,IUserAnnouncementService
{
  public UserAnnouncementService(IUnitOfWork unitOfWork) : base(unitOfWork) {
  }

  public List<AnnouncementDto> ListAnnouncements() {
    return UnitOfWork.AnnouncementRepository
      .Get(x => x.ExpireDate > DateTime.Now && !x.DeleteDate.HasValue)
      .Select(x => new AnnouncementDto() {
        Message = x.Message,
        Order = x.Order
      })
      .ToList();
  }

}