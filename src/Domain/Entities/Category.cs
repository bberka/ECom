using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Domain.Entities
{
	public class Category
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		
		public bool IsValid { get; set; }

        
		[MaxLength(32)]
		public string Name { get; set; }

        [ForeignKey("LanguageId")]
        public int? LanguageId { get; set; }
        public virtual Language Language { get; set; }

        [ForeignKey("ImageId")]
        public int? ImageId { get; set; }
        public virtual Image Image { get; set; }

    }
}
