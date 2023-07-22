﻿using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class ShowCaseRepository : RepositoryBase<ShowCase>
{
  public ShowCaseRepository(DbContext context) : base(context) {
  }
}