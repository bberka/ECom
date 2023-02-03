﻿using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{

    public class CategoryController : BaseUserController
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult List()
        {
            var res = _service.ListCategories();
			logger.Info(res.ToJsonString());
			return Ok(res);
        }

	}
}
