using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Entities;
using ECom.Domain.Exceptions;

namespace ECom.Application.Services.BaseServices;

public abstract class OptionService : IOptionService
{
  protected readonly IUnitOfWork UnitOfWork;
  protected readonly IMemoryCache MemoryCache;

  protected OptionService(IUnitOfWork unitOfWork,IMemoryCache memoryCache) {
    UnitOfWork = unitOfWork;
    MemoryCache = memoryCache;
  }

  public Option GetOption() {
    var cache = MemoryCache.Get<Option>("option");
    if (cache is not null) return cache;
    cache = UnitOfWork.OptionRepository.FirstOrDefault(x => x.Key == true);
    if (cache is null) throw new NotFoundException(nameof(Option));
    MemoryCache.Set("option", cache, TimeSpan.FromMinutes(5));
    return cache;
  }
}