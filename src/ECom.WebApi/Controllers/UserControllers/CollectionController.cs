using ECom.Domain.Constants;

namespace ECom.WebApi.Controllers.UserControllers
{

    public class CollectionController : BaseUserController
    {
        private readonly ICollectionService _collectionService;
        private readonly ILogService _logService;

        public CollectionController(ICollectionService collectionService, ILogService logService)
        {
            this._collectionService = collectionService;
            _logService = logService;
        }
        [HttpGet]
        public ActionResult<ResultData<Collection>> Get(int collectionId)
        {
            var userId = HttpContext.GetUserId();
            var res =_collectionService.GetCollection(userId,collectionId);
            _logService.UserLog(res.ToResult(),userId,"Collection.Get",collectionId);
            return res.WithoutRv();
        }
        [HttpGet]
        public ActionResult<List<Collection>> List()
        {
            var userId = HttpContext.GetUserId();
            return _collectionService.GetCollections(userId);
        }
        [HttpGet]
        public ActionResult<ResultData<List<CollectionProduct>>> GetProducts(int id,ushort page,string culture = ConstantMgr.DefaultCulture)
        {
            var userId = HttpContext.GetUserId();
            var res = _collectionService.GetCollectionProducts(userId,id,page,culture);
            _logService.UserLog(res.ToResult(),userId,"Collection.GetProducts",id,page,culture);
            return res.WithoutRv();
        }
        [HttpPost]
        public ActionResult<Result> Create(CreateCollectionRequestModel model)
        {
            var res = _collectionService.CreateCollection(model);
            _logService.UserLog(res,model.AuthenticatedUserId,"Collection.Create",model.ToJsonString());
            return res.WithoutRv();
        }
        [HttpDelete]
        public ActionResult<Result> Delete(int collectionId)
        {
            var userId = HttpContext.GetUserId();
            var res = _collectionService.DeleteCollection(userId,collectionId);
            _logService.UserLog(res,userId,"Collection.Delete",collectionId);
            return res.WithoutRv();
        }

        [HttpPost]
        public ActionResult<Result> Update(UpdateCollectionRequestModel model)
        {
            var res = _collectionService.UpdateCollection(model);
            _logService.UserLog(res,model.AuthenticatedUserId,"Collection.Update",model.ToJsonString());
            return res.WithoutRv();
        }
    }
}
