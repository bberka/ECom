﻿namespace ECom.Infrastructure.Repository;

public class ProductSubCategoryRepository : GenericRepository<ProductSubCategory, EComDbContext>
{
  public ProductSubCategoryRepository(EComDbContext context) : base(context) {
  }
}   
