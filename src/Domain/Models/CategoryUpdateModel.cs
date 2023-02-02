﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Models
{
	public class CategoryUpdateModel
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }
		public int LanguageId { get; set; }
		public bool IsValid { get; set; }
	}
}
