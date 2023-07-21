using ECom.Domain.Entities;
using ECom.Shared.Constants;
using Microsoft.Extensions.Caching.Memory;

namespace ECom.Application.Services;

public class CompanyInformationService : ICompanyInformationService
{
  private const byte CACHE_REFRESH_INTERVAL_MINS = 1;
  private const string CACHE_KEY = "company_info";
  private readonly IMemoryCache _memoryCache;
  private readonly IUnitOfWork _unitOfWork;
  private bool Key = true;
  public CompanyInformationService(IMemoryCache memoryCache, IUnitOfWork unitOfWork) {
    _memoryCache = memoryCache;
    _unitOfWork = unitOfWork;
  }


  public CompanyInformation GetCompanyInformation() {
    var cache = _memoryCache.Get<CompanyInformation>(CACHE_KEY);
    if (cache is not null) return cache;
    var companyInformation = _unitOfWork.CompanyInformationRepository.GetFirstOrDefault(x => x.Key == Key);
    if (companyInformation is not null)
      _memoryCache.Set(CACHE_KEY, companyInformation, TimeSpan.FromMinutes(CACHE_REFRESH_INTERVAL_MINS));
    return new CompanyInformation();
  }



  public CustomResult UpdateOrAddCompanyInformation(CompanyInformation info) {
    var current = _unitOfWork.CompanyInformationRepository.GetFirstOrDefault(x => x.Key == info.Key);
    if (current != null) _unitOfWork.CompanyInformationRepository.Delete(current);
    _unitOfWork.CompanyInformationRepository.Insert(info);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateOrAddCompanyInformation));
    return DomainResult.OkUpdated(nameof(CompanyInformation));
  }
}