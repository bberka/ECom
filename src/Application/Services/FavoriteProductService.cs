using ECom.Domain.Entities;
using ECom.Shared.Constants;

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

  public CustomResult AddFavoriteProduct(Guid userId, Guid productId) {
    var userExist = _unitOfWork.UserRepository.Any(x => x.Id == userId);
    if (!userExist) return DomainResult.NotFound(nameof(User));
    var productExist = _productService.Exists(productId);
    if (!productExist) return DomainResult.NotFound(nameof(Product));
    var data = new FavoriteProduct {
      RegisterDate = DateTime.Now,
      ProductId = productId,
      UserId = userId
    };
    _unitOfWork.FavoriteProductRepository.Insert(data);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddFavoriteProduct));
    return DomainResult.OkAdded(nameof(FavoriteProduct));
  }

  public CustomResult RemoveFavoriteProduct(Guid userId, Guid productId) {
    var userExist = _unitOfWork.UserRepository.Any(x => x.Id == userId);
    if (!userExist) return DomainResult.NotFound(nameof(User));
    var favProduct =
      _unitOfWork.FavoriteProductRepository.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
    if (favProduct is null) return DomainResult.NotFound(nameof(FavoriteProduct));
    _unitOfWork.FavoriteProductRepository.Delete(favProduct);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(RemoveFavoriteProduct));

    return DomainResult.OkRemoved(nameof(FavoriteProduct));
  }

  public List<FavoriteProduct> GetFavoriteProducts(Guid userId) {
    return _unitOfWork.FavoriteProductRepository.Get(x => x.UserId == userId)
      .Include(x => x.Product)
      //.ThenInclude(x => x.Images)
      .ToList();
  }
}