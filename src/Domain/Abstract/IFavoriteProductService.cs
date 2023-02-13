namespace ECom.Domain.Abstract
{
    public interface IFavoriteProductService
    {
        Result AddProduct(int userId, int productId);
        Result RemoveProduct(int userId, int productId);
        List<FavoriteProduct> GetFavoriteProducts(int userId, ushort page ,string culture = ConstantMgr.DefaultCulture);
    }
}
