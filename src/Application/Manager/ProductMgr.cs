

using Domain.DTOs;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Common;
using System.Security.Cryptography.X509Certificates;

namespace Application.Manager
{
    public static class ProductMgr
    {
        public static List<Product> ListProductsBaseByCategory(int categoryId, uint page, OrderByType type = OrderByType.Recommended)
        {
            var lastIdx = (int)(DbCacheHelper.Option.Get().PagingProductCount * (page - 1));
            var pageProductCount = DbCacheHelper.Option.Get().PagingProductCount;
            var products = EComDbContext.New().Products
                .Where(p => p.Category.Id == categoryId)
                .Skip(lastIdx)
                .Take(pageProductCount)
                .OrderByDescending(x => x.RegisterDate)
                .ToList();
            return products;
        }
        public static List<ProductSimpleViewModel> ListProductsSimpleViewModelByCategory(int categoryId, uint page, OrderByType type = OrderByType.Recommended)
        {
            var lastIdx = (int)(DbCacheHelper.Option.Get().PagingProductCount * (page - 1));
            var pageProductCount = DbCacheHelper.Option.Get().PagingProductCount;
            var ctx = EComDbContext.New();
            var products = ctx.Products
                .Where(p => p.CategoryId == categoryId)
                .Skip(lastIdx)
                .Take(pageProductCount)
                .OrderByDescending(x => x.RegisterDate)
                .Join(
                ctx.ProductDetails,
                x => x.Id,
                x => x.ProductId,
                (p, d) =>
                new ProductSimpleViewModel
                {
                    Product = p,
                    Details = d
                })
                .ToList();
            return products;
        }

        public static List<Product> GetVariantProducts(int variantId)
        {
            var ctx = EComDbContext.New();
            var list = ctx.Products.Where(x => x.ProductVariantId == variantId).ToList();
            return list;
        }

        public static List<ProductVariant> GetVariants()
        {
            var ctx = EComDbContext.New();
            return ctx.ProductVariants.ToList();
        }
        public static ProductVariant? GetVariant(int id)
        {
            var ctx = EComDbContext.New();
            return ctx.ProductVariants.Where(x => x.Id == id).FirstOrDefault();
        }
        public static ProductVariant GetVariantSingle(int id)
        {
            var ctx = EComDbContext.New();
            return ctx.ProductVariants.Where(x => x.Id == id).Single();
        }
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

        public static List<ProductDetails>? GetProductDetails(long productNo)
        {
            var ctx = EComDbContext.New();
            var products = ctx.ProductDetails.Where(x => x.Id == productNo).ToList();
            return products;
        }
        public static ProductDetails? GetProductDetails(long productNo, LanguageType type)
        {
            var ctx = EComDbContext.New();
            var product = ctx.ProductDetails.Where(x => x.Id == productNo && x.LanguageId == (int)type).FirstOrDefault();
            return product;
        }
        public static ProductDetails GetProductDetailsSingle(long productNo, LanguageType type)
        {
            var ctx = EComDbContext.New();
            var product = ctx.ProductDetails.Where(x => x.Id == productNo && x.LanguageId == (int)type).Single();
            return product;
        }



    }
}
