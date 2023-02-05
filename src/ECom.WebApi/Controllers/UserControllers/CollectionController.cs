using ECom.Domain.Abstract;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ECom.WebApi.Controllers.UserControllers
{
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
        [HttpGet]
        public IActionResult GetCollectionProducts(int id)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult CreateCollection(CreateCollectionRequestModel model)
        {
            var res = _collectionService.CreateCollection(model);
            if (!res.IsSuccess)
            {
                logger.Warn(res.Rv, res.ErrorCode, res.Parameters, model.ToJsonString());
                return BadRequest(res);
            }
            logger.Info(res.Rv, res.ErrorCode, res.Parameters, model.ToJsonString());
            return Ok();
        }
    }
}
