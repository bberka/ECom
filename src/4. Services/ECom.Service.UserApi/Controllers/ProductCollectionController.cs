using ECom.Foundation.Static;

namespace ECom.Service.UserApi.Controllers;

[AuthorizeUserOnly]
public class ProductCollectionController : UserControllerBase
{
  [FromServices]
  public IUserCollectionService UserCollectionService { get; set; }

  [FromServices]
  public ICollectionService CollectionService { get; set; }


  [Endpoint("/user/product/collection/create", HttpMethodType.POST)]
  public Result Create(Request_Collection_Add request) {
    var authId = HttpContext.GetAuthId();
    var res = UserCollectionService.CreateCollection(authId, request);
    LogService.UserLog(UserActionType.CreateProductCollection, res, authId, request.ToJsonString());
    return res;
  }

  [Endpoint("/user/product/collection/delete", HttpMethodType.DELETE)]
  public Result Delete(Guid id) {
    var userId = HttpContext.GetUserId();
    var res = UserCollectionService.DeleteCollection(userId, id);
    LogService.UserLog(UserActionType.DeleteCollection, res, userId, id);
    return res;
  }

  [Endpoint("/user/product/collection/get", HttpMethodType.GET)]
  public Result<Collection> Get(Guid id) {
    var userId = HttpContext.GetUserId();
    var res = CollectionService.GetCollection(userId, id);
    LogService.UserLog(UserActionType.GetCollection, res, userId, id);
    return res;
  }

  [Endpoint("/user/product/collection/list", HttpMethodType.GET)]
  public List<Collection> List() {
    var userId = HttpContext.GetUserId();
    var list = CollectionService.GetCollections(userId);
    LogService.UserLog(UserActionType.ListCollections, userId);
    return list;
  }

  // [Endpoint("/user/product/collection/list", HttpMethodType.GET)]
  // public Result<List<CollectionProduct>> GetProducts(int id, ushort page,string culture = ConstantMgr.DefaultLanguage) {
  //   throw new NotImplementedException();
  //   var userId = HttpContext.GetUserId();
  //   var res = _collectionService.GetCollectionProducts(userId, id, page, culture);
  //   _logService.UserLog(res.ToResult(), userId, "Collection.GetProducts", id, page, culture);
  //   return res.ToActionResult();
  // }

  [Endpoint("/user/product/collection/update", HttpMethodType.POST)]
  public Result Update(Request_Collection_Update request) {
    var authId = HttpContext.GetUserId();
    var res = UserCollectionService.UpdateCollection(authId, request);
    LogService.UserLog(UserActionType.UpdateCollection, res, authId, request.ToJsonString());
    return res;
  }
}