using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ECom.Domain.Entities
{
	public class SubCategory : IEfEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public bool IsValid { get; set; }

        [MinLength(ConstantMgr.NameMinLength)]
        [MaxLength(ConstantMgr.NameMaxLength)]
		public string Name { get; set; }

		public int CategoryId { get; set; }
		
		//virtual
        [IgnoreDataMember]
        public virtual Category Category { get; set; }

	}
}
