using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Domain.Entities
{
	public class SubCategory : IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public bool IsValid { get; set; }


        [MaxLength(32)]
		public string Name { get; set; }

        [ForeignKey("MainCategoryId")]
        public int? MainCategoryId { get; set; }
        public virtual Category MainCategory { get; set; }

    }
}
