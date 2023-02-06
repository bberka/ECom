using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECom.Domain.Entities
{
	public class SubCategory : IEfEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public bool IsValid { get; set; }

        [MaxLength(32)]
		public string Name { get; set; }

		[ForeignKey("CategoryId")]
		public int CategoryId { get; set; }
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public virtual Category Category { get; set; }

	}
}
