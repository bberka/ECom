namespace ECom.Business.Services.BaseServices;

public class CargoOptionService : ICargoOptionService
{
  private readonly IMemoryCache _memoryCache;
  private readonly IUnitOfWork _unitOfWork;

  public CargoOptionService(IUnitOfWork unitOfWork, IMemoryCache memoryCache) {
    _unitOfWork = unitOfWork;
    _memoryCache = memoryCache;
  }

  public void ClearCache() {
    _memoryCache.Remove(CacheKeys.CargoOption);
  }

  public void SetCacheValue(List<CargoOption> data) {
    _memoryCache.Set(CacheKeys.CargoOption, data, TimeSpan.FromMinutes(CacheTimes.CargoOption));
  }

  public List<CargoOption>? GetFromCache() {
    return _memoryCache.Get<List<CargoOption>>(CacheKeys.CargoOption);
  }

  public List<CargoOption> GetFromDb() {
    var dbData = _unitOfWork.CargoOptions.AsNoTracking().ToList();
    if (dbData is null) throw new NotFoundException(nameof(CargoOption));
    return dbData;
  }

  public List<CargoOption> Get() {
    var cache = GetFromCache();
    if (cache is not null) return cache;
    var dbData = GetFromDb();
    SetCacheValue(dbData);
    return dbData;
  }
}