namespace ECom.Business.Services.BaseServices;

public class PaymentOptionService : IPaymentOptionService
{
  private readonly IMemoryCache _memoryCache;
  private readonly IUnitOfWork _unitOfWork;

  public PaymentOptionService(IUnitOfWork unitOfWork, IMemoryCache memoryCache) {
    _unitOfWork = unitOfWork;
    _memoryCache = memoryCache;
  }

  public void ClearCache() {
    _memoryCache.Remove(CacheKeys.PaymentOption);
  }

  public void SetCacheValue(PaymentOption data) {
    _memoryCache.Set(CacheKeys.PaymentOption, data, TimeSpan.FromMinutes(CacheTimes.PaymentOption));
  }

  public PaymentOption? GetFromCache() {
    return _memoryCache.Get<PaymentOption>(CacheKeys.PaymentOption);
  }

  public PaymentOption GetFromDb() {
    var data = _unitOfWork.PaymentOptions.SingleOrDefault();
    if (data is null) throw new NotFoundException(nameof(PaymentOption));
    return data;
  }

  public PaymentOption Get() {
    var data = GetFromCache();
    if (data is not null) return data;
    data = GetFromDb();
    if (data is null) {
      var defPaymentOpt = new PaymentOption();
      _unitOfWork.PaymentOptions.Add(defPaymentOpt);
      var res = _unitOfWork.Save();
      if (!res) throw new DbInternalException(nameof(Get));
      data = defPaymentOpt;
    }

    SetCacheValue(data);
    return data;
  }
}