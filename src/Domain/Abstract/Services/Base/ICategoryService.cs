using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services.Base;

public interface ICategoryService
{
    List<CategoryDto> ListCategoriesDto();

}