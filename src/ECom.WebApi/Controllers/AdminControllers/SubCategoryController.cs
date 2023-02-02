using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.AdminControllers
{

    public class SubCategoryController : BaseAdminController
    {

		[HttpPost]
        public IActionResult Update([FromBody] SubCategory category) 
        {
			var res = SubCategoryMgr.This.UpdateSubCategory(category);
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
			var res = SubCategoryMgr.This.DeleteSubCategory(id);
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
			var res = SubCategoryMgr.This.EnableOrDisable(id);
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
