namespace ECom.Domain.ApiModels.Request
{
    public class ListProductsByCategoryRequestModel
    {
        public int CategoryId { get; set; }
        public int Page { get; set; }
        public OrderByType OrderByType { get; set; } = OrderByType.Recommended;
    }
}
