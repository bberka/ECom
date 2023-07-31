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
  public CustomResult UpdateCompanyInformation(CompanyInformation info) {
    var isValidModel = info.IsValidModel();
    if (!isValidModel) {
      return DomainResult.InvalidState(CompanyInformation.LocKey);
    }
    info.Key = Key;
    var dbData = UnitOfWork.CompanyInformationRepository;
    UnitOfWork.CompanyInformationRepository.RemoveRange(dbData);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateCompanyInformation));
    UnitOfWork.CompanyInformationRepository.Add(info);
    var res2 = UnitOfWork.Save();
    if (!res2) return DomainResult.DbInternalError(nameof(UpdateCompanyInformation));
    SetCacheValue(info);
    return DomainResult.OkUpdated(CompanyInformation.LocKey);
  }
}