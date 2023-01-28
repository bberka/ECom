using Domain.Models;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IJwtAuthentication
	{
		public ResultData<JwtTokenModel> Authenticate(LoginModel model);
		public ResultData<string> Refresh(string token);
	}
}
