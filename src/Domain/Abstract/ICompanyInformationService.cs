using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface ICompanyInformationService
{
  CompanyInformation GetCompanyInformation();
  CustomResult UpdateOrAddCompanyInformation(CompanyInformation info);
}