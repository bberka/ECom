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

        Result UpdateCargoOption(CargoOption option);
        Result UpdateOption(Option option);
        Result UpdatePaymentOption(PaymentOption option);
        Result UpdateSmtpOption(SmtpOption option);
    }
}
