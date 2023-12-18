namespace ECom.Business.Services.BaseServices;

public class EmailService : IEmailService
{
  private static readonly EasTask EmailTask = new();
  private readonly IOptionService _optionService;
  private readonly IUnitOfWork _unitOfWork;

  public EmailService(IUnitOfWork unitOfWork, IOptionService optionService) {
    _unitOfWork = unitOfWork;
    _optionService = optionService;
  }
}