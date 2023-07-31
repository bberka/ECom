using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Constants;
using ECom.Shared.Entities;
using ECom.Shared.Extensions;

namespace ECom.Application.Services.BaseServices;

public abstract class ProductService : IProductService
{
  protected readonly Option Option;
  protected readonly ICategoryService CategoryService;
  protected readonly IImageService ImageService;
  protected readonly IOptionService OptionService;
  protected readonly IUnitOfWork UnitOfWork;

  protected ProductService(
    IUnitOfWork unitOfWork,
    IOptionService optionService,
    ICategoryService categoryService,
    IImageService imageService) {
    UnitOfWork = unitOfWork;
    OptionService = optionService;
    CategoryService = categoryService;
    ImageService = imageService;
    Option = OptionService.GetOption();
  }

  public bool Exists(Guid id) {
    return UnitOfWork.ProductRepository.Any(x => x.Id == id);
  }

  public CustomResult<Product> GetProduct(Guid productNo) {
    var product = UnitOfWork.ProductRepository.FirstOrDefault(x => x.Id == productNo);
    if (product is null) return DomainResult.NotFound(nameof(Product));
    if (product.DeleteDate.HasValue) return DomainResult.Invalid(nameof(Product));
    return product;
  }

  public List<ProductComment> GetProductComments(
    List<Guid> productIds,
    ushort page) {
    var lastIdx = Option.PagingProductCount * page;
    return UnitOfWork.ProductCommentRepository.Where(x => productIds.Contains(x.ProductId))
      .OrderByDescending(x => x.RegisterDate)
      .Skip(lastIdx)
      .Take(Option.PagingProductCount)
      .ToList();
  }

  public List<ProductComment> GetProductComments(Guid productId, ushort page) {
    var lastIdx = Option.PagingProductCount * page;
    return UnitOfWork.ProductCommentRepository.Where(x => x.ProductId == productId)
      .OrderByDescending(x => x.RegisterDate)
      .Skip(lastIdx)
      .Take(Option.PagingProductCount)
      .ToList();
  }

  public CustomResult<int> AddProductComment(Guid userId, AddProductCommentRequest model) {
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
    UnitOfWork.ProductCommentRepository.Add(comment);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddProductComment));
    return DomainResult.OkAdded(nameof(ProductComment));
  }

  //public CustomResult<int> AddCommentImage(IFormFile file, Guid UserId,int commentId)
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
  //    var imageResult = ImageService.UploadImage(file);
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
  //    var commentImageResult = _productCommentImageRepo.Create(commentImage);
  //    if (!commentImageResult)
  //    {
  //        return DomainResult.DbInternalError();
  //    }
  //    return DomainResult.ProductCommentImage.AddSuccessResult(commentId);
  //}

  public List<Product> GetProducts(ushort page, string culture = ConstantMgr.DefaultCulture) {
    if (page == 0) return new List<Product>();
    var lastIdx = Option.PagingProductCount * (page - 1);
    return UnitOfWork.ProductRepository
      .Where(x => !x.DeleteDate.HasValue)
      .OrderByDescending(x =>x.RegisterDate)
      .Paging(page,Option.PagingProductCount)
      .Include(x => x.ProductComments)
      .Include(x => x.ProductDetails)
      .Include(x => x.ProductImages)
      .ToList();
  }

  public List<Product> GetProducts(List<Guid> productIds, ushort page, string culture = ConstantMgr.DefaultCulture) {
    return UnitOfWork.ProductRepository
      .Where(x => !x.DeleteDate.HasValue && productIds.Contains(x.Id))
      .OrderByDescending(x => x.RegisterDate)
      .Paging(page, Option.PagingProductCount)
      .Include(x => x.ProductComments)
      .Include(x => x.ProductDetails)
      .Include(x => x.ProductImages)
      .ToList();
  }
}