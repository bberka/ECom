namespace ECom.Domain.Abstract;

public interface ICategoryService
{
  bool CategoryExists(string key);
  CustomResult DeleteCategory(string key);
  //CustomResult DeleteSubCategory(uint id);
  CustomResult EnableCategory(string key);
  CustomResult DisableCategory(string key);
  //CustomResult EnableSubCategory(uint id);
  //CustomResult DisableSubCategory(uint id);
  List<Category> ListCategories();
  CustomResult UpdateCategory(AddOrUpdateCategoryRequest model);
  //CustomResult UpdateSubCategory(SubCategory model);
  CustomResult AddCategory(AddOrUpdateCategoryRequest model);
  //CustomResult AddSubCategory(AddSubCategoryRequest model);
}