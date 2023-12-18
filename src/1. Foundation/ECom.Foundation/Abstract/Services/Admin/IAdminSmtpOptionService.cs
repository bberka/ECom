using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminSmtpOptionService
{
  Result UpdateSmtpOption(SmtpOption option);
  Result AddSmtpOption(SmtpOption model);
  Result DeleteSmtpOption(Guid id);
}