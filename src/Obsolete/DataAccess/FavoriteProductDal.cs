using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.DataAccess
{
	public class FavoriteProductDal : EntityRepositoryBase<FavoriteProduct, EComDbContext>
	{
        public FavoriteProductDal(EComDbContext context) : base(context)
        {
        }
    }
}
