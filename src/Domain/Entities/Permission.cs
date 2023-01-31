using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
	public class Permission : IEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		
		[MaxLength(32)]
		public string Name { get; set; }

        [MaxLength(256)]
        public string? Memo { get; set; }

		
		public bool IsValid { get; set; }

	}
}
