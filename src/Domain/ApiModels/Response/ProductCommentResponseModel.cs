namespace ECom.Domain.ApiModels.Response
{
    public class ProductCommentResponseModel
    {
        public int ProductId { get; set; }
        public ProductComment Comment { get; set; }
        public List<Image> Images { get; set; }
    }
}
