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
        List<CargoOption> ListCargoOptions();
        List<PaymentOption> ListPaymentOptions();
        List<SmtpOption> ListSmtpOptions();

        Option GetOptionFromCache();
        List<CargoOption> ListCargoOptionsFromCache();
        List<PaymentOption> ListPaymentOptionsFromCache();
        List<SmtpOption> ListSmtpOptionsFromCache();

        Result UpdateCargoOption(CargoOption option);
        Result UpdateOption(Option option);
        Result UpdatePaymentOption(PaymentOption option);
        Result UpdateSmtpOption(SmtpOption option);
        public void RefreshCache();
    }
}
