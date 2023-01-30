

using Domain.Entities;
using Infrastructure;
using Infrastructure.Common;
using System.Security.Cryptography.X509Certificates;

namespace Application.Manager
{
    public static class ProductMgr
    {
        public static List<Product> ListProductsByCategory(int categoryId,uint page,OrderByType type = OrderByType.Recommended)
        {
            var lastIdx = DbCacheHelper.Option.Get().PagingProductCount * ( page - 1);
            var products = EComDbContext.New().Products
                .Where(p => p.Category.Id == categoryId)
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

        public static Product? GetProduct(long productNo)
        {
            var ctx = EComDbContext.New();
            var product = ctx.Products.Where(x => x.Id == productNo).FirstOrDefault();
            return product;
        }

        public static Product? GetProductSingle(long productNo)
        {
            var ctx = EComDbContext.New();
            var product = ctx.Products.Where(x => x.Id == productNo).Single();
            return product;
        }
        //public static List<Product> SearchProduct(string value,LanguageType language)
        //{
        //    var ctx = EComDbContext.New();
        //    var product = from p in ctx.Products
        //                  join d in ctx.ProductDetails
        //                  on p.Id equals d.ProductId
        //                  select new
        //                  {
        //                      Product = p,
        //                      Detail = d
        //                  };
        //    var result = product
        //        .Where(x => x.Detail.Name.Contains(value) && x.Detail.LanguageId == (int)language);
            

        //    return product;
        //}

    }
}
