﻿using ECom.Foundation.Enum;

namespace ECom.Foundation.DTOs.Request;

public class Request_PageWithCulture : Request_Page
{
  public Language Culture { get; set; }
}