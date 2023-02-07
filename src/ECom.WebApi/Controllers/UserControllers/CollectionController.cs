using ECom.Domain.Constants;

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
        public ActionResult<ResultData<Collection>> Get(int collectionId)
        {
            var userId = HttpContext.GetUserId();
            return _collectionService.GetCollection(userId,collectionId);
        }
        [HttpGet]
        public ActionResult<List<Collection>> List()
        {
            var userId = HttpContext.GetUserId();
            return _collectionService.GetCollections(userId);
        }
        [HttpGet]
        public ActionResult<ResultData<List<CollectionProduct>>> GetCollectionProducts(int id,ushort page,string culture = ConstantMgr.DefaultCulture)
        {
            var userId = HttpContext.GetUserId();
            return _collectionService.GetCollectionProducts(userId,id,page,culture);
        }
        [HttpPost]
        public ActionResult<Result> CreateCollection(CreateCollectionRequestModel model)
        {
            return _collectionService.CreateCollection(model);
        }
        [HttpDelete]
        public ActionResult<Result> Delete(int collectionId)
        {
            var userId = HttpContext.GetUserId();
            return _collectionService.DeleteCollection(userId,collectionId);
        }

        [HttpPost]
        public ActionResult<Result> Update(UpdateCollectionRequestModel model)
        {
            return _collectionService.UpdateCollection(model);
        }
    }
}
