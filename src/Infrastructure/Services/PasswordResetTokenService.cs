
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Services
{
	public interface IPasswordResetTokenService : IEfEntityRepository<PasswordResetToken>
	{
	}
	public class PasswordResetTokenService : EfEntityRepositoryBase<PasswordResetToken, EComDbContext>, IPasswordResetTokenService
	{


	}
}
