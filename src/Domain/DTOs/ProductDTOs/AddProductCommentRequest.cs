﻿namespace ECom.Domain.DTOs.ProductDTOs
{
    public class AddProductCommentRequest : AuthRequestModelBase
    {
        public string Comment { get; set; }

        public byte Star { get; set; }

        public int ProductId { get; set; }

    }

}