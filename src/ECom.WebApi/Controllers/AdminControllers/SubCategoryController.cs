using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{

    public class SubCategoryController : BaseAdminController
    {
		private readonly ISubCategoryService _subCategoryService;
		public SubCategoryController(ISubCategoryService subCategoryService)
		{
			_subCategoryService = subCategoryService;
		}
		[HttpPost]
        public IActionResult Update([FromBody] SubCategory category) 
        {
			var res = _subCategoryService.UpdateSubCategory(category);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, $"{res.ResponseAsInt}:{res.ResponseAsString}", category.ToJsonString());
				return BadRequest(res.ToJsonString());
			}
			logger.Info(category.ToJsonString());
			return Ok(res);
		}
		
		[HttpDelete]
		public IActionResult Delete([FromBody] uint id)
		{
			var res = _subCategoryService.DeleteSubCategory(id);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, $"{res.ResponseAsInt}:{res.ResponseAsString}", id);
				return BadRequest(res.ToJsonString());
			}
			logger.Info(id);
			return Ok(res);
		}
		[HttpPut]
		public IActionResult EnableOrDisable([FromBody] uint id)
		{
			var res = _subCategoryService.EnableOrDisable(id);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, $"{res.ResponseAsInt}:{res.ResponseAsString}", id);
				return BadRequest(res.ToJsonString());
			}
			logger.Info(id);
			return Ok(res);
		}

	}
}
