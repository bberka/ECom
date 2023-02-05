namespace ECom.Domain.ApiModels.Response
{
    public class ProductFullResponseModel
    {
        public ProductSimpleResponseModel Product { get; set; }
        public List<ProductSimpleResponseModel> Variants { get; set; }
        public List<ProductCommentResponseModel> Comments { get; set; }
        public int UserId { get; set; }
        public bool IsFavorite { get; set; } = false;
        public List<Collection> AddedCollections { get; set; } = new();
    }
}
