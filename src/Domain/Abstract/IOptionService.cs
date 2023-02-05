using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface IOptionService
    {
        Option GetOption();
        List<CargoOption> GetCargoOptions();
        List<PaymentOption> GetPaymentOptions();
        List<SmtpOption> GetSmtpOptions();

        Option GetOptionFromCache();
        List<CargoOption> GetCargoOptionsFromCache();
        List<PaymentOption> GetPaymentOptionsFromCache();
        List<SmtpOption> GetSmtpOptionsFromCache();

        Result UpdateCargoOption(CargoOption option);
        Result UpdateOption(Option option);
        Result UpdatePaymentOption(PaymentOption option);
        Result UpdateSmtpOption(SmtpOption option);
        public void RefreshCache();
    }
}
