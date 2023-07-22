﻿using ECom.Domain.Entities;

namespace ECom.Infrastructure.Repository;

public class EmailVerifyTokenRepository : RepositoryBase<EmailVerifyToken>
{
  public EmailVerifyTokenRepository(DbContext context) : base(context) {
  }
}