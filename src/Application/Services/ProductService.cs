using ECom.Domain;
using ECom.Domain.DTOs.ProductDTOs;

namespace ECom.Application.Services;

public class ProductService : IProductService
{
  private readonly ICategoryService _categoryService;
  private readonly IImageService _imageService;

  private readonly Option _option;
  private readonly IOptionService _optionService;
  private readonly IUnitOfWork _unitOfWork;

  public ProductService(
    IUnitOfWork unitOfWork,
    IOptionService optionService,
    ICategoryService categoryService,
    IImageService imageService) {
    _unitOfWork = unitOfWork;
    _optionService = optionService;
    _categoryService = categoryService;
    _imageService = imageService;
    _option = _optionService.GetOption();
  }

  public bool Exists(int id) {
    return _unitOfWork.ProductRepository.Any(x => x.Id == id);
  }

  public CustomResult<Product> GetProduct(long productNo) {
    var product = _unitOfWork.ProductRepository.GetFirstOrDefault(x => x.Id == productNo);
    if (product is null) return DomainResult.NotFound(nameof(Product));
    if (!product.IsValid) return DomainResult.Invalid(nameof(Product));
    if (product.DeleteDate.HasValue) return DomainResult.Deleted(nameof(Product));
    return product;
  }

  public List<ProductComment> GetProductComments(
    List<int> productIds,
    ushort page) {
    var lastIdx = _option.PagingProductCount * page;
    return _unitOfWork.ProductCommentRepository
      .Get(x => productIds.Contains(x.ProductId))
      .OrderByDescending(x => x.RegisterDate)
      .Skip(lastIdx)
      .Take(_option.PagingProductCount)
      .ToList();
  }

  public List<ProductComment> GetProductComments(int productId, ushort page) {
    var lastIdx = _option.PagingProductCount * page;
    return _unitOfWork.ProductCommentRepository
      .Get(x => x.ProductId == productId)
      .OrderByDescending(x => x.RegisterDate)
      .Skip(lastIdx)
      .Take(_option.PagingProductCount)
      .ToList();
  }

  public CustomResult<int> AddProductComment(AddProductCommentRequest model) {
    var productResult = GetProduct(model.ProductId);
    if (!productResult.Status) return productResult.ToResult();
    //TODO: Check if user purchased the product
    var comment = new ProductComment {
      ProductId = model.ProductId,
      Comment = model.Comment,
      RegisterDate = DateTime.Now,
      UserId = model.AuthenticatedUserId,
      Star = model.Star
    };
    _unitOfWork.ProductCommentRepository.Insert(comment);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddProductComment));
    return DomainResult.OkAdded(nameof(ProductComment));
  }

  //public CustomResult<int> AddCommentImage(IFormFile file, int userId,int commentId)
  //{
  //    var productComment = _productCommentRepo.Find(commentId);
  //    if (productComment is null)
  //    {
  //        return DomainResult.ProductComment.NotFound();
  //    }
  //    if (productComment.UserId != userId)
  //    {
  //        return DomainResult.User.NotAuthorized();
  //    }
  //    var imageResult = _imageService.UploadImage(file);
  //    if (imageResult.IsFailure)
  //    {
  //        return DomainResult.DbInternalError();
  //    }

  //    var commentImage = new ProductCommentImage()
  //    {
  //        ImageId = imageResult.Data,
  //        RegisterDate = DateTime.Now,
  //        ProductCommentId = commentId
  //    };
  //    var commentImageResult = _productCommentImageRepo.Add(commentImage);
  //    if (!commentImageResult)
  //    {
  //        return DomainResult.DbInternalError();
  //    }
  //    return DomainResult.ProductCommentImage.AddSuccessResult(commentId);
  //}

  public List<Product> GetProducts(ushort page, string culture = ConstantMgr.DefaultCulture) {
    if (page == 0) return new List<Product>();
    var lastIdx = _option.PagingProductCount * (page - 1);
    return _unitOfWork.ProductRepository
      .GetPaging(page,
        _option.PagingProductCount,
        x => !x.DeleteDate.HasValue && x.IsValid,
        x => x.OrderByDescending(y => y.RegisterDate))
      .Include(x => x.ProductComments)
      .Include(x => x.ProductDetails)
      .Include(x => x.ProductImages)
      .ToList();
  }

  public List<Product> GetProducts(List<int> productIds, ushort page, string culture = ConstantMgr.DefaultCulture) {
    return _unitOfWork.ProductRepository
      .GetPaging(page,
        _option.PagingProductCount,
        x => !x.DeleteDate.HasValue && x.IsValid && productIds.Contains(x.Id),
        x => x.OrderByDescending(y => y.RegisterDate))
      .Include(x => x.ProductComments)
      .Include(x => x.ProductDetails)
      .Include(x => x.ProductImages)
      .ToList()
      .ToList();
  }
}