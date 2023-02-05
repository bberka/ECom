
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services
{

	public class EmailService : IEmailService
	{
		private readonly IEfEntityRepository<EmailVerifyToken> _emailVerifyTokenRepo;
		private readonly IEfEntityRepository<PasswordResetToken> _passswordResetTokenRepo;
		private readonly IOptionService _optionService;

		public EmailService(
			IEfEntityRepository<EmailVerifyToken> emailVerifyTokenRepo,
			IEfEntityRepository<PasswordResetToken> passswordResetTokenRepo,
			IOptionService optionService)
		{
			this._emailVerifyTokenRepo = emailVerifyTokenRepo;
			this._passswordResetTokenRepo = passswordResetTokenRepo;
			this._optionService = optionService;
		}
	}
}
