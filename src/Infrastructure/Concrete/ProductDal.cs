

namespace ECom.Infrastructure.Concrete
{
	public class ProductDal : EfEntityRepositoryBase<Product, EComDbContext>
	{

		private ProductDal() { }
		public static ProductDal This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static ProductDal? Instance;

		public List<Product> ListProductsBaseByCategory(ListProductsByCategoryModel model)
		{
			var option = OptionDal.This.Cache.Get();
			var lastIdx = (int)(option.PagingProductCount * (model.Page - 1));
			var pageProductCount = option.PagingProductCount;
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
			var option = OptionDal.This.Cache.Get();
			var lastIdx = (int)(option.PagingProductCount * (model.Page - 1));
			var pageProductCount = option.PagingProductCount;
			var ctx = EComDbContext.New();
			var subCategories = SubCategoryDal.This
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
			var lastIdx = (int)(OptionDal.This.Cache.Get().PagingProductCount * (model.Page - 1));
			var pageProductCount = OptionDal.This.Cache.Get().PagingProductCount;
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
		public  Product? GetProduct(long productNo)
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

		public List<ProductDetails>? GetProductDetails(long productNo)
		{
			var ctx = EComDbContext.New();
			var products = ctx.ProductDetails.Where(x => x.Id == productNo).ToList();
			return products;
		}
		public ProductDetails? GetProductDetails(long productNo, LanguageType type)
		{
			var ctx = EComDbContext.New();
			var product = ctx.ProductDetails.Where(x => x.Id == productNo && x.LanguageId == (int)type).FirstOrDefault();
			return product;
		}
		public ProductDetails GetProductDetailsSingle(long productNo, LanguageType type)
		{
			var ctx = EComDbContext.New();
			var product = ctx.ProductDetails.Where(x => x.Id == productNo && x.LanguageId == (int)type).Single();
			return product;
		}


		public void CheckExists(int id)
		{
			var exist = Any(x => x.Id == id);
			if (!exist) throw new BaseException(Response.ProductNotFound);
		}
		public void CheckExists(uint id)
		{
			var exist = Any(x => x.Id == id);
			if (!exist) throw new BaseException(Response.ProductNotFound);
		}
	}
}
