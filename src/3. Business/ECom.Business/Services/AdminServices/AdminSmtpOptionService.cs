using ECom.Foundation.Static;

namespace ECom.Business.Services.AdminServices;

public class AdminSmtpOptionService : IAdminSmtpOptionService
{
  private readonly ISmtpOptionService _smtpOptionService;
  private readonly IUnitOfWork _unitOfWork;

  public AdminSmtpOptionService(IUnitOfWork unitOfWork,
                                ISmtpOptionService smtpOptionService) {
    _unitOfWork = unitOfWork;
    _smtpOptionService = smtpOptionService;
  }

  public Result DeleteSmtpOption(Guid id) {
    var data = _unitOfWork.SmtpOptions.Find(id);
    if (data is null)
      return DomResults.x_is_not_found("smtp_option");
    _unitOfWork.SmtpOptions.Remove(data);
    var res = _unitOfWork.Save();
    if (!res)
      return DomResults.db_internal_error(nameof(DeleteSmtpOption));
    _smtpOptionService.ClearCache();
    return DomResults.x_is_deleted_successfully("smtp_option");
  }

  public Result UpdateSmtpOption(SmtpOption option) {
    var typeExists = _unitOfWork.SmtpOptions.Any(x => x.SmtpHostType == option.SmtpHostType && x.Id != option.Id);
    if (typeExists)
      return DomResults.x_already_exists("smtp_host_type");
    _unitOfWork.SmtpOptions.Update(option);
    var res = _unitOfWork.Save();
    if (!res)
      return DomResults.db_internal_error(nameof(UpdateSmtpOption));
    _smtpOptionService.ClearCache();
    return DomResults.x_is_updated_successfully("smtp_option");
  }

  public Result AddSmtpOption(SmtpOption model) {
    var typeExists = _unitOfWork.SmtpOptions.Any(x => x.SmtpHostType == model.SmtpHostType);
    if (typeExists)
      return DomResults.x_already_exists("smtp_host_type");
    _unitOfWork.SmtpOptions.Add(model);
    var res = _unitOfWork.Save();
    if (!res)
      return DomResults.db_internal_error(nameof(AddSmtpOption));
    _smtpOptionService.ClearCache();
    return DomResults.x_is_added_successfully("smtp_option");
  }
}