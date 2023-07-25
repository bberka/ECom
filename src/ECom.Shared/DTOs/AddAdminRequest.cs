﻿namespace ECom.Shared.DTOs;

public class AddAdminRequest : BaseAuthenticatedRequest
{
    public string EmailAddress { get; set; }

    public string Password { get; set; }

    public string RoleId { get; set; }
}