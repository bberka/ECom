﻿using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class CargoOptionRepository : RepositoryBase<CargoOption>
{
  public CargoOptionRepository(DbContext context) : base(context) {
  }
}