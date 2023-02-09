namespace ECom.Domain.ApiModels.Request
{
    public class AddSubCategoryRequestModel : AuthRequestModelBase
    {

        public int CategoryId { get; set; }

        [MinLength(4)]
        [MaxLength(32)]
        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(6)]
        public string Culture { get; set; }
    }
}
