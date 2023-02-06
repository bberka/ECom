using ECom.Domain.ApiModels.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface ICategoryService
    {
        bool CategoryExists(int categoryId);
        Result DeleteCategory(uint id);
        Result DeleteSubCategory(uint id);
        Result EnableOrDisableCategory(uint id);
        Result EnableOrDisableSubCategory(uint id);
        List<Category> ListCategories();
        Result UpdateCategory(CategoryUpdateRequestModel model);
        Result UpdateSubCategory(SubCategory? data);
        Result AddCategory(AddCategoryRequestModel model);
        Result AddSubCategory(AddSubCategoryRequestModel model);
    }
}
