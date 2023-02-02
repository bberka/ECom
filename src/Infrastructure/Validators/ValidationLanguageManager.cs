using FluentValidation.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Validators
{
	public class ValidationLanguageManager : LanguageManager
	{
		public ValidationLanguageManager()
		{
			AddTranslation("en", "NotNullValidator", "'{PropertyName}' is required.");
		}
	}
}
