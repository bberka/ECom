
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOptionService _optionService;

		public EmailService(IUnitOfWork unitOfWork,IOptionService optionService)
		{
            _unitOfWork = unitOfWork;
            this._optionService = optionService;
		}
	}
}
