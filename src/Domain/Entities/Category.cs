﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ECom.Domain.Entities
{
	public class Category : IEfEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		
		public bool IsValid { get; set; }

		[MaxLength(32)]
		public string Name { get; set; }

        [ForeignKey("LanguageId")]
        public int? LanguageId { get; set; }
        public virtual Language? Language { get; set; }

		public List<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
	}

}
