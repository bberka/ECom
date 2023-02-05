namespace ECom.Domain.ApiModels.Request
{
    public class ListProductsRequestModel
    {
        public int Page { get; set; }
        public OrderByType OrderByType { get; set; } = OrderByType.Recommended;
    }
}
