using ECom.Domain.Aspects;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Base;

namespace ECom.Application.Services.BaseServices;


public abstract class AnnouncementService : IAnnouncementService
{
  protected const int MaxAnnouncementCount = 4;
  protected readonly IUnitOfWork UnitOfWork;

  protected internal AnnouncementService(IUnitOfWork unitOfWork) {
    UnitOfWork = unitOfWork;
  }

}