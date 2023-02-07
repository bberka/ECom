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
        [HttpPost]
        public ActionResult<ResultData<ListCollectionProductsResponseModel>> GetCollectionProducts([FromBody] int id)
        {
            var userId = HttpContext.GetUserId();
            return _collectionService.GetCollectionProducts(userId,id);
        }
        [HttpPost]
        public ActionResult<Result> CreateCollection(CreateCollectionRequestModel model)
        {
            return _collectionService.CreateCollection(model);
        }
    }
}
