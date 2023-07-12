namespace ECom.Domain.Abstract;

public interface ICategoryService
{
  bool CategoryExists(int categoryId);
  Result DeleteCategory(uint id);
  Result DeleteSubCategory(uint id);
  Result EnableOrDisableCategory(uint id);
  Result EnableOrDisableSubCategory(uint id);
  List<Category> ListCategories();
  Result UpdateCategory(UpdateCategoryRequest model);
  Result UpdateSubCategory(SubCategory model);
  Result AddCategory(AddCategoryRequest model);
  Result AddSubCategory(AddSubCategoryRequest model);
}