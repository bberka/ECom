namespace ECom.Business.Services.AdminServices;

public class AdminPaymentOptionService : IAdminPaymentOptionService
{
  private readonly IPaymentOptionService _paymentOptionService;
  private readonly IUnitOfWork _unitOfWork;

  public AdminPaymentOptionService(IUnitOfWork unitOfWork, IPaymentOptionService paymentOptionService) {
    _unitOfWork = unitOfWork;
    _paymentOptionService = paymentOptionService;
  }

  public Result UpdatePaymentOption(PaymentOption option) {
    option.Key = true;
    var dbData = _unitOfWork.PaymentOptions;
    _unitOfWork.PaymentOptions.RemoveRange(dbData);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdatePaymentOption));
    option.UpdateDate = DateTime.Now;
    _unitOfWork.PaymentOptions.Add(option);
    var res2 = _unitOfWork.Save();
    if (!res2) return DefResult.DbInternalError(nameof(UpdatePaymentOption));
    _paymentOptionService.ClearCache();
    return DefResult.OkUpdated(PaymentOption.LocKey);
  }
}