
using System.Runtime.InteropServices;

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

        //public List<ProductSimpleResponseModel> ListProductsSimpleViewModel(ListProductsRequestModel model)
        //{
        //	var lastIdx = (int)(_option.PagingProductCount * (model.Page - 1));
        //	var pageProductCount = _option.PagingProductCount;
        //	var ctx = EComDbContext.New();
        //	var products = ctx.Products
        //		.Skip(lastIdx)
        //		.Take(pageProductCount)
        //		.OrderByDescending(x => x.RegisterDate)
        //		.Join(
        //		ctx.ProductDetails,
        //		x => x.Id,
        //		x => x.ProductId,
        //		(p, d) =>
        //		new ProductSimpleResponseModel
        //		{
        //			Product = p,
        //			Details = d
        //		})
        //		.ToList();
        //	return products;
        //}

        //public List<Product> GetVariantProducts(int variantId)
        //{
        //	var ctx = EComDbContext.New();
        //	var list = ctx.Products.Where(x => x.ProductVariantId == variantId).ToList();
        //	return list;
        //}

        //public List<ProductVariant> GetVariants()
        //{
        //	var ctx = EComDbContext.New();
        //	return ctx.ProductVariants.ToList();
        //}
        //public ProductVariant? GetVariant(int id)
        //{
        //	var ctx = EComDbContext.New();
        //	return ctx.ProductVariants.Where(x => x.Id == id).FirstOrDefault();
        //}
        //public ProductVariant GetVariantSingle(int id)
        //{
        //	var ctx = EComDbContext.New();
        //	return ctx.ProductVariants.Where(x => x.Id == id).Single();
        //}


        //public Product? GetProductSingle(long productNo)
        //{
        //	var ctx = EComDbContext.New();
        //	var product = ctx.Products.Where(x => x.Id == productNo).Single();
        //	return product;
        //}

        //public List<ProductDetail>? GetProductDetails(long productNo)
        //{
        //	var ctx = EComDbContext.New();
        //	var products = ctx.ProductDetails.Where(x => x.Id == productNo).ToList();
        //	return products;
        //}
        //public ProductDetail? GetProductDetails(long productNo, LanguageType type = LanguageType.Default)
        //{
        //	var ctx = EComDbContext.New();
        //	var product = ctx.ProductDetails.Where(x => x.Id == productNo && x.LanguageId == (int)type).FirstOrDefault();
        //	return product;
        //}
        //public ProductDetail GetProductDetailsSingle(long productNo, LanguageType type = LanguageType.Default)
        //{
        //	var ctx = EComDbContext.New();
        //	var product = ctx.ProductDetails.Where(x => x.Id == productNo && x.LanguageId == (int)type).Single();
        //	return product;
        //}
        public void CheckExists(int id)
        {
            var exist = _productRepo.Any(x => x.Id == id);
            if (!exist) throw new CustomException(ErrorCode.NotFound);
        }
        public void CheckExists(uint id)
        {
            var exist = _productRepo.Any(x => x.Id == id);
            if (!exist) throw new CustomException(ErrorCode.NotFound);
        }

        public bool Exists(int id)
        {
            return _productRepo.Any(x => x.Id == id);
        }

        public Product? GetProduct(long productNo)
        {
            return _productRepo.Get(x => x.Id == productNo && x.IsValid == true && !x.DeleteDate.HasValue).FirstOrDefault();
        }

        
        public List<ProductDTO> GetProductDTOs(List<int> productIds)
        {
            var result = new List<ProductDTO>();
            var ctx = new EComDbContext();
            var productDTOs = _productRepo
                .Get(x => productIds.Contains(x.Id))
                .Join(ctx.ProductDetails, x => x.Id, x => x.ProductId, (a, b) => new ProductDTO
                {
                    Product = a,
                    Details = b
                })
                .ToList();
            return productDTOs;
        }
    }
}
