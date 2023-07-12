namespace ECom.Application.Services;

public class FavoriteProductService : IFavoriteProductService
{
  private readonly IProductService _productService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IUserService _userService;

  public FavoriteProductService(
    IUnitOfWork unitOfWork,
    IProductService productService,
    IUserService userService) {
    _unitOfWork = unitOfWork;
    _productService = productService;
    _userService = userService;
  }

  public Result AddProduct(int userId, int productId) {
    var userExist = _userService.Exists(userId);
    if (!userExist) return DomainResult.User.NotFoundResult();
    var productExist = _productService.Exists(productId);
    if (!productExist) return DomainResult.Product.NotFoundResult();
    var data = new FavoriteProduct {
      RegisterDate = DateTime.Now,
      ProductId = productId,
      UserId = userId
    };
    _unitOfWork.FavoriteProductRepository.Insert(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.FavoriteProduct.AddSuccessResult();
  }

  public Result RemoveProduct(int userId, int productId) {
    var userExist = _userService.Exists(userId);
    if (!userExist) return DomainResult.User.NotFoundResult();
    var favProduct =
      _unitOfWork.FavoriteProductRepository.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
    if (favProduct is null) return DomainResult.FavoriteProduct.NotFoundResult();
    _unitOfWork.FavoriteProductRepository.Delete(favProduct);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();

    return DomainResult.FavoriteProduct.RemoveSuccessResult();
  }

  public List<FavoriteProduct>
    GetFavoriteProducts(int userId, ushort page, string culture = ConstantMgr.DefaultCulture) {
    return _unitOfWork.FavoriteProductRepository
      .Get(x => x.UserId == userId)
      .Include(x => x.Product)
      //.ThenInclude(x => x.Images)
      .ToList();
  }
}