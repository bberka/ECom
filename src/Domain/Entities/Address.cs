using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ECom.Domain.Entities
{
    public class Address : IEfEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public DateTime? DeleteDate { get; set; }

        [MinLength(ConstantMgr.NameMinLength)]
        [MaxLength(ConstantMgr.NameMaxLength)]
        public string Name { get; set; }
        
		[MinLength(ConstantMgr.NameMinLength)]
		[MaxLength(ConstantMgr.NameMaxLength)]
		public string Surname { get; set; }

		[MaxLength(ConstantMgr.TitleMaxLength)]
        public string Title { get; set; }
        
        [MaxLength(64)]
        public string Town { get; set; }
        
        [MaxLength(32)]
        public string Country { get; set; }

        [MaxLength(32)]
        public string Provience { get; set; }
        
        [MaxLength(128)]
        public string Details { get; set; }

        [MinLength(ConstantMgr.PhoneNumberMinLength)]
        [MaxLength(ConstantMgr.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } 

        //FK
        public int UserId { get; set; }
        
    }
}
