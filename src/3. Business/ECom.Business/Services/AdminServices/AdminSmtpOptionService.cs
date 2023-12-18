namespace ECom.Business.Services.AdminServices;

public class AdminSmtpOptionService : IAdminSmtpOptionService
{
  private readonly ISmtpOptionService _smtpOptionService;
  private readonly IUnitOfWork _unitOfWork;

  public AdminSmtpOptionService(IUnitOfWork unitOfWork, ISmtpOptionService smtpOptionService) {
    _unitOfWork = unitOfWork;
    _smtpOptionService = smtpOptionService;
  }

  public Result DeleteSmtpOption(Guid id) {
    var data = _unitOfWork.SmtpOptions.Find(id);
    if (data is null) return DefResult.NotFound(SmtpOption.LocKey);
    _unitOfWork.SmtpOptions.Remove(data);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(DeleteSmtpOption));
    _smtpOptionService.ClearCache();
    return DefResult.OkDeleted(SmtpOption.LocKey);
  }

  public Result UpdateSmtpOption(SmtpOption option) {
    var typeExists = _unitOfWork.SmtpOptions.Any(x => x.SmtpHostType == option.SmtpHostType && x.Id != option.Id);
    if (typeExists) return DefResult.AlreadyExists("smtp_host_type");
    _unitOfWork.SmtpOptions.Update(option);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdateSmtpOption));
    _smtpOptionService.ClearCache();
    return DefResult.OkUpdated(SmtpOption.LocKey);
  }

  public Result AddSmtpOption(SmtpOption model) {
    var typeExists = _unitOfWork.SmtpOptions.Any(x => x.SmtpHostType == model.SmtpHostType);
    if (typeExists) return DefResult.AlreadyExists("smtp_host_type");
    _unitOfWork.SmtpOptions.Add(model);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(AddSmtpOption));
    _smtpOptionService.ClearCache();
    return DefResult.OkAdded(SmtpOption.LocKey);
  }
}