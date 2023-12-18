namespace ECom.Business.Services.BaseServices;

public class CompanyInformationService : ICompanyInformationService
{
  private readonly IMemoryCache _memoryCache;
  private readonly IUnitOfWork _unitOfWork;


  public CompanyInformationService(IMemoryCache memoryCache, IUnitOfWork unitOfWork) {
    _memoryCache = memoryCache;
    _unitOfWork = unitOfWork;
  }

  public CompanyInformation Get() {
    var val = GetFromCache();
    if (val != null) return val;
    val = GetFromDb();
    SetCacheValue(val);
    return val;
  }

  public void ClearCache() {
    _memoryCache.Remove(CacheKeys.CompanyInformation);
  }

  public void SetCacheValue(CompanyInformation companyInformation) {
    _memoryCache.Set(CacheKeys.CompanyInformation, companyInformation, TimeSpan.FromMinutes(CacheTimes.CompanyInformation));
  }

  public CompanyInformation? GetFromCache() {
    var cache = _memoryCache.Get<CompanyInformation>(CacheKeys.CompanyInformation);
    return cache;
  }

  public CompanyInformation GetFromDb() {
    var companyInformation = _unitOfWork.CompanyInformation
                                        .AsNoTracking()
                                        .Single(x => x.Key == true);
    return companyInformation;
  }
}