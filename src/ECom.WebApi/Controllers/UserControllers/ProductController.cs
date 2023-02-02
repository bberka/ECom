

namespace ECom.WebApi.Controllers.UserControllers
{
    public class ProductController : BaseUserController
    {
        [HttpPost]
        public IActionResult ListProducts([FromBody] ListProductsModel model)
        {
            return Ok(ProductDal.This.ListProductsSimpleViewModel(model));
        }
    }
}
