﻿namespace ECom.Shared.DTOs.ProductDto;

public class AddProductCommentRequest : BaseAuthenticatedRequest
{
  public string Comment { get; set; }

  public byte Star { get; set; }

  public Guid ProductId { get; set; }
}