using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.Services
{
	public interface IOrderService : IEfEntityRepository<Order>
	{
	}
	public class OrderService : EfEntityRepositoryBase<Order, EComDbContext>, IOrderService
	{


	}
}
