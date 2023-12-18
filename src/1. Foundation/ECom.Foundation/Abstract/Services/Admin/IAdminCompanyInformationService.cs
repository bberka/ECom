using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminCompanyInformationService
{
  Result UpdateCompanyInformation(CompanyInformation info);
}