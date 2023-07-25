using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Admin;

public interface IAdminOptionService : IOptionService
{
  List<SmtpOption> ListSmtpOptions();
  List<CargoOption> ListCargoOptions();
  List<PaymentOption> ListPaymentOptions();
  CustomResult UpdateCargoOption(CargoOption option);
  CustomResult UpdateOption(Option option);
  CustomResult UpdatePaymentOption(PaymentOption option);
  CustomResult UpdateSmtpOption(SmtpOption option);
}