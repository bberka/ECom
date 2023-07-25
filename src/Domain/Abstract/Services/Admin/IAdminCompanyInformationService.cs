using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.Admin;

public interface IAdminCompanyInformationService : ICompanyInformationService
{
  CustomResult UpdateOrAddCompanyInformation(CompanyInformation info);
}