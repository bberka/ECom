using ECom.Domain.ApiModels.Request;
using ECom.Domain.ApiModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ECom.Domain.Abstract
{
    public interface IProductService
    {
        bool Exists(int id);

        ResultData<Product> GetProduct(long productNo);

        /// <summary>
        /// </summary>
        /// <param name="productIds"></param>
        /// <param name="page"></param>
        /// <param name="culture"></param>
        /// <returns>
        /// <see cref="Product"/> list by given parameters with including <see cref="ProductVariant"/>, <see cref="ProductImage"/>, <see cref="ProductDetail"/>
        /// without including <see cref="ProductComment"/> or related data
        /// </returns>
        List<Product> GetProducts(List<int> productIds,ushort page,string culture = ConstantMgr.DefaultCulture);

        /// <summary>
        /// </summary>
        /// <param name="productIds"></param>
        /// <param name="page"></param>
        /// <param name="culture"></param>
        /// <returns>
        /// <see cref="Product"/> list by given parameters with including <see cref="ProductVariant"/>, <see cref="ProductImage"/>, <see cref="ProductDetail"/>
        /// without including <see cref="ProductComment"/> or related data
        /// </returns>
        List<Product> GetProducts(ushort page,string culture = ConstantMgr.DefaultCulture);

        /// <summary>
        /// </summary>
        /// <param name="productIds"></param>
        /// <param name="page"></param>
        /// <param name="culture"></param>
        /// <returns>
        /// <see cref="ProductComment"/> list by given parameters with including <see cref="ProductCommentImage"/>, <see cref="ProductCommentStar"/>
        /// </returns>
        List<ProductComment> GetProductComments(List<int> productIds, ushort page);

        /// <summary>
        /// </summary>
        /// <param name="productIds"></param>
        /// <param name="page"></param>
        /// <param name="culture"></param>
        /// <returns>
        /// <see cref="ProductComment"/> list by given parameters with including <see cref="ProductCommentImage"/>, <see cref="ProductCommentStar"/>
        /// </returns>
        List<ProductComment> GetProductComments(int productId,ushort page);

        ResultData<int> AddComment(AddProductCommentRequestModel model);

        //ResultData<int> AddCommentImage(IFormFile file, int userId,int commentId);
        //List<ProductDetail>? GetProductDetails(long productNo);
        //ProductDetail? GetProductDetails(long productNo, LanguageType type = LanguageType.Default);
        //ProductDetail GetProductDetailsSingle(long productNo, LanguageType type = LanguageType.Default);
        //Product? GetProductSingle(long productNo);
        //ProductVariant? GetVariant(int id);
        //List<Product> GetVariantProducts(int variantId);
        //List<ProductVariant> GetVariants();
        //ProductVariant GetVariantSingle(int id);
        //List<Product> ListProductsBaseByCategory(ListProductsByCategoryRequestModel model);
        //List<ProductSimpleResponseModel> ListProductsSimpleViewModel(ListProductsRequestModel model);
        //List<ProductSimpleResponseModel> ListProductsSimpleViewModelByCategory(ListProductsByCategoryRequestModel model);
    }
}
