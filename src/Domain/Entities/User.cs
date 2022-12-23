﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public class User
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public DateTime RegisterDate { get; set; }

		[Required]
		public bool IsValid { get; set; }

		public bool IsTestAccount { get; set; } = false;

		[Required]
		[MaxLength(32)]
		public string Username{ get; set; }
		
		[Required]
		[MaxLength(64)]
		public string Password { get; set; }

		[Required]
		[MaxLength(255)]
		public string Email { get; set; }

		[Required]
		public bool IsEmailVerified { get; set; } = false;

		[MaxLength(255)]
		public string? TwoFactorKey { get; set; }

		[Required]
		public bool IsEnabledTwoFactor { get; set; } = false;

		[Required]
		public byte Role { get; set; } = 255;

		[Required]
		public int TotalLoginCount { get; set; }
		
		[Required]
		[MaxLength(16)]
		public string? LastLoginIp { get; set; }

		[Required]
		[MaxLength(500)]
		public string? LastLoginUserAgent { get; set; }

		public DateTime? LastLoginDate { get; set; }

		[Required]
		public byte FailedPasswordCount { get; set; } = 0;

		public DateTime? LastPasswordUpdateDate { get; set; }
		public DateTime? DeletedDate { get; set; }
	}
}
