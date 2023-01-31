using ECom.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Entities
{
	public class EfProduct : EfEntityRepositoryBase<Product, EComDbContext>
	{

	}
}
