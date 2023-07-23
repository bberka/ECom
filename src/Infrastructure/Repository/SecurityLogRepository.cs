﻿using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class SecurityLogRepository : RepositoryBase<SecurityLog>
{
  public SecurityLogRepository(DbContext context) : base(context) {
  }
}
