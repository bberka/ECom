namespace ECom.Business.Services.BaseServices;

public class DiscountService : IDiscountService
{
  private readonly IUnitOfWork _unitOfWork;

  public DiscountService(IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }
}