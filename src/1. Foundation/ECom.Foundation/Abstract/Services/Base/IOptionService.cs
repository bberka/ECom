using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface IOptionService : ICacheService<Option>
{
  Option Get();
}