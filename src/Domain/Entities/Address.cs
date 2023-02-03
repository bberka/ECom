﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ECom.Domain.Entities 
{
    public class Address : IEfEntity
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime RegisterDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? LastUseDate { get; set; }

        [MinLength(ConstantMgr.StringMinLength)]
        [MaxLength(ConstantMgr.NameMaxLength)]
        public string Name { get; set; }
        
		[MinLength(ConstantMgr.StringMinLength)]
		[MaxLength(ConstantMgr.NameMaxLength)]
		public string Surname { get; set; }

		[MinLength(ConstantMgr.StringMinLength)]
		[MaxLength(ConstantMgr.TitleMaxLength)]
        public string Title { get; set; }
        
        [MaxLength(64)]
        public string Town { get; set; }
        
        [MaxLength(32)]
        public string Country { get; set; }
        public string Provience { get; set; }
        
        [MaxLength(64)]
        public string Details { get; set; }

        [MaxLength(ConstantMgr.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;


        [ForeignKey("UserId")]
        public int? UserId { get; set; }

    }
}
