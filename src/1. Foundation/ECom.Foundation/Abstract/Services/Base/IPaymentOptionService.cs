using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface IPaymentOptionService : ICacheService<PaymentOption>
{
  PaymentOption Get();
}