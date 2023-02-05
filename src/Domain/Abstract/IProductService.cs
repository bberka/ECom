using ECom.Domain.ApiModels.Request;
using ECom.Domain.ApiModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface IProductService
    {
        void CheckExists(int id);
        void CheckExists(uint id);
        Product? GetProduct(long productNo);
        List<ProductDetail>? GetProductDetails(long productNo);
        ProductDetail? GetProductDetails(long productNo, LanguageType type = LanguageType.Default);
        ProductDetail GetProductDetailsSingle(long productNo, LanguageType type = LanguageType.Default);
        Product? GetProductSingle(long productNo);
        ProductVariant? GetVariant(int id);
        List<Product> GetVariantProducts(int variantId);
        List<ProductVariant> GetVariants();
        ProductVariant GetVariantSingle(int id);
        List<Product> ListProductsBaseByCategory(ListProductsByCategoryRequestModel model);
        List<ProductSimpleResponseModel> ListProductsSimpleViewModel(ListProductsRequestModel model);
        List<ProductSimpleResponseModel> ListProductsSimpleViewModelByCategory(ListProductsByCategoryRequestModel model);
    }
}
