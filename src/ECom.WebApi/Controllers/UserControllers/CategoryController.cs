using ECom.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    [AllowAnonymous]
    public class CategoryController : BaseUserController
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        [ResponseCache(Duration = 60)]
        public ActionResult<List<Category>> List()
        {
            return _service.ListCategories();
        }

	}
}
