using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface ICompanyInformationService : ICacheService<CompanyInformation>
{
  CompanyInformation Get();
  void ClearCache();
  void SetCacheValue(CompanyInformation companyInformation);
  CompanyInformation? GetFromCache();
  CompanyInformation GetFromDb();
}