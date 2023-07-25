using ECom.Domain.Abstract.Services.Base;

namespace ECom.Application.Services.BaseServices;

public abstract class OrderService : IOrderService
{
  protected readonly IUnitOfWork UnitOfWork;

  protected OrderService(IUnitOfWork unitOfWork) {
    UnitOfWork = unitOfWork;
  }
}