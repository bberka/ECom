namespace ECom.Application.Services;

public class EmailService : IEmailService
{
  private readonly IOptionService _optionService;
  private readonly IUnitOfWork _unitOfWork;

  public EmailService(IUnitOfWork unitOfWork, IOptionService optionService) {
    _unitOfWork = unitOfWork;
    _optionService = optionService;
  }
}