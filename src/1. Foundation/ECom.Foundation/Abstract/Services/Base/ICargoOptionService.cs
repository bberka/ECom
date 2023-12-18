using ECom.Foundation.Entities;

namespace ECom.Foundation.Abstract.Services.Base;

public interface ICargoOptionService : ICacheService<List<CargoOption>>
{
  List<CargoOption> Get();
}