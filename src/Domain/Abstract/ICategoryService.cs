namespace ECom.Domain.Abstract;

public interface ICategoryService
{
  bool CategoryExists(int categoryId);
  CustomResult DeleteCategory(uint id);
  CustomResult DeleteSubCategory(uint id);
  CustomResult EnableCategory(uint id);
  CustomResult DisableCategory(uint id);
  CustomResult EnableSubCategory(uint id);
  CustomResult DisableSubCategory(uint id);
  List<Category> ListCategories();
  CustomResult UpdateCategory(UpdateCategoryRequest model);
  CustomResult UpdateSubCategory(SubCategory model);
  CustomResult AddCategory(AddCategoryRequest model);
  CustomResult AddSubCategory(AddSubCategoryRequest model);
}