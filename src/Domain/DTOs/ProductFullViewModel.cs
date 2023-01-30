﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ProductFullViewModel
    {
        public ProductSimpleViewModel Product { get; set; }
        public List<ProductSimpleViewModel> Variants { get; set; }
        public List<ProductCommentViewModel> Comments { get; set; }
        public int UserId { get; set; }
        public bool IsFavorite { get; set; } = false;
        public List<Collection> AddedCollections { get; set; } = new();
    }
}
