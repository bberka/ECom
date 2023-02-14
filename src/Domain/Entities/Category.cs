using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECom.Domain.Entities
{
	public class Category : IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		
		public bool IsValid { get; set; }

		[MinLength(ConstantMgr.NameMinLength)]
		[MaxLength(ConstantMgr.NameMaxLength)]
		public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(4)]
        public string Culture { get; set; } = ConstantMgr.DefaultCulture;

		//Virtual
		public virtual List<SubCategory> SubCategories { get; set; }
	}

}
