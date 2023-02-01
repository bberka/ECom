using ECom.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.Abstract
{
	public interface IJwtAuthentication
	{
		public JwtTokenModel Authenticate(LoginModel model);
		public JwtTokenModel Refresh(JwtTokenModel model);
	}
}
