

namespace ECom.Domain.DTOs
{
    public class ProductCommentViewModel
    {
        public int ProductId { get; set; }
        public ProductComment Comment { get; set; }
        public List<Image> Images { get; set; }
    }
}
