﻿namespace ECom.Shared.DTOs;

public class AnnouncementAddRequestDto
{
    public int Order { get; set; }

    [MaxLength(128)]
    public string Message { get; set; } = null!;
    public DateTime ExpireDate { get; set; } = DateTime.Now.AddDays(1);
}