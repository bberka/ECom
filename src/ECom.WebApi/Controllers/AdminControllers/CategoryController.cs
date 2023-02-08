using EasMe.Authorization.Filters;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Constants;
using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{

    public class CategoryController : BaseAdminController
    {
		private readonly ICategoryService _categoryService;
		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpPost]
        [HasPermission(AdminOperationType.Category_Add)]
        public ActionResult<Result> AddCategory([FromBody] AddCategoryRequestModel model)
		{
			var res = _categoryService.AddCategory(model);
			return res.WithoutRv();
		}
        [HttpPost]
        [HasPermission(AdminOperationType.Category_Add)]
        public ActionResult<Result> AddSubCategory([FromBody] AddSubCategoryRequestModel model)
        {
            var res = _categoryService.AddSubCategory(model);
            return res.WithoutRv();
        }

        [HttpPost]
        [HasPermission(AdminOperationType.Category_Update)]
        public ActionResult<Result> Update([FromBody] CategoryUpdateRequestModel model) 
        {
			var res = _categoryService.UpdateCategory(model);
			return res.WithoutRv();
		}
		
		[HttpDelete]
        [HasPermission(AdminOperationType.Category_Delete)]
        public ActionResult<Result> Delete([FromBody] uint id)
		{
			//TODO: test
			var res = _categoryService.DeleteCategory(id);
			return res.WithoutRv();
		}
		[HttpPut]
        [HasPermission(AdminOperationType.Category_Update)]
        public ActionResult<Result> EnableOrDisable([FromBody] uint id)
		{
			var res = _categoryService.EnableOrDisableCategory(id);
			return res.WithoutRv();
		}

		[HttpPost]
        [HasPermission(AdminOperationType.Category_Update)]
        public ActionResult<Result> UpdateSubCategory([FromBody] SubCategory category)
		{
			var res = _categoryService.UpdateSubCategory(category);
			return res.WithoutRv();
		}

		[HttpDelete]
        [HasPermission(AdminOperationType.CargoOption_Delete)]
        public ActionResult<Result> DeleteSubCategory([FromBody] uint id)
		{
			var res = _categoryService.DeleteSubCategory(id);
			return res.WithoutRv();
		}
		[HttpPut]
        [HasPermission(AdminOperationType.Category_Update)]
        public ActionResult<Result> EnableOrDisableSubCategory([FromBody] uint id)
		{
			var res = _categoryService.EnableOrDisableSubCategory(id);
			return res.WithoutRv();
		}

	}
}
