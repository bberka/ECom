namespace ECom.Domain.ApiModels.Request
{
    public class UpdateUserRequestModel : AuthRequestModelBase
    {
        [EmailAddress]
        [MaxLength(255)]
        public string EmailAddress { get; set; }

        [MinLength(ConstantMgr.NameMinLength)]
        [MaxLength(ConstantMgr.NameMaxLength)]
        public string FirstName { get; set; }


        [MinLength(ConstantMgr.NameMinLength)]
        [MaxLength(ConstantMgr.NameMaxLength)]
        public string LastName { get; set; }


        [MinLength(ConstantMgr.PhoneNumberMinLength)]
        [MaxLength(ConstantMgr.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public int? CitizenShipNumber { get; set; }
        public int? TaxNumber { get; set; }
    }
}
