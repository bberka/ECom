﻿namespace ECom.Domain.DTOs.ProductDTOs;

public class ListProductsByCategoryRequest
{
  public int CategoryId { get; set; }
  public int Page { get; set; }
  public OrderByType OrderByType { get; set; } = OrderByType.Recommended;
}