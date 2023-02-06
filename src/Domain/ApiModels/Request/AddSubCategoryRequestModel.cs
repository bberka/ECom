﻿namespace ECom.Domain.ApiModels.Request
{
    public class AddSubCategoryRequestModel
    {

        public int Category { get; set; }

        [MinLength(3)]
        [MaxLength(32)]
        public string Name { get; set; }

        [MinLength(1)]
        [MaxLength(6)]
        public string Culture { get; set; }
    }
}
