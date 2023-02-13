namespace ECom.Domain.DTOs.Request
{
    public class AddSubCategoryRequest : AuthRequestModelBase
    {

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Culture { get; set; }
    }
}
