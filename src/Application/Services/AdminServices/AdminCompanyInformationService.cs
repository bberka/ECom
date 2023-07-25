using ECom.Application.Services.BaseServices;
using ECom.Domain.Aspects;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Entities;

namespace ECom.Application.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminCompanyInformationService : CompanyInformationService, IAdminCompanyInformationService
{
  public AdminCompanyInformationService(IMemoryCache memoryCache, IUnitOfWork unitOfWork) : base(memoryCache, unitOfWork) {
  }
  public CustomResult UpdateOrAddCompanyInformation(CompanyInformation info) {
    var current = UnitOfWork.CompanyInformationRepository.FirstOrDefault(x => x.Key == info.Key);
    if (current != null) UnitOfWork.CompanyInformationRepository.Delete(current);
    UnitOfWork.CompanyInformationRepository.Insert(info);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateOrAddCompanyInformation));
    return DomainResult.OkUpdated(nameof(CompanyInformation));
  }
}