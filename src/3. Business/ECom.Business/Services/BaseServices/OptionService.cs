namespace ECom.Business.Services.BaseServices;

public class OptionService : IOptionService
{
  private readonly IMemoryCache _memoryCache;
  private readonly IUnitOfWork _unitOfWork;

  public OptionService(IUnitOfWork unitOfWork, IMemoryCache memoryCache) {
    _unitOfWork = unitOfWork;
    _memoryCache = memoryCache;
  }

  public Option Get() {
    var cache = GetFromCache();
    if (cache is not null) return cache;
    var dbData = GetFromDb();
    SetCacheValue(dbData);
    return dbData;
  }

  public void ClearCache() {
    _memoryCache.Remove(CacheKeys.Option);
  }

  public void SetCacheValue(Option companyInformation) {
    _memoryCache.Set(CacheKeys.Option, companyInformation, TimeSpan.FromMinutes(CacheTimes.Option));
  }

  public Option? GetFromCache() {
    return _memoryCache.Get<Option>(CacheKeys.Option);
  }

  public Option GetFromDb() {
    var dbData = _unitOfWork.Options.AsNoTracking().Single(x => x.Key == true);
    if (dbData is null) throw new NotFoundException(nameof(Option));
    return dbData;
  }
}