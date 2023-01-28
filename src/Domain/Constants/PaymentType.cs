using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public enum PaymentType
    {
        None = 0,
        Iyzico = 1,
        PayTR = 2,
        Shopier = 3,
        Stripe = 4,
        Transfer = 5,
        CashOnDelivery = 6,
    }
}
