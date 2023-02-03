using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.Services
{
	public interface IFavoriteProductService : IEfEntityRepository<FavoriteProduct>
	{
	}
	public class FavoriteProductService : EfEntityRepositoryBase<FavoriteProduct, EComDbContext>, IFavoriteProductService
	{

	}
}
