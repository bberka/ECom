

using Infrastructure;
using Infrastructure.Common;

namespace Application.Manager
{
    public static class ProductMgr
    {
        public static List<Product> ListProductsByCategory(int categoryId,uint page,OrderByType type = OrderByType.Recommended)
        {
            var lastIdx = DbCacheHelper.Option.Get().PagingProductCount * ( page - 1);
            var products = EComDbContext.New().Products
                .Where(p => p.CategoryId == categoryId)
                .OrderByDescending(x => x.RegisterDate)
                .ToList();
            return products;
        }
        //public static List<Product> ListProductsByFilter(int categoryId, uint page, OrderByType type = OrderByType.Recommended)
        //{
        //    var lastIdx = Constants.PAGE_MAX_PRODUCT_COUNT * (page - 1);
        //    var ctx = new EComDbContext();
        //    var products = ctx.Products
        //        .Where(p => p.CategoryId == categoryId)
        //        .OrderByDescending(x => x.RegisterDate)
        //        .ToList();
        //    return products;
        //}
    }
}
