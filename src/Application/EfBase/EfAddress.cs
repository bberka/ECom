using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ECom.Infrastructure.DataAccess;

namespace ECom.Domain.Entities 
{
    public class EfAddress : EfEntityRepositoryBase<Address,EComDbContext>
	{
        
    }
}
