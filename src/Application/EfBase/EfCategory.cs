using ECom.Infrastructure.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECom.Domain.Entities
{
	public class EfCategory : EfEntityRepositoryBase<Category, EComDbContext>
	{

	}
}
