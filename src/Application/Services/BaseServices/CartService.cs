using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Abstract.Services.User;
using ECom.Shared.Entities;

namespace ECom.Application.Services.BaseServices;

public abstract class CartService : ICartService
{
  protected readonly IProductService ProductService;
  protected readonly IUnitOfWork UnitOfWork;
  protected readonly IUserAccountService UserService;

  protected CartService(
    IUnitOfWork unitOfWork,
    IUserAccountService userService,
    IProductService productService) {
    UnitOfWork = unitOfWork;
    UserService = userService;
    ProductService = productService;
  }

  public CustomResult AddOrIncreaseProduct(Guid userId, Guid productId) {
    var productExist = ProductService.Exists(productId);
    if (!productExist) return DomainResult.NotFound(nameof(Product));
    var existing = UnitOfWork.CartRepository.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
    if (existing != null) {
      existing.Count++;
      UnitOfWork.CartRepository.Update(existing);
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
      UnitOfWork.CartRepository.Insert(newBasket);
    }

    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddOrIncreaseProduct));
    return DomainResult.OkAdded(nameof(Cart));
  }

  public CustomResult RemoveOrDecreaseProduct(Guid userId, Guid productId) {
    var exist = UnitOfWork.CartRepository.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
    if (exist is null) return DomainResult.NotFound(nameof(Cart));
    if (exist.Count > 1) {
      exist.Count--;
      UnitOfWork.CartRepository.Update(exist);
    }
    else {
      UnitOfWork.CartRepository.Delete(exist);
    }

    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(RemoveOrDecreaseProduct));

    return DomainResult.OkRemoved(nameof(Cart));
  }

  public int GetBasketProductCount(Guid userId) {
    return UnitOfWork.CartRepository.Count(x => x.UserId == userId);
  }

  public List<Cart> ListBasketProducts(Guid userId) {
    return UnitOfWork.CartRepository.Get(x => x.UserId == userId).ToList();
  }

  public CustomResult ClearCartProducts(Guid userId) {
    var list = UnitOfWork.CartRepository.Get(x => x.UserId == userId);
    UnitOfWork.CartRepository.DeleteRange(list);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(ClearCartProducts));
    return DomainResult.OkCleared(nameof(Cart));
  }
}