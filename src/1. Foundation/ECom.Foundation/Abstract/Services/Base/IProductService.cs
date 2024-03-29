﻿using ECom.Foundation.DTOs.Request;
using ECom.Foundation.Entities;
using ECom.Foundation.Static;

namespace ECom.Foundation.Abstract.Services.Base;

public interface IProductService
{
  bool Exists(Guid id);

  Result<Product> GetProduct(Guid productNo);

  /// <summary>
  /// </summary>
  /// <param name="productIds"></param>
  /// <param name="page"></param>
  /// <param name="cultures"></param>
  /// <returns>
  ///   <see cref="Product" /> list by given parameters with including <see cref="ProductVariant" />,
  ///   <see cref="ProductImage" />, <see cref="ProductDetail" />
  ///   without including <see cref="ProductComment" /> or related data
  /// </returns>
  List<Product> GetProducts(List<Guid> productIds, ushort page, CultureType culture = StaticValues.DEFAULT_LANGUAGE);

  /// <summary>
  /// </summary>
  /// <param name="productIds"></param>
  /// <param name="page"></param>
  /// <param name="cultures"></param>
  /// <returns>
  ///   <see cref="Product" /> list by given parameters with including <see cref="ProductVariant" />,
  ///   <see cref="ProductImage" />, <see cref="ProductDetail" />
  ///   without including <see cref="ProductComment" /> or related data
  /// </returns>
  List<Product> GetProducts(ushort page, CultureType culture = StaticValues.DEFAULT_LANGUAGE);

  /// <summary>
  /// </summary>
  /// <param name="productIds"></param>
  /// <param name="page"></param>
  /// <param name="culture"></param>
  /// <returns>
  ///   <see cref="ProductComment" /> list by given parameters with including <see cref="ProductCommentImage" />,
  ///   <see cref="ProductCommentStar" />
  /// </returns>
  List<ProductComment> GetProductComments(List<Guid> productIds, ushort page);

  /// <summary>
  /// </summary>
  /// <param name="productIds"></param>
  /// <param name="page"></param>
  /// <param name="culture"></param>
  /// <returns>
  ///   <see cref="ProductComment" /> list by given parameters with including <see cref="ProductCommentImage" />,
  ///   <see cref="ProductCommentStar" />
  /// </returns>
  List<ProductComment> GetProductComments(Guid productId, ushort page);

  Result AddProductComment(Guid userId, Request_ProductComment_Add model);

  //CustomResult<int> AddCommentImage(IFormFile file, Guid UserId,int commentId);
  //ListProducts<ProductDetail>? GetProductDetails(long productNo);
  //ProductDetail? GetProductDetails(long productNo, LanguagePacks type = LanguagePacks.Default);
  //ProductDetail GetProductDetailsSingle(long productNo, LanguagePacks type = LanguagePacks.Default);
  //Product? GetProductSingle(long productNo);
  //ProductVariant? GetVariant(int id);
  //ListProducts<Product> GetVariantProducts(int variantId);
  //ListProducts<ProductVariant> GetVariants();
  //ProductVariant GetVariantSingle(int id);
  //ListProducts<Product> ListProductsBaseByCategory(ListProductsByCategoryRequestModel model);
  //ListProducts<ProductSimpleResponseModel> ListProductsSimpleViewModel(ListProductsRequestModel model);
  //ListProducts<ProductSimpleResponseModel> ListProductsSimpleViewModelByCategory(ListProductsByCategoryRequestModel model);
}