using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
	public class SubCategory
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public bool IsValid { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int MainCategoryId { get; set; }

        [Required]
		[MaxLength(32)]
		public string Name { get; set; }
        [Required]
        [MaxLength(128)]
        public string Description { get; set; }
        [Required]
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        [Required]
        [ForeignKey("Image")]
        public int ImageId { get; set; }
    }
}
