using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{

    public class CategoryController : BaseUserController
    {
        [HttpGet]
        public IActionResult List()
        {
            var res = CategoryDal.This.ListCategories();
			logger.Info();
			return Ok(res.ToJsonString());
        }

	}
}
