using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Infrastructure.Services
{
	public interface IProductCommentImageBindService : IEfEntityRepository<ProductCommentImageBind>
	{
	}
	public class ProductCommentImageBindService : EfEntityRepositoryBase<ProductCommentImageBind, EComDbContext>, IProductCommentImageBindService
	{

	}
}
