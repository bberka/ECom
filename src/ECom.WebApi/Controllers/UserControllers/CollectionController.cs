using ECom.Domain.Abstract;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Entities;
using ECom.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{

    [UserAuthFilter]
    public class CollectionController : BaseUserController
    {
        private readonly ICollectionService _collectionService;

        public CollectionController(ICollectionService collectionService)
        {
            this._collectionService = collectionService;
        }
        [HttpGet]
        public IActionResult GetCollections()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult GetCollectionProducts([FromBody] int id)
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateCollection(CreateCollectionRequestModel model)
        {
            var res = _collectionService.CreateCollection(model);
            logger.Info(res.Rv, res.ErrorCode, res.Parameters, model.ToJsonString());
            return Ok();
        }
    }
}
