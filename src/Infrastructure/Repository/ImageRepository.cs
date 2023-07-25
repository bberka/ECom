﻿using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class ImageRepository : RepositoryBase<Image>
{
  public ImageRepository(DbContext context) : base(context) {
  }
}