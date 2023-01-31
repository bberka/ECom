namespace ECom.Domain.Models
{
    public class ListProductsModel
    {
        public int Page { get; set; }
        public OrderByType OrderByType { get; set; } = OrderByType.Recommended;
    }
}
