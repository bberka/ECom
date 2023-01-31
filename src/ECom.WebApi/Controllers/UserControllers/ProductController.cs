﻿
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
    public class ProductController : BaseUserController
    {
        [HttpPost]
        public IActionResult ListProducts([FromBody] ListProductsModel model)
        {
            return Ok(ProductMgr.ListProductsSimpleViewModel(model));
        }
    }
}
