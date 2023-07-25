using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Constants;
using ECom.Shared.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace ECom.Application.Services.BaseServices;

public abstract class CompanyInformationService : ICompanyInformationService
{
  protected const byte CACHE_REFRESH_INTERVAL_MINS = 1;
  protected const string CACHE_KEY = "company_info";
  protected readonly IMemoryCache MemoryCache;
  protected readonly IUnitOfWork UnitOfWork;
  protected const bool Key = true;
  protected CompanyInformationService(IMemoryCache memoryCache, IUnitOfWork unitOfWork) {
    MemoryCache = memoryCache;
    UnitOfWork = unitOfWork;
  }
  public CompanyInformation GetCompanyInformation() {
    var cache = MemoryCache.Get<CompanyInformation>(CACHE_KEY);
    if (cache is not null) return cache;
    var companyInformation = UnitOfWork.CompanyInformationRepository.FirstOrDefault(x => x.Key == Key);
    if (companyInformation is not null)
      MemoryCache.Set(CACHE_KEY, companyInformation, TimeSpan.FromMinutes(CACHE_REFRESH_INTERVAL_MINS));
    return new CompanyInformation();
  }




}