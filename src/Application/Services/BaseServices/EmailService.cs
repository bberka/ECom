using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Abstract.Services.Base;

namespace ECom.Application.Services.BaseServices;

public abstract class EmailService : IAdminEmailService
{
  protected readonly IOptionService OptionService;
  protected readonly IUnitOfWork UnitOfWork;

  protected EmailService(IUnitOfWork unitOfWork, IOptionService optionService) {
    UnitOfWork = unitOfWork;
    OptionService = optionService;
  }
}