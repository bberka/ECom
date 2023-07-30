﻿using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class PermissionRepository : RepositoryBase<Permission>
{
  public PermissionRepository(DbContext context) : base(context) {
  }
}