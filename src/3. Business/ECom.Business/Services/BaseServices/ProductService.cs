using ECom.Foundation.Static;

namespace ECom.Business.Services.BaseServices;

public class ProductService : IProductService
{
  private readonly ICategoryService _categoryService;
  private readonly IImageService _imageService;
  private readonly IOptionService _optionService;
  private readonly IUnitOfWork _unitOfWork;
  protected readonly Option Option;

  public ProductService(
    IUnitOfWork unitOfWork,
    IOptionService optionService,
    ICategoryService categoryService,
    IImageService imageService) {
    _unitOfWork = unitOfWork;
    _optionService = optionService;
    _categoryService = categoryService;
    _imageService = imageService;
    Option = _optionService.Get();
  }

  public bool Exists(Guid id) {
    return _unitOfWork.Products.Any(x => x.Id == id);
  }

  public Result<Product> GetProduct(Guid productNo) {
    var product = _unitOfWork.Products.FirstOrDefault(x => x.Id == productNo);
    if (product is null) return DomResults.x_is_not_found("product");
    if (product.DeleteDate.HasValue) return DomResults.x_is_invalid("product");
    return product;
  }

  public List<ProductComment> GetProductComments(
    List<Guid> productIds,
    ushort page) {
    var lastIdx = Option.PagingProductCount * page;
    return _unitOfWork.ProductComments.Where(x => productIds.Contains(x.ProductId))
                      .OrderByDescending(x => x.RegisterDate)
                      .Skip(lastIdx)
                      .Take(Option.PagingProductCount)
                      .ToList();
  }

  public List<ProductComment> GetProductComments(Guid productId, ushort page) {
    var lastIdx = Option.PagingProductCount * page;
    return _unitOfWork.ProductComments.Where(x => x.ProductId == productId)
                      .OrderByDescending(x => x.RegisterDate)
                      .Skip(lastIdx)
                      .Take(Option.PagingProductCount)
                      .ToList();
  }

  public Result AddProductComment(Guid userId, Request_ProductComment_Add model) {
    var productResult = GetProduct(model.ProductId);
    if (!productResult.Status) return productResult.ToResult();
    //TODO: Check if user purchased the product
    var comment = new ProductComment {
      ProductId = model.ProductId,
      Comment = model.Comment,
      RegisterDate = DateTime.Now,
      UserId = userId,
      Star = model.Star
    };
    _unitOfWork.ProductComments.Add(comment);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(AddProductComment));
    return DomResults.x_is_added_successfully("product_comment");
  }

  //public CustomResult<int> AddCommentImage(IFormFile file, Guid UserId,int commentId)
  //{
  //    var productComment = _productCommentRepo.Find(commentId);
  //    if (productComment is null)
  //    {
  //        return DomResults.ProductComment.NotFound();
  //    }
  //    if (productComment.UserId != userId)
  //    {
  //        return DomResults.User.NotAuthorized();
  //    }
  //    var imageResult = ImageService.UploadImage(file);
  //    if (imageResult.IsFailure)
  //    {
  //        return DomResults.DbInternalError();
  //    }

  //    var commentImage = new ProductCommentImage()
  //    {
  //        ImageId = imageResult.Value,
  //        RegisterDate = DateTime.Now,
  //        ProductCommentId = commentId
  //    };
  //    var commentImageResult = _productCommentImageRepo.New(commentImage);
  //    if (!commentImageResult)
  //    {
  //        return DomResults.DbInternalError();
  //    }
  //    return DomResults.ProductCommentImage.AddSuccessResult(commentId);
  //}

  public List<Product> GetProducts(ushort page, CultureType culture = StaticValues.DEFAULT_LANGUAGE) {
    if (page == 0) return new List<Product>();
    var lastIdx = Option.PagingProductCount * (page - 1);
    return _unitOfWork.Products
                      .Where(x => !x.DeleteDate.HasValue)
                      .OrderByDescending(x => x.RegisterDate)
                      .Paging(page, Option.PagingProductCount)
                      .Include(x => x.ProductComments)
                      .Include(x => x.ProductDetail)
                      .Include(x => x.ProductVariant)
                      .Include(x => x.ProductImages)
                      .ToList();
  }

  public List<Product> GetProducts(List<Guid> productIds, ushort page, CultureType culture = StaticValues.DEFAULT_LANGUAGE) {
    return _unitOfWork.Products
                      .Where(x => !x.DeleteDate.HasValue && productIds.Contains(x.Id))
                      .OrderByDescending(x => x.RegisterDate)
                      .Paging(page, Option.PagingProductCount)
                      .Include(x => x.ProductComments)
                      .Include(x => x.ProductDetail)
                      .Include(x => x.ProductVariant)
                      .Include(x => x.ProductImages)
                      .ToList();
  }
}