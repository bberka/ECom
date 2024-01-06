using ECom.Foundation.Static;

namespace ECom.Business.Services.BaseServices;

public class SmtpOptionService : ISmtpOptionService
{
  private readonly IMemoryCache _memoryCache;
  private readonly IUnitOfWork _unitOfWork;

  public SmtpOptionService(IUnitOfWork unitOfWork, IMemoryCache memoryCache) {
    _unitOfWork = unitOfWork;
    _memoryCache = memoryCache;
  }

  public void ClearCache() {
    _memoryCache.Remove(CacheKeys.SmtpOption);
  }

  public void SetCacheValue(List<SmtpOption> data) {
    _memoryCache.Set(CacheKeys.SmtpOption, data, TimeSpan.FromMinutes(CacheTimes.SmtpOption));
  }

  public List<SmtpOption>? GetFromCache() {
    return _memoryCache.Get<List<SmtpOption>>(CacheKeys.SmtpOption);
  }

  public List<SmtpOption> GetFromDb() {
    var dbData = _unitOfWork.SmtpOptions.AsNoTracking().ToList();
    if (dbData is null) throw new NotFoundException(nameof(SmtpOption));
    return dbData;
  }

  public List<SmtpOption> Get() {
    var cache = GetFromCache();
    if (cache is not null) return cache;
    var dbData = GetFromDb();
    SetCacheValue(dbData);
    return dbData;
  }
}