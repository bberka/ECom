using ECom.Domain.Abstract;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Entities;
using ECom.WebApi.Filters;
using Microsoft.AspNetCore.Authorization;
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
        public ActionResult<List<Collection>> GetCollections()
        {
            var userId = HttpContext.GetUserId();
            return _collectionService.GetCollections(userId);
        }
        //[HttpPost]
        //public IActionResult GetCollectionProducts([FromBody] int id)
        //{
        //    return Ok();
        //}
        [HttpPost]
        public ActionResult<Result> CreateCollection(CreateCollectionRequestModel model)
        {
            return _collectionService.CreateCollection(model);
        }
    }
}
