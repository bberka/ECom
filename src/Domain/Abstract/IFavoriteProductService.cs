namespace ECom.Domain.Abstract;

public interface IFavoriteProductService
{
  CustomResult AddProduct(int userId, int productId);
  CustomResult RemoveProduct(int userId, int productId);
  List<FavoriteProduct> GetFavoriteProducts(int userId, ushort page, string culture = ConstantMgr.DefaultCulture);
}