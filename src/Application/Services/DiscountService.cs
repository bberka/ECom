namespace ECom.Application.Services;

public class DiscountService : IDiscountService
{
  private readonly IUnitOfWork _unitOfWork;

  public DiscountService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }
}