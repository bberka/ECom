﻿using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class ProductVariantRepository : RepositoryBase<ProductVariant>
{
  public ProductVariantRepository(DbContext context) : base(context) {
  }
}   
