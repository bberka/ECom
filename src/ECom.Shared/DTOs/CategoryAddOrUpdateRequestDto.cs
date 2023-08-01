﻿namespace ECom.Shared.DTOs;

public class CategoryAddOrUpdateRequestDto : BaseAuthenticatedRequest
{
    public bool IsValid { get; set; }
    public string NameKey { get; set; } = null!;
    public string? ParentNameKey { get; set; }
    public string Name { get; set; } = null!;
    public Language Language { get; set; }
}