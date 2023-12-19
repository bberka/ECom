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
    if (product is null) return DefResult.NotFound(nameof(Product));
    if (product.DeleteDate.HasValue) return DefResult.Invalid(nameof(Product));
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

  public Result<int> AddProductComment(Guid userId, Request_ProductComment_Add model) {
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
    if (!res) return DefResult.DbInternalError(nameof(AddProductComment));
    return DefResult.OkAdded(nameof(ProductComment));
  }

  //public CustomResult<int> AddCommentImage(IFormFile file, Guid UserId,int commentId)
  //{
  //    var productComment = _productCommentRepo.Find(commentId);
  //    if (productComment is null)
  //    {
  //        return DefResult.ProductComment.NotFound();
  //    }
  //    if (productComment.UserId != userId)
  //    {
  //        return DefResult.User.NotAuthorized();
  //    }
  //    var imageResult = ImageService.UploadImage(file);
  //    if (imageResult.IsFailure)
  //    {
  //        return DefResult.DbInternalError();
  //    }

  //    var commentImage = new ProductCommentImage()
  //    {
  //        ImageId = imageResult.Data,
  //        RegisterDate = DateTime.Now,
  //        ProductCommentId = commentId
  //    };
  //    var commentImageResult = _productCommentImageRepo.Create(commentImage);
  //    if (!commentImageResult)
  //    {
  //        return DefResult.DbInternalError();
  //    }
  //    return DefResult.ProductCommentImage.AddSuccessResult(commentId);
  //}

  public List<Product> GetProducts(ushort page, Language culture = ConstantContainer.DefaultLanguage) {
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

  public List<Product> GetProducts(List<Guid> productIds, ushort page, Language culture = ConstantContainer.DefaultLanguage) {
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