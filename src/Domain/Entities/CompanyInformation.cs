﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
	public class CompanyInformation : IEfEntity
	{
		[Key]
		public bool IsRelease { get; set; }

		[MaxLength(128)]
		public string DomainUrl { get; set; }

		[MaxLength(128)]
		public string WebApiUrl { get; set; }

		[MaxLength(128)]
		public string CompanyName { get; set; }

		[MaxLength(1024)]
		public string Description { get; set; }
		public string PhoneNumber { get; set; }

		[MaxLength(255)]
		public string ContactEmail { get; set; }
		public int? WhatsApp { get; set; }

		[MaxLength(255)]
		public string CompanyAddress { get; set; }

		[MaxLength(255)]
		public string? FacebookLink { get; set; }
		[MaxLength(255)]
		public string? InstagramLink { get; set; }
		[MaxLength(255)]
		public string? YoutubeLink { get; set; }

		[ForeignKey("DefaultLanguageId")]
		public int? DefaultLanguageId { get; set; }

		[ForeignKey("LogoImageId")]
		public int? LogoImageId { get; set; }

		[ForeignKey("FavIcoImageId")]
		public int? FavIcoImageId { get; set; }
	}
}