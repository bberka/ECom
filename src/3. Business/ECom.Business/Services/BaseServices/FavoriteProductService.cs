namespace ECom.Business.Services.BaseServices;

public class FavoriteProductService : IFavoriteProductService
{
  private readonly IProductService _productService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IUserAccountService _userService;


  public FavoriteProductService(
    IUnitOfWork unitOfWork,
    IProductService productService,
    IUserAccountService userService) {
    _unitOfWork = unitOfWork;
    _productService = productService;
    _userService = userService;
  }

  public List<FavoriteProduct> GetFavoriteProducts(Guid userId) {
    return _unitOfWork.FavoriteProducts.Where(x => x.UserId == userId)
                      .Include(x => x.Product)
                      //.ThenInclude(x => x.Images)
                      .ToList();
  }

  public Result AddFavoriteProduct(Guid userId, Guid productId) {
    var userExist = _unitOfWork.Users.Any(x => x.Id == userId);
    if (!userExist) return DefResult.NotFound(User.LocKey);
    var productExist = _productService.Exists(productId);
    if (!productExist) return DefResult.NotFound(nameof(Product));
    var data = new FavoriteProduct {
      RegisterDate = DateTime.Now,
      ProductId = productId,
      UserId = userId
    };
    _unitOfWork.FavoriteProducts.Add(data);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(AddFavoriteProduct));
    return DefResult.OkAdded(nameof(FavoriteProduct));
  }

  public Result RemoveFavoriteProduct(Guid userId, Guid productId) {
    var userExist = _unitOfWork.Users.Any(x => x.Id == userId);
    if (!userExist) return DefResult.NotFound(User.LocKey);
    var favProduct =
      _unitOfWork.FavoriteProducts.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
    if (favProduct is null) return DefResult.NotFound(nameof(FavoriteProduct));
    _unitOfWork.FavoriteProducts.Remove(favProduct);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(RemoveFavoriteProduct));

    return DefResult.OkRemoved(nameof(FavoriteProduct));
  }
}