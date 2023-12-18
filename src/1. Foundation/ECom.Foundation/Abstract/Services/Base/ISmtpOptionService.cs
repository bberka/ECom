using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface ISmtpOptionService : ICacheService<List<SmtpOption>>
{
  List<SmtpOption> Get();
}