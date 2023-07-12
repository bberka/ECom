namespace ECom.Application.Services;

public class OrderService : IOrderService
{
  private readonly IUnitOfWork _unitOfWork;

  public OrderService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }
}