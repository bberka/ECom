namespace ECom.Domain.Abstract;

public interface ICompanyInformationService
{
  ResultData<CompanyInformation> GetCompanyInformation();
  CompanyInformation? GetFromCache();
  Result UpdateOrAddCompanyInformation(CompanyInformation info);
}