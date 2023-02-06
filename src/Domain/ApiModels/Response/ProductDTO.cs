namespace ECom.Domain.ApiModels.Response
{
    public class ProductDTO
    {
        public Product Product { get; set; }
        public List<ProductDetail> Details { get; set; }
    }
}
