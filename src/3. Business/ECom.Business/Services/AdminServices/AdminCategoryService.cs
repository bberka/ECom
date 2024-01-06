namespace ECom.Business.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminCategoryService : IAdminCategoryService
{
  private readonly ICategoryService _categoryService;
  private readonly IUnitOfWork _unitOfWork;

  public AdminCategoryService(IUnitOfWork unitOfWork, ICategoryService categoryService) {
    _unitOfWork = unitOfWork;
    _categoryService = categoryService;
  }


  public Result UpdateCategoryOrdering(List<NestableListElementDto> categories) {
    var categoryList = ConvertToDbCategoryModel(categories);
    var dbData = _unitOfWork.Categories.ToList();
    foreach (var item in categoryList) {
      var dbItem = dbData.FirstOrDefault(x => x.NameKey == item.NameKey);
      if (dbItem is null) {
        _unitOfWork.Categories.Add(item);
      }
      else {
        dbItem.Order = item.Order;
        dbItem.MainCategoryNameKey = item.MainCategoryNameKey;
        // var isMainCtgDifferent = dbItem.MainCategoryNameKey != item.MainCategoryNameKey;
        // if (isMainCtgDifferent) {
        //  var dbSubCategories = dbData.Where(x => x.MainCategoryNameKey == dbItem.NameKey).ToList();
        //  foreach (var subCategory in dbSubCategories) {
        //    subCategory.MainCategoryNameKey = item.MainCategoryNameKey;
        //    _unitOfWork.Categories.Update(subCategory);
        //  }
        // }
        _unitOfWork.Categories.Update(dbItem);
      }
    }

    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UpdateCategoryOrdering));
    return DomResults.x_is_updated_successfully("category");
  }

  public Result AddCategory(Request_Category_Add model) {
    var exists = _unitOfWork.Categories.Any(x => x.NameKey == model.NameKey);
    if (exists) return DomResults.x_already_exists("category");
    var category = new Category {
      NameKey = model.NameKey,
      MainCategoryNameKey = model.MainCategoryNameKey,
      Order = 0,
      ShowAtFooter = false,
      ShowAtTopMenu = true,
      RegisterDate = DateTime.Now,
      Link = model.Link
    };
    _unitOfWork.Categories.Add(category);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(AddCategory));

    return DomResults.x_is_added_successfully("category");
  }

  public Result DeleteCategory(string key) {
    var category = _unitOfWork.Categories.Find(key);
    if (category is null) return DomResults.x_is_not_found("category");
    _unitOfWork.Categories.Remove(category);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(DeleteCategory));
    return DomResults.x_is_deleted_successfully("category");
  }

  public Result UpdateCategory(Request_Category_Update model) {
    throw new NotImplementedException();
  }

  private List<Category> ConvertToDbCategoryModel(List<NestableListElementDto> list) {
    //TODO: Optimize this to be more efficient and maybe use recursion
    //Note: Max 3 levels of nesting is allowed for categories Main > Sub > SubSub
    var resultList = new List<Category>();
    var mainCategoryOrderLast = 0;
    for (var i = 0; i < list.Count; i++) {
      var item = list[i];
      var mainCategory = new Category {
        NameKey = item.Id,
        Order = i,
        RegisterDate = DateTime.Now
      };
      resultList.Add(mainCategory);
      if (item.Children.Length > 0)
        for (var j = 0; j < item.Children.Length; j++) {
          var subItem = item.Children[j];
          var subCategory = new Category {
            NameKey = subItem.Id,
            Order = j,
            MainCategoryNameKey = mainCategory.NameKey
          };
          resultList.Add(subCategory);
          if (subItem.Children.Length > 0)
            for (var k = 0; k < subItem.Children.Length; k++) {
              var subSubItem = subItem.Children[k];
              var subSubCategory = new Category {
                NameKey = subSubItem.Id,
                Order = k,
                MainCategoryNameKey = subCategory.NameKey
              };
              resultList.Add(subSubCategory);
              if (subSubItem.Children.Length > 0) throw new Exception("Max 3 levels of nesting is allowed for categories Main > Sub > SubSub");
            }
        }
    }

    return resultList;
  }

  public List<Category> ListCategories() {
    return _unitOfWork.Categories
                      .ToList();
  }

  public Result UpdateCategoryOrdering(Request_Category_Update model) {
    var category = _unitOfWork.Categories.FirstOrDefault(x => x.NameKey == model.NameKey);
    if (category is null) return DomResults.x_is_not_found("category");
    category.NameKey = model.NameKey;
    category.MainCategoryNameKey = model.MainCategoryNameKey;
    _unitOfWork.Categories.Update(category);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UpdateCategoryOrdering));
    return DomResults.x_is_updated_successfully("category");
  }

  public Result AddCategory(Request_Category_Update model) {
    var category = new Category {
      NameKey = model.NameKey,
      MainCategoryNameKey = model.MainCategoryNameKey
    };
    _unitOfWork.Categories.Add(category);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(AddCategory));
    return DomResults.x_is_added_successfully("category");
  }
}