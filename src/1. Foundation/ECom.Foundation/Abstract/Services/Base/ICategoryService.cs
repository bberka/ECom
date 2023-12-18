using ECom.Foundation.DTOs;

namespace ECom.Foundation.Abstract.Services.Base;

public interface ICategoryService : ICacheService<List<CategoryDto>>
{
  List<CategoryDto> Get();
}