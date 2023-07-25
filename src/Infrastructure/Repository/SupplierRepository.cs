﻿using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class SupplierRepository : RepositoryBase<Supplier>
{
  public SupplierRepository(DbContext context) : base(context) {
  }
}