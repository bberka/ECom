﻿using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class AdminRepository : RepositoryBase<Admin>
{
  public AdminRepository(DbContext context) : base(context) {
  }
}