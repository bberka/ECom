using ECom.Domain.DTOs.ProductDTOs;

namespace ECom.Domain.Abstract;

public interface IProductService
{
  bool Exists(int id);

  CustomResult<Product> GetProduct(long productNo);

  /// <summary>
  /// </summary>
  /// <param name="productIds"></param>
  /// <param name="page"></param>
  /// <param name="culture"></param>
  /// <returns>
  ///   <see cref="Product" /> list by given parameters with including <see cref="ProductVariant" />,
  ///   <see cref="ProductImage" />, <see cref="ProductDetail" />
  ///   without including <see cref="ProductComment" /> or related data
  /// </returns>
  List<Product> GetProducts(List<int> productIds, ushort page, string culture = ConstantMgr.DefaultCulture);

  /// <summary>
  /// </summary>
  /// <param name="productIds"></param>
  /// <param name="page"></param>
  /// <param name="culture"></param>
  /// <returns>
  ///   <see cref="Product" /> list by given parameters with including <see cref="ProductVariant" />,
  ///   <see cref="ProductImage" />, <see cref="ProductDetail" />
  ///   without including <see cref="ProductComment" /> or related data
  /// </returns>
  List<Product> GetProducts(ushort page, string culture = ConstantMgr.DefaultCulture);

  /// <summary>
  /// </summary>
  /// <param name="productIds"></param>
  /// <param name="page"></param>
  /// <param name="culture"></param>
  /// <returns>
  ///   <see cref="ProductComment" /> list by given parameters with including <see cref="ProductCommentImage" />,
  ///   <see cref="ProductCommentStar" />
  /// </returns>
  List<ProductComment> GetProductComments(List<int> productIds, ushort page);

  /// <summary>
  /// </summary>
  /// <param name="productIds"></param>
  /// <param name="page"></param>
  /// <param name="culture"></param>
  /// <returns>
  ///   <see cref="ProductComment" /> list by given parameters with including <see cref="ProductCommentImage" />,
  ///   <see cref="ProductCommentStar" />
  /// </returns>
  List<ProductComment> GetProductComments(int productId, ushort page);

  CustomResult<int> AddComment(AddProductCommentRequest model);

  //CustomResult<int> AddCommentImage(IFormFile file, int userId,int commentId);
  //ListProducts<ProductDetail>? GetProductDetails(long productNo);
  //ProductDetail? GetProductDetails(long productNo, LanguageType type = LanguageType.Default);
  //ProductDetail GetProductDetailsSingle(long productNo, LanguageType type = LanguageType.Default);
  //Product? GetProductSingle(long productNo);
  //ProductVariant? GetVariant(int id);
  //ListProducts<Product> GetVariantProducts(int variantId);
  //ListProducts<ProductVariant> GetVariants();
  //ProductVariant GetVariantSingle(int id);
  //ListProducts<Product> ListProductsBaseByCategory(ListProductsByCategoryRequestModel model);
  //ListProducts<ProductSimpleResponseModel> ListProductsSimpleViewModel(ListProductsRequestModel model);
  //ListProducts<ProductSimpleResponseModel> ListProductsSimpleViewModelByCategory(ListProductsByCategoryRequestModel model);
}