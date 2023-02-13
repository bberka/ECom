namespace ECom.Domain.DTOs.Request
{
    public class AddCategoryRequest : AuthRequestModelBase
    {

        public string Name { get; set; }

        public string Culture { get; set; }
    }
}
