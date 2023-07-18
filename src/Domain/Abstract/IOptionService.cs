namespace ECom.Domain.Abstract;

public interface IOptionService
{
  Option GetOption();
  List<CargoOption> ListCargoOptions();
  List<PaymentOption> ListPaymentOptions();
  List<SmtpOption> ListSmtpOptions();

  CustomResult UpdateCargoOption(CargoOption option);
  CustomResult UpdateOption(Option option);
  CustomResult UpdatePaymentOption(PaymentOption option);
  CustomResult UpdateSmtpOption(SmtpOption option);
}