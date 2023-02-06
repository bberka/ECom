using ECom.Domain.ApiModels.Request;
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
		public ActionResult<Result> AddCategory([FromBody] AddCategoryRequestModel model)
		{
			var res = _categoryService.AddCategory(model);
			return res;
		}
        [HttpPost]
        public ActionResult<Result> AddSubCategory([FromBody] AddSubCategoryRequestModel model)
        {
            var res = _categoryService.AddSubCategory(model);
            return res;
        }

        [HttpPost]
        public ActionResult<Result> Update([FromBody] CategoryUpdateRequestModel model) 
        {
			var res = _categoryService.UpdateCategory(model);
			return res;
		}
		
		[HttpDelete]
		public ActionResult<Result> Delete([FromBody] uint id)
		{
			//TODO: test
			var res = _categoryService.DeleteCategory(id);
			return res;
		}
		[HttpPut]
		public ActionResult<Result> EnableOrDisable([FromBody] uint id)
		{
			var res = _categoryService.EnableOrDisableCategory(id);
			return res;
		}

		[HttpPost]
		public ActionResult<Result> UpdateSubCategory([FromBody] SubCategory category)
		{
			var res = _categoryService.UpdateSubCategory(category);
			return res;
		}

		[HttpDelete]
		public ActionResult<Result> DeleteSubCategory([FromBody] uint id)
		{
			var res = _categoryService.DeleteSubCategory(id);
			return res;
		}
		[HttpPut]
		public ActionResult<Result> EnableOrDisableSubCategory([FromBody] uint id)
		{
			var res = _categoryService.EnableOrDisableSubCategory(id);
			return res;
		}

	}
}
