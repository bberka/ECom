using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Constants;
using ECom.Shared.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace ECom.Application.Services.BaseServices;

public abstract class CompanyInformationService : ICompanyInformationService
{
  protected const byte CacheRefreshIntervalMinutes = 1;
  protected const string CacheKey = "company_info";
  protected readonly IMemoryCache MemoryCache;
  protected readonly IUnitOfWork UnitOfWork;
  protected const bool Key = true;
  protected CompanyInformationService(IMemoryCache memoryCache, IUnitOfWork unitOfWork) {
    MemoryCache = memoryCache;
    UnitOfWork = unitOfWork;
  }
  public CompanyInformation GetCompanyInformation() {
    var val = GetFromCache();
    if (val != null) return val;
    val = GetFromDb();
    SetCacheValue(val);
    return val;
  }

  protected void ClearCache() {
    MemoryCache.Remove(CacheKey);
  }

  protected void SetCacheValue(CompanyInformation companyInformation) {
    MemoryCache.Set(CacheKey, companyInformation, TimeSpan.FromMinutes(CacheRefreshIntervalMinutes));
  }

  protected CompanyInformation? GetFromCache() {
    var cache = MemoryCache.Get<CompanyInformation>(CacheKey);
    return cache;
  }

  protected CompanyInformation GetFromDb() {
    var companyInformation = UnitOfWork.CompanyInformationRepository.Where(x => x.Key == Key).AsNoTracking().Single();
    return companyInformation;
  }
}