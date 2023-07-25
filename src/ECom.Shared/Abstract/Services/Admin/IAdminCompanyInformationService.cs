using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Entities;

namespace ECom.Shared.Abstract.Services.Admin;

public interface IAdminCompanyInformationService : ICompanyInformationService
{
  CustomResult UpdateOrAddCompanyInformation(CompanyInformation info);
}