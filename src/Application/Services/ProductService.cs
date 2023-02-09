using ECom.Domain.Results;

namespace ECom.Application.Services
{

    public class ProductService : IProductService
    {
        private readonly IEfEntityRepository<Product> _productRepo;
        private readonly IEfEntityRepository<ProductDetail> _productDetailRepo;
        private readonly IEfEntityRepository<ProductComment> _productCommentRepo;
        private readonly IEfEntityRepository<ProductImage> _productImageRepo;
        private readonly IEfEntityRepository<ProductCommentImage> _productCommentImageBindRepo;
        private readonly IEfEntityRepository<ProductVariant> _productVariantRepo;
        private readonly IEfEntityRepository<FavoriteProduct> _favoriteProductRepo;
        private readonly IEfEntityRepository<SubCategory> _subCategoryRepo;
        private readonly IEfEntityRepository<Category> _categoryRepo;
        private readonly IOptionService _optionService;
        private readonly ICategoryService _categoryService;

        private readonly Option _option;
        public ProductService(
            IEfEntityRepository<Product> productRepo,
            IEfEntityRepository<ProductDetail> productDetailRepo,
            IEfEntityRepository<ProductComment> productCommentRepo,
            IEfEntityRepository<ProductImage> productImageRepo,
            IEfEntityRepository<ProductCommentImage> productCommentImageRepo,
            IEfEntityRepository<ProductVariant> productVariantRepo,
            IEfEntityRepository<FavoriteProduct> favoriteProductRepo,
            IEfEntityRepository<SubCategory> subCategoryRepo,
            IEfEntityRepository<Category> categoryRepo,
            IOptionService optionService,
            ICategoryService categoryService)
        {
            this._productRepo = productRepo;
            this._productDetailRepo = productDetailRepo;
            this._productCommentRepo = productCommentRepo;
            this._productImageRepo = productImageRepo;
            this._productCommentImageBindRepo = productCommentImageRepo;
            this._productVariantRepo = productVariantRepo;
            this._favoriteProductRepo = favoriteProductRepo;
            this._subCategoryRepo = subCategoryRepo;
            this._categoryRepo = categoryRepo;
            this._optionService = optionService;
            this._categoryService = categoryService;

            _option = _optionService.GetOptionFromCache();
        }

        public bool Exists(int id)
        {
            return _productRepo.Any(x => x.Id == id);
        }

        public ResultData<Product> GetProduct(long productNo)
        {
            var product = _productRepo.GetFirstOrDefault(x => x.Id == productNo);
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
            return _productCommentRepo
                .Get(x => productIds.Contains(x.ProductId))
                .OrderByDescending(x => x.RegisterDate)
                .Skip(lastIdx)
                .Take(_option.PagingProductCount)
                .Include(x => x.ProductCommentImages)
                .ToList();
        }

        public List<ProductComment> GetProductComments(int productId,ushort page)
        {
            var lastIdx = (int)(_option.PagingProductCount * (page));
            return _productCommentRepo
                .Get(x => x.ProductId == productId)
                .OrderByDescending(x => x.RegisterDate)
                .Skip(lastIdx)
                .Take(_option.PagingProductCount)
                .Include(x => x.ProductCommentImages)
                .ToList();
        }

        public List<Product> GetProducts(ushort page, string culture = ConstantMgr.DefaultCulture)
        {
            if (page == 0) return new();
            var lastIdx = (int)(_option.PagingProductCount * (page - 1));
            var ctx = new EComDbContext();
            return ctx.Products
                .Where(x => !x.DeleteDate.HasValue && x.IsValid)
                .OrderByDescending(x => x.RegisterDate)
                .Skip(lastIdx)
                .Take(_option.PagingProductCount)
                .Include(x => x.ProductVariant)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductDetails)
                .Include(x => x.ProductComments)
                .ThenInclude(x => x.ProductCommentImages)
                .ToList();
        }

        public List<Product> GetProducts(List<int> productIds, ushort page, string culture = ConstantMgr.DefaultCulture)
        {
            var lastIdx = (int)(_option.PagingProductCount * (page));
            return _productRepo.Get(x => !x.DeleteDate.HasValue && x.IsValid && productIds.Contains(x.Id))
                .OrderByDescending(x => x.RegisterDate)
                .Skip(lastIdx)
                .Take(_option.PagingProductCount)
                .Include(x => x.ProductVariant)
                .Include(x => x.ProductImages)
                .Include(x => x.ProductDetails)
                .Include(x => x.ProductComments)
                .ThenInclude(x => x.ProductCommentImages)
                .ToList();
        }
    }
}
