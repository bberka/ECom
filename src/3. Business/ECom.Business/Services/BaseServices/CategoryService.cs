namespace ECom.Business.Services.BaseServices;

public class CategoryService : ICategoryService
{
  private readonly IMemoryCache _memoryCache;
  private readonly IUnitOfWork _unitOfWork;

  public CategoryService(IUnitOfWork unitOfWork, IMemoryCache memoryCache) {
    _unitOfWork = unitOfWork;
    _memoryCache = memoryCache;
  }

  public List<CategoryDto> Get() {
    var cachedData = GetFromCache();
    if (cachedData is not null) return cachedData;
    var dbData = GetFromDb();
    SetCacheValue(dbData);
    return dbData;
  }

  public void ClearCache() {
    _memoryCache.Remove(CacheKeys.CategoryList);
  }

  public void SetCacheValue(List<CategoryDto> data) {
    _memoryCache.Set(CacheKeys.CategoryList, data, TimeSpan.FromMinutes(CacheTimes.CategoryList));
  }

  public List<CategoryDto>? GetFromCache() {
    return _memoryCache.Get<List<CategoryDto>>(CacheKeys.CategoryList);
  }

  public List<CategoryDto> GetFromDb() {
    var allCategories = _unitOfWork.Categories
                                   .AsNoTracking()
                                   .OrderBy(x => x.Order)
                                   .ToList();
    var result = Build(allCategories);
    return result;

    List<CategoryDto> Build(List<Category> categories,
                            string? parentNameKey = null) {
      var result = new List<CategoryDto>();
      var filteredCategories = categories.Where(x => x.MainCategoryNameKey == parentNameKey).OrderBy(x => x.Order).ToList();
      foreach (var category in filteredCategories) {
        var categoryDto = new CategoryDto {
          NameKey = category.NameKey,
          Order = category.Order,
          Categories = Build(categories, category.NameKey),
          Link = category.Link,
          Id = category.Id,
          MainCategoryNameKey = category.MainCategoryNameKey
        };
        result.Add(categoryDto);
      }

      return result.OrderBy(x => x.Order).ToList();
    }
  }
}