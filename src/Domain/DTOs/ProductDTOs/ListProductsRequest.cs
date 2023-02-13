namespace ECom.Domain.DTOs.ProductDTOs
{
    public class ListProductsRequest
    {
        public int Page { get; set; }
        public OrderByType OrderByType { get; set; } = OrderByType.Recommended;
    }
}
