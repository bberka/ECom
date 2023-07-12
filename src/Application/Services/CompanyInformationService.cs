namespace ECom.Application.Services;

public class CompanyInformationService : ICompanyInformationService
{
  private const byte CACHE_REFRESH_INTERVAL_MINS = 1;
  private readonly IMemoryCache _memoryCache;
  private readonly IUnitOfWork _unitOfWork;

  public CompanyInformationService(IMemoryCache memoryCache, IUnitOfWork unitOfWork) {
    _memoryCache = memoryCache;
    _unitOfWork = unitOfWork;
  }


  public ResultData<CompanyInformation> GetCompanyInformation() {
    var companyInformation =
      _unitOfWork.CompanyInformationRepository.GetFirstOrDefault(x => x.IsRelease == !ConstantMgr.IsDevelopment());
    if (companyInformation is null) return DomainResult.CompanyInformation.NotFoundResult();
    return companyInformation;
  }

  public CompanyInformation? GetFromCache() {
    var cache = _memoryCache.Get<CompanyInformation>("company_info");
    if (cache is not null) return cache;
    cache = _unitOfWork.CompanyInformationRepository.GetFirstOrDefault(x => x.IsRelease == !ConstantMgr.IsDevelopment());
    if (cache is not null)
      _memoryCache.Set("company_info", cache, TimeSpan.FromMinutes(5));
    return cache;
  }

  public Result UpdateOrAddCompanyInformation(CompanyInformation info) {
    info.IsRelease = !ConstantMgr.IsDevelopment();
    var current = _unitOfWork.CompanyInformationRepository.GetFirstOrDefault(x => x.IsRelease == info.IsRelease);
    if (current != null) _unitOfWork.CompanyInformationRepository.Delete(current);
    _unitOfWork.CompanyInformationRepository.Insert(info);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.CompanyInformation.UpdateSuccessResult();
  }
}