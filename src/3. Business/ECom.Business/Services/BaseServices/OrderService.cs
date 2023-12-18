namespace ECom.Business.Services.BaseServices;

public class OrderService : IOrderService
{
  private readonly IUnitOfWork _unitOfWork;

  public OrderService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }
}