using ECom.Domain.DTOs.ProductDTOs;
using ECom.Domain.Results;
using Microsoft.AspNetCore.Http;

namespace ECom.Application.Services
{

    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptionService _optionService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;

        private readonly Option _option;
        public ProductService(
            IUnitOfWork unitOfWork,
            IOptionService optionService,
            ICategoryService categoryService,
            IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _optionService = optionService;
            _categoryService = categoryService;
            _imageService = imageService;
            _option = _optionService.GetOption();
        }

        public bool Exists(int id)
        {
            return _unitOfWork.ProductRepository.Any(x => x.Id == id);
        }

        public ResultData<Product> GetProduct(long productNo)
        {
            var product = _unitOfWork.ProductRepository.GetFirstOrDefault(x => x.Id == productNo);
            if (product is null) return DomainResult.Product.NotFoundResult(1);
            if (!product.IsValid) return DomainResult.Product.NotValidResult(2);
            if (product.DeleteDate.HasValue) return DomainResult.Product.DeletedResult(3);
            return product;
        }
        
        public List<ProductComment> GetProductComments(
            List<int> productIds,
            ushort page)
        {
            var lastIdx = (int)(_option.PagingProductCount * (page));
            return _unitOfWork.ProductCommentRepository
                .Get(x => productIds.Contains(x.ProductId))
                .OrderByDescending(x => x.RegisterDate)
                .Skip(lastIdx)
                .Take(_option.PagingProductCount)
                .ToList();
        }

        public List<ProductComment> GetProductComments(int productId,ushort page)
        {
            var lastIdx = (int)(_option.PagingProductCount * (page));
            return _unitOfWork.ProductCommentRepository
                .Get(x => x.ProductId == productId)
                .OrderByDescending(x => x.RegisterDate)
                .Skip(lastIdx)
                .Take(_option.PagingProductCount)
                .ToList();
        }

        public ResultData<int> AddComment(AddProductCommentRequest model)
        {
            var productResult = GetProduct(model.ProductId);
            if (productResult.IsFailure) return productResult.ToResult(100);
            //TODO: Check if user purchased the product
            var comment = new ProductComment()
            {
                ProductId = model.ProductId,
                Comment = model.Comment,
                RegisterDate = DateTime.Now,
                UserId = model.AuthenticatedUserId,
                Star = model.Star,
            };
            _unitOfWork.ProductCommentRepository.Add(comment);
            var res = _unitOfWork.Save();
            if (!res) return DomainResult.DbInternalErrorResult(1);
            return DomainResult.ProductComment.AddSuccessResult(comment.Id);
        }

        //public ResultData<int> AddCommentImage(IFormFile file, int userId,int commentId)
        //{
        //    var productComment = _productCommentRepo.Find(commentId);
        //    if (productComment is null)
        //    {
        //        return DomainResult.ProductComment.NotFoundResult(1);
        //    }
        //    if (productComment.UserId != userId)
        //    {
        //        return DomainResult.User.NotAuthorizedResult(2);
        //    }
        //    var imageResult = _imageService.UploadImage(file);
        //    if (imageResult.IsFailure)
        //    {
        //        return DomainResult.DbInternalErrorResult(3);
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
        //        return DomainResult.DbInternalErrorResult(4);
        //    }
        //    return DomainResult.ProductCommentImage.AddSuccessResult(commentId);
        //}

        public List<Product> GetProducts(ushort page, string culture = ConstantMgr.DefaultCulture)
        {
            if (page == 0) return new();
            var lastIdx = (int)(_option.PagingProductCount * (page - 1));
            return _unitOfWork.ProductRepository
                .Get(x => !x.DeleteDate.HasValue && x.IsValid)
                .OrderByDescending(x => x.RegisterDate)
                .Skip(lastIdx)
                .Take(_option.PagingProductCount)
                .Include(x => x.ProductVariant)
                .Include(x => x.Images)
                .Include(x => x.ProductDetails)
                //.Include(x => x.ProductComments)
                //.ThenInclude(x => x.ProductCommentImages)
                .ToList();
        }
        
        public List<Product> GetProducts(List<int> productIds, ushort page, string culture = ConstantMgr.DefaultCulture)
        {
            var lastIdx = (int)(_option.PagingProductCount * (page));
            return _unitOfWork.ProductRepository.Get(x => !x.DeleteDate.HasValue && x.IsValid && productIds.Contains(x.Id))
                .OrderByDescending(x => x.RegisterDate)
                .Skip(lastIdx)
                .Take(_option.PagingProductCount)
                .Include(x => x.ProductVariant)
                .Include(x => x.Images)
                .Include(x => x.ProductDetails)
                //.Include(x => x.ProductComments)
                //.ThenInclude(x => x.ProductCommentImages)
                .ToList();
        }
    }
}
