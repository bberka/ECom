namespace ECom.Domain.Models
{
    public class ListProductsByCategoryModel
    {
        public int CategoryId { get; set; }
        public int Page { get; set; }
        public OrderByType OrderByType { get; set; } = OrderByType.Recommended;
    }
}
