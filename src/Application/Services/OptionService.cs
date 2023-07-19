using ECom.Domain.Entities;
using ECom.Domain.Exceptions;
using ECom.Shared.Constants;

namespace ECom.Application.Services;

public class OptionService : IOptionService
{
  private const byte CACHE_REFRESH_INTERVAL_MINS = 10;

  private const string PAYMENT_OPTION_CACHE_KEY = "payment_option";
  private const string CARGO_OPTION_CACHE_KEY = "cargo_option";
  private const string SMTP_OPTION_CACHE_KEY = "smtp_option";
  private readonly IMemoryCache _memoryCache;
  private readonly IUnitOfWork _unitOfWork;

  public OptionService(IMemoryCache memoryCache, IUnitOfWork unitOfWork) {
    _memoryCache = memoryCache;
    _unitOfWork = unitOfWork;
  }


  public CustomResult UpdateOption(Option option) {
    _unitOfWork.OptionRepository.Update(option);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateOption));
    _memoryCache.Set("option", option, TimeSpan.FromMinutes(5));
    return DomainResult.OkUpdated(nameof(Option));
  }

  public CustomResult UpdateCargoOption(CargoOption option) {
    _unitOfWork.CargoOptionRepository.Update(option);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateCargoOption));
    return DomainResult.OkUpdated(nameof(UpdateCargoOption));
  }

  public CustomResult UpdatePaymentOption(PaymentOption option) {
    _unitOfWork.PaymentOptionRepository.Update(option);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdatePaymentOption));
    return DomainResult.OkUpdated(nameof(PaymentOption));
  }

  public CustomResult UpdateSmtpOption(SmtpOption option) {
    _unitOfWork.SmtpOptionRepository.Update(option);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateSmtpOption));
    return DomainResult.OkUpdated(nameof(SmtpOption));
  }


  public Option GetOption() {
    var cache = _memoryCache.Get<Option>("option");
    if (cache is not null) return cache;
    cache = _unitOfWork.OptionRepository.GetFirstOrDefault(x => x.IsRelease == !ConstantMgr.IsDevelopment());
    if (cache is null) throw new NotFoundException(nameof(Option));
    _memoryCache.Set("option", cache, TimeSpan.FromMinutes(5));
    return cache;
  }


  public List<CargoOption> ListCargoOptions() {
    var cache = _memoryCache.Get<List<CargoOption>>(CARGO_OPTION_CACHE_KEY);
    if (cache is not null) return cache;
    cache = _unitOfWork.CargoOptionRepository.Get(x => x.IsValid == true).ToList();
    _memoryCache.Set(CARGO_OPTION_CACHE_KEY, cache, TimeSpan.FromMinutes(5));
    return cache;
  }

  public List<PaymentOption> ListPaymentOptions() {
    var cache = _memoryCache.Get<List<PaymentOption>>(PAYMENT_OPTION_CACHE_KEY);
    if (cache is not null) return cache;
    cache = _unitOfWork.PaymentOptionRepository.Get(x => x.IsValid == true).ToList();
    _memoryCache.Set(PAYMENT_OPTION_CACHE_KEY, cache, TimeSpan.FromMinutes(5));
    return cache;
  }


  public List<SmtpOption> ListSmtpOptions() {
    var cache = _memoryCache.Get<List<SmtpOption>>(SMTP_OPTION_CACHE_KEY);
    if (cache is not null) return cache;
    cache = _unitOfWork.SmtpOptionRepository.Get(x => x.IsValid == true).ToList();
    _memoryCache.Set(SMTP_OPTION_CACHE_KEY, cache, TimeSpan.FromMinutes(5));
    return cache;
  }
}