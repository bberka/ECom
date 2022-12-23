using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IJwtAuthentication
	{
		public JwtTokenModel Authenticate(string username, string password);
		public string Refresh(string token);
	}
}
