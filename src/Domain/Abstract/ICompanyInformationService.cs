namespace ECom.Domain.Abstract;

public interface ICompanyInformationService
{
  CustomResult<CompanyInformation> GetCompanyInformation();
  CompanyInformation? GetFromCache();
  CustomResult UpdateOrAddCompanyInformation(CompanyInformation info);
}