using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Abstract.Services.User;
using ECom.Shared.Constants;
using ECom.Shared.Entities;

namespace ECom.Application.Services.BaseServices;

public abstract class FavoriteProductService : IFavoriteProductService
{
    private readonly IProductService ProductService;
    private readonly IUnitOfWork UnitOfWork;
    private readonly IUserAccountService UserService;

    protected FavoriteProductService(
      IUnitOfWork unitOfWork,
      IProductService productService,
      IUserAccountService userService)
    {
        UnitOfWork = unitOfWork;
        ProductService = productService;
        UserService = userService;
    }

    public CustomResult AddFavoriteProduct(Guid userId, Guid productId)
    {
        var userExist = UnitOfWork.Users.Any(x => x.Id == userId);
        if (!userExist) return DomainResult.NotFound(nameof(User));
        var productExist = ProductService.Exists(productId);
        if (!productExist) return DomainResult.NotFound(nameof(Product));
        var data = new FavoriteProduct
        {
            RegisterDate = DateTime.Now,
            ProductId = productId,
            UserId = userId
        };
        UnitOfWork.FavoriteProducts.Add(data);
        var res = UnitOfWork.Save();
        if (!res) return DomainResult.DbInternalError(nameof(AddFavoriteProduct));
        return DomainResult.OkAdded(nameof(FavoriteProduct));
    }

    public CustomResult RemoveFavoriteProduct(Guid userId, Guid productId)
    {
        var userExist = UnitOfWork.Users.Any(x => x.Id == userId);
        if (!userExist) return DomainResult.NotFound(nameof(User));
        var favProduct =
          UnitOfWork.FavoriteProducts.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId);
        if (favProduct is null) return DomainResult.NotFound(nameof(FavoriteProduct));
        UnitOfWork.FavoriteProducts.Remove(favProduct);
        var res = UnitOfWork.Save();
        if (!res) return DomainResult.DbInternalError(nameof(RemoveFavoriteProduct));

        return DomainResult.OkRemoved(nameof(FavoriteProduct));
    }

    public List<FavoriteProduct> GetFavoriteProducts(Guid userId)
    {
        return UnitOfWork.FavoriteProducts.Where(x => x.UserId == userId)
          .Include(x => x.Product)
          //.ThenInclude(x => x.Images)
          .ToList();
    }
}