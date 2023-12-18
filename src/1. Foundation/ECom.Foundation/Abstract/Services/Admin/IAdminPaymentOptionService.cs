using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminPaymentOptionService
{
  Result UpdatePaymentOption(PaymentOption option);
}