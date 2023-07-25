using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Abstract.Services.User;
using ECom.Domain.Aspects;
using ECom.Domain.Entities;

namespace ECom.Application.Services.BaseServices;


public abstract class AnnouncementService : IAnnouncementService
{
  protected const int MaxAnnouncementCount = 4;
  protected readonly IUnitOfWork UnitOfWork;

  protected internal AnnouncementService(IUnitOfWork unitOfWork) {
    UnitOfWork = unitOfWork;
  }

}