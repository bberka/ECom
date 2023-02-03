﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.Services
{
	public interface ISmtpOptionService : IEfEntityRepository<SmtpOption>
	{
	}
	public class SmtpOptionService : EfEntityRepositoryBase<SmtpOption, EComDbContext>, ISmtpOptionService
	{

	}
}