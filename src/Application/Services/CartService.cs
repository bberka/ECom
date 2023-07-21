using ECom.Domain.Entities;

namespace ECom.Application.Services;

public class CartService : ICartService
{
  private readonly IProductService _productService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IUserService _userService;

  public CartService(
    IUnitOfWork unitOfWork,
    IUserService userService,
    IProductService productService) {
    _unitOfWork = unitOfWork;
    _userService = userService;
    _productService = productService;
  }

  public CustomResult AddOrIncreaseProduct(Guid userId, Guid productId) {
    var productExist = _productService.Exists(productId);
    if (!productExist) return DomainResult.NotFound(nameof(Product));
    var existing = _unitOfWork.CartRepository.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
    if (existing != null) {
      existing.Count++;
      _unitOfWork.CartRepository.Update(existing);
    }
    else {
      var newBasket = new Cart {
        Count = 1,
        RegisterDate = DateTime.Now,
        ProductId = productId,
        UserId = userId,
        UpdateDate = DateTime.Now,
        DeleteDate = null,
      };
      _unitOfWork.CartRepository.Insert(newBasket);
    }

    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddOrIncreaseProduct));
    return DomainResult.OkAdded(nameof(Cart));
  }

  public CustomResult RemoveOrDecreaseProduct(Guid userId, Guid productId) {
    var exist = _unitOfWork.CartRepository.GetFirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
    if (exist is null) return DomainResult.NotFound(nameof(Cart));
    if (exist.Count > 1) {
      exist.Count--;
      _unitOfWork.CartRepository.Update(exist);
    }
    else {
      _unitOfWork.CartRepository.Delete(exist);
    }

    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(RemoveOrDecreaseProduct));

    return DomainResult.OkRemoved(nameof(Cart));
  }

  public int GetBasketProductCount(Guid userId) {
    return _unitOfWork.CartRepository.Count(x => x.UserId == userId);
  }

  public List<Cart> ListBasketProducts(Guid userId) {
    return _unitOfWork.CartRepository.Get(x => x.UserId == userId).ToList();
  }

  public CustomResult ClearCartProducts(Guid userId) {
    var list = _unitOfWork.CartRepository.Get(x => x.UserId == userId);
    _unitOfWork.CartRepository.DeleteRange(list);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(ClearCartProducts));
    return DomainResult.OkCleared(nameof(Cart));
  }
}