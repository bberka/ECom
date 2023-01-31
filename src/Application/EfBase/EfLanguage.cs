using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Infrastructure.DataAccess;

namespace ECom.Domain.Entities
{
	public class EfLanguage : EfEntityRepositoryBase<Language, EComDbContext>
	{

	}
}
