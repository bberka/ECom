﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services

{
	public interface IValidationDbService
	{
		bool AllowTester(bool isTesterAccount);
		bool NotHasLowerCase(string password);
		bool NotHasNumber(string password);
		bool NotHasSpace(string password);
		bool NotHasSpecialChar(string password);
		bool NotHasUpperCase(string password);
		bool NotUsedEmail_Admin(string email);
		bool NotUsedEmail_User(string email);
	}

	public class ValidationDbService : IValidationDbService
	{
		private readonly IEfEntityRepository<User> _userRepo;
		private readonly IEfEntityRepository<Admin> _adminRepo;
		private readonly IOptionService _optionService;
		private readonly Option _option;
		public ValidationDbService(
			IEfEntityRepository<User> userRepo,
			IEfEntityRepository<Admin> adminRepo,
			IOptionService optionService
			)
		{
			this._userRepo = userRepo;
			this._adminRepo = adminRepo;
			this._optionService = optionService;
			_option = _optionService.GetFullOptionCache().Option;
		}

		public bool AllowTester(bool isTesterAccount)
		{
			if (!isTesterAccount) return false;
			var option = _optionService.GetFullOptionCache().Option;
			return !option.IsRelease;
		}
		public bool NotUsedEmail_Admin(string email)
		{
			return !_adminRepo.Any(x => x.EmailAddress == email);
		}

		public bool NotUsedEmail_User(string email)
		{
			return !_userRepo.Any(x => x.EmailAddress == email);
		}

		public bool NotHasSpecialChar(string password)
		{
			if (!_option.RequireSpecialCharacterInPassword)
			{
				return true;
			}
			return !EasValidate.HasSpecialChars(password);
		}
		public bool NotHasNumber(string password)
		{
			if (!_option.RequireNumberInPassword)
			{
				return true;
			}
			return !password.Any(x => char.IsDigit(x));
		}
		public bool NotHasLowerCase(string password)
		{
			if (!_option.RequireLowerCaseInPassword)
			{
				return true;
			}
			return !password.Any(x => char.IsLower(x));
		}
		public bool NotHasUpperCase(string password)
		{
			if (!_option.RequireUpperCaseInPassword)
			{
				return true;
			}
			return !password.Any(x => char.IsUpper(x));
		}
		public bool NotHasSpace(string password)
		{
			return !password.Any(x => x == ' ');
		}
	}
}