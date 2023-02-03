






using ECom.Domain.Entities;

namespace ECom.Application.Services
{
	public interface IProductService
	{
		void CheckExists(int id);
		void CheckExists(uint id);
		Product? GetProduct(long productNo);
		List<ProductDetail>? GetProductDetails(long productNo);
		ProductDetail? GetProductDetails(long productNo, LanguageType type = LanguageType.Default);
		ProductDetail GetProductDetailsSingle(long productNo, LanguageType type = LanguageType.Default);
		Product? GetProductSingle(long productNo);
		ProductVariant? GetVariant(int id);
		List<Product> GetVariantProducts(int variantId);
		List<ProductVariant> GetVariants();
		ProductVariant GetVariantSingle(int id);
		List<Product> ListProductsBaseByCategory(ListProductsByCategoryModel model);
		List<ProductSimpleViewModel> ListProductsSimpleViewModel(ListProductsModel model);
		List<ProductSimpleViewModel> ListProductsSimpleViewModelByCategory(ListProductsByCategoryModel model);
	}

	public class ProductService : IProductService
	{
		private readonly IEfEntityRepository<Product> _productRepo;
		private readonly IEfEntityRepository<ProductDetail> _productDetailRepo;
		private readonly IEfEntityRepository<ProductComment> _productCommentRepo;
		private readonly IEfEntityRepository<ProductImageBind> _productImageBindRepo;
		private readonly IEfEntityRepository<ProductCommentImageBind> _productCommentImageBindRepo;
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
			IEfEntityRepository<ProductImageBind> productImageBindRepo,
			IEfEntityRepository<ProductCommentImageBind> productCommentImageBindRepo,
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
			this._productImageBindRepo = productImageBindRepo;
			this._productCommentImageBindRepo = productCommentImageBindRepo;
			this._productVariantRepo = productVariantRepo;
			this._favoriteProductRepo = favoriteProductRepo;
			this._subCategoryRepo = subCategoryRepo;
			this._categoryRepo = categoryRepo;
			this._optionService = optionService;
			this._categoryService = categoryService;

			_option = _optionService.GetOptionFromCache();
		}
		public List<Product> ListProductsBaseByCategory(ListProductsByCategoryModel model)
		{
			var lastIdx = (int)(_option.PagingProductCount * (model.Page - 1));
			var pageProductCount = _option.PagingProductCount;
			var products = EComDbContext.New().Products
				.Where(p => p.Category.Id == model.CategoryId)
				.Include(x => x.Comments)
				.Include(x => x.Details)
				.Include(x => x.Variants)
				.Skip(lastIdx)
				.Take(pageProductCount)
				.OrderByDescending(x => x.RegisterDate)
				.ToList();
			return products;
		}
		public List<ProductSimpleViewModel> ListProductsSimpleViewModelByCategory(ListProductsByCategoryModel model)
		{
			var lastIdx = (int)(_option.PagingProductCount * (model.Page - 1));
			var pageProductCount = _option.PagingProductCount;
			var ctx = EComDbContext.New();
			var subCategories = _subCategoryRepo
				.Get(x => x.CategoryId == model.CategoryId)
				.Select(x => x.Id)
				.ToArray();
			var products = ctx.Products
				.Where(p => subCategories.Contains(model.CategoryId))
				.Skip(lastIdx)
				.Take(pageProductCount)
				.OrderByDescending(x => x.RegisterDate)
				.Join(
				ctx.ProductDetails,
				x => x.Id,
				x => x.ProductId,
				(p, d) =>
				new ProductSimpleViewModel
				{
					Product = p,
					Details = d
				})
				.ToList();
			return products;
		}

		public List<ProductSimpleViewModel> ListProductsSimpleViewModel(ListProductsModel model)
		{
			var lastIdx = (int)(_option.PagingProductCount * (model.Page - 1));
			var pageProductCount = _option.PagingProductCount;
			var ctx = EComDbContext.New();
			var products = ctx.Products
				.Skip(lastIdx)
				.Take(pageProductCount)
				.OrderByDescending(x => x.RegisterDate)
				.Join(
				ctx.ProductDetails,
				x => x.Id,
				x => x.ProductId,
				(p, d) =>
				new ProductSimpleViewModel
				{
					Product = p,
					Details = d
				})
				.ToList();
			return products;
		}

		public List<Product> GetVariantProducts(int variantId)
		{
			var ctx = EComDbContext.New();
			var list = ctx.Products.Where(x => x.ProductVariantId == variantId).ToList();
			return list;
		}

		public List<ProductVariant> GetVariants()
		{
			var ctx = EComDbContext.New();
			return ctx.ProductVariants.ToList();
		}
		public ProductVariant? GetVariant(int id)
		{
			var ctx = EComDbContext.New();
			return ctx.ProductVariants.Where(x => x.Id == id).FirstOrDefault();
		}
		public ProductVariant GetVariantSingle(int id)
		{
			var ctx = EComDbContext.New();
			return ctx.ProductVariants.Where(x => x.Id == id).Single();
		}
		public Product? GetProduct(long productNo)
		{
			var ctx = EComDbContext.New();
			var product = ctx.Products.Where(x => x.Id == productNo).FirstOrDefault();
			return product;
		}

		public Product? GetProductSingle(long productNo)
		{
			var ctx = EComDbContext.New();
			var product = ctx.Products.Where(x => x.Id == productNo).Single();
			return product;
		}

		public List<ProductDetail>? GetProductDetails(long productNo)
		{
			var ctx = EComDbContext.New();
			var products = ctx.ProductDetails.Where(x => x.Id == productNo).ToList();
			return products;
		}
		public ProductDetail? GetProductDetails(long productNo, LanguageType type = LanguageType.Default)
		{
			var ctx = EComDbContext.New();
			var product = ctx.ProductDetails.Where(x => x.Id == productNo && x.LanguageId == (int)type).FirstOrDefault();
			return product;
		}
		public ProductDetail GetProductDetailsSingle(long productNo, LanguageType type = LanguageType.Default)
		{
			var ctx = EComDbContext.New();
			var product = ctx.ProductDetails.Where(x => x.Id == productNo && x.LanguageId == (int)type).Single();
			return product;
		}
		public void CheckExists(int id)
		{
			var exist = _productRepo.Any(x => x.Id == id);
			if (!exist) throw new BaseException(ErrCode.NotFound);
		}
		public void CheckExists(uint id)
		{
			var exist = _productRepo.Any(x => x.Id == id);
			if (!exist) throw new BaseException(ErrCode.NotFound);
		}
	}
}
