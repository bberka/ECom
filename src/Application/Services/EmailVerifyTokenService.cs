
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services
{
	public interface IEmailVerifyTokenService : IEfEntityRepository<EmailVerifyToken>
	{
	}
	public class EmailVerifyTokenService : EfEntityRepositoryBase<EmailVerifyToken, EComDbContext>, IEmailVerifyTokenService
	{

	}
}
