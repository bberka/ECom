namespace ECom.Business.Services.BaseServices;

public class CartService : ICartService
{
  private readonly IProductService _productService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IUserAccountService _userService;

  public CartService(
    IUnitOfWork unitOfWork,
    IUserAccountService userService,
    IProductService productService) {
    _unitOfWork = unitOfWork;
    _userService = userService;
    _productService = productService;
  }

  public Result AddOrIncreaseProduct(Guid userId, Guid productId) {
    var productExist = _productService.Exists(productId);
    if (!productExist)
      return DomResults.x_is_not_found("product");
    var existing = _unitOfWork.Carts.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
    if (existing != null) {
      existing.Count++;
      _unitOfWork.Carts.Update(existing);
    }
    else {
      var newBasket = new Cart {
        Count = 1,
        RegisterDate = DateTime.Now,
        ProductId = productId,
        UserId = userId,
        UpdateDate = DateTime.Now,
        DeleteDate = null
      };
      _unitOfWork.Carts.Add(newBasket);
    }

    var res = _unitOfWork.Save();
    if (!res)
      return DomResults.db_internal_error(nameof(AddOrIncreaseProduct));
    return DomResults.x_is_added_to_y_successfully("product", "cart");
  }

  public Result RemoveOrDecreaseProduct(Guid userId, Guid productId) {
    var exist = _unitOfWork.Carts.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
    if (exist is null)
      return DomResults.x_is_not_found("cart");
    if (exist.Count > 1) {
      exist.Count--;
      _unitOfWork.Carts.Update(exist);
    }
    else {
      _unitOfWork.Carts.Remove(exist);
    }

    var res = _unitOfWork.Save();
    if (!res)
      return DomResults.db_internal_error(nameof(RemoveOrDecreaseProduct));
    return DomResults.x_is_removed_successfully_from_y("product", "cart");
  }

  public int GetBasketProductCount(Guid userId) {
    return _unitOfWork.Carts.Count(x => x.UserId == userId);
  }

  public Result<List<Cart>> ListBasketProducts(Guid userId) {
    return _unitOfWork.Carts.Where(x => x.UserId == userId).ToList();
  }

  public Result ClearCartProducts(Guid userId) {
    var list = _unitOfWork.Carts.Where(x => x.UserId == userId);
    _unitOfWork.Carts.RemoveRange(list);
    var res = _unitOfWork.Save();
    if (!res)
      return DomResults.db_internal_error(nameof(ClearCartProducts));

    return DomResults.x_is_cleared_successfully("cart");
  }
}