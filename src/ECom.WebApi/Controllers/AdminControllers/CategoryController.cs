using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{

    public class CategoryController : BaseAdminController
    {
        [HttpGet]
        public IActionResult List()
        {
            var res = CategoryMgr.This.ListCategories();
			logger.Warn();
			return Ok(res.ToJsonString());
        }


		[HttpPost]
        public IActionResult Update([FromBody] Category category) 
        {
			var res = CategoryMgr.This.UpdateCategory(category);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, $"{res.ResponseAsInt}:{res.ResponseAsString}", category.ToJsonString());
				return BadRequest(res.ToJsonString());
			}
			logger.Warn(category.ToJsonString());
			return Ok(res);
		}
        [HttpPost]
		public IActionResult Delete([FromBody] int id)
		{
			var res = CategoryMgr.This.DeleteCategory(id);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, $"{res.ResponseAsInt}:{res.ResponseAsString}", id);
				return BadRequest(res.ToJsonString());
			}
			logger.Warn(id);
			return Ok(res);
		}
		[HttpPost]
		public IActionResult EnableOrDisable([FromBody] int id)
		{
			var res = CategoryMgr.This.EnableOrDisableCategory(id);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, $"{res.ResponseAsInt}:{res.ResponseAsString}", id);
				return BadRequest(res.ToJsonString());
			}
			logger.Warn(id);
			return Ok(res);
		}
	}
}
