using ECom.Application.Services.BaseServices;
using ECom.Domain.Aspects;
using ECom.Domain.Exceptions;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Constants;
using ECom.Shared.Entities;

namespace ECom.Application.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminOptionService : OptionService, IAdminOptionService, IOptionService
{
  protected const byte CacheRefreshIntervalMinutes = 10;
  protected const string PaymentOptionCacheKey = "payment_option";
  protected const string CargoOptionCacheKey = "cargo_option";
  protected const string SmtpOptionCacheKey = "smtp_option";

  public AdminOptionService(IMemoryCache memoryCache, IUnitOfWork unitOfWork) : base(unitOfWork,memoryCache) {
  }


  public CustomResult UpdateOption(Option option) {
    UnitOfWork.Options.Update(option);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateOption));
    MemoryCache.Set("option", option, TimeSpan.FromMinutes(5));
    return DomainResult.OkUpdated(nameof(Option));
  }

  public CustomResult UpdateCargoOption(CargoOption option) {
    UnitOfWork.CargoOptions.Update(option);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateCargoOption));
    return DomainResult.OkUpdated(nameof(UpdateCargoOption));
  }

  public CustomResult UpdatePaymentOption(PaymentOption option) {
    UnitOfWork.PaymentOptions.Update(option);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdatePaymentOption));
    return DomainResult.OkUpdated(nameof(PaymentOption));
  }

  public CustomResult UpdateSmtpOption(SmtpOption option) {
    UnitOfWork.SmtpOptions.Update(option);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateSmtpOption));
    return DomainResult.OkUpdated(nameof(SmtpOption));
  }





  public List<CargoOption> ListCargoOptions() {
    var cache = MemoryCache.Get<List<CargoOption>>(CargoOptionCacheKey);
    if (cache is not null) return cache;
    cache = UnitOfWork.CargoOptions.Where(x => x.DeleteDate.HasValue == false).ToList();
    MemoryCache.Set(CargoOptionCacheKey, cache, TimeSpan.FromMinutes(5));
    return cache;
  }

  public List<PaymentOption> ListPaymentOptions() {
    var cache = MemoryCache.Get<List<PaymentOption>>(PaymentOptionCacheKey);
    if (cache is not null) return cache;
    cache = UnitOfWork.PaymentOptions.Where(x => x.DeleteDate.HasValue == false).ToList();
    MemoryCache.Set(PaymentOptionCacheKey, cache, TimeSpan.FromMinutes(5));
    return cache;
  }


  public List<SmtpOption> ListSmtpOptions() {
    var cache = MemoryCache.Get<List<SmtpOption>>(SmtpOptionCacheKey);
    if (cache is not null) return cache;
    cache = UnitOfWork.SmtpOptions.Where(x => x.DeleteDate.HasValue == false).ToList();
    MemoryCache.Set(SmtpOptionCacheKey, cache, TimeSpan.FromMinutes(5));
    return cache;
  }
}