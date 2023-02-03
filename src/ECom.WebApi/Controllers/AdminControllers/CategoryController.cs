﻿using ECom.Domain.Entities;
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
        public IActionResult Update([FromBody] CategoryUpdateModel category) 
        {
			var res = _categoryService.UpdateCategory(category);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, res.ErrorCode,res.Parameters, category.ToJsonString());
				return BadRequest(res.ToJsonString());
			}
			logger.Info(category.ToJsonString());
			return Ok(res);
		}
		
		[HttpDelete]
		public IActionResult Delete([FromBody] uint id)
		{
			var res = _categoryService.DeleteCategory(id);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, res.ErrorCode, res.Parameters, id);
				return BadRequest(res.ToJsonString());
			}
			logger.Info(id);
			return Ok(res);
		}
		[HttpPut]
		public IActionResult EnableOrDisable([FromBody] uint id)
		{
			var res = _categoryService.EnableOrDisable(id);
			if (!res.IsSuccess)
			{
				logger.Warn(res.Rv, res.ErrorCode, res.Parameters, id);
				return BadRequest(res.ToJsonString());
			}
			logger.Info(id);
			return Ok(res);
		}

	}
}
