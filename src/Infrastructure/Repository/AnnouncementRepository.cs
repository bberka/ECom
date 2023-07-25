﻿using ECom.Shared.Entities;

namespace ECom.Infrastructure.Repository;

public class AnnouncementRepository : RepositoryBase<Announcement>
{
  public AnnouncementRepository(DbContext context) : base(context) {
  }
}