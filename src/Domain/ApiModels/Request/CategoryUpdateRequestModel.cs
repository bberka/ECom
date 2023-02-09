﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.ApiModels.Request
{
    public class CategoryUpdateRequestModel : AuthRequestModelBase
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }
        public bool IsValid { get; set; }
    }
}
