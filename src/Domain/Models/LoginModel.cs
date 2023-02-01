﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Models
{
	public class LoginModel
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string? TwoFactorKey { get; set; }
		public bool RememberMe { get; set; }
	}
}
