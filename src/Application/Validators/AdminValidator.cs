﻿using ECom.Application.BaseManager;
using FluentValidation;

namespace ECom.Application.Validators
{
	public class AdminValidator : AbstractValidator<Admin>
	{

		public static AdminValidator This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static AdminValidator? Instance;
		private AdminValidator()
		{
			RuleFor(x => x.EmailAddress)
				.NotNull()
				.NotEmpty()
				.EmailAddress()
				.WithErrorCode(Response.InvalidEmailAddress.ToString());

			RuleFor(x => x.IsValid)
				.Equal(x => false)
				.WithErrorCode(Response.AccountIsNotValid.ToString());	

			RuleFor(x => x.IsTestAccount)
				.Equal(x => true)
				.Must(DebugModeOn)
				.WithErrorCode(Response.DebugAccountCanNotBeUsed.ToString());

			RuleFor(x => x.IsEmailVerified)
				.Equal(x => false)
				.WithErrorCode(Response.EmailIsNotVerified.ToString());

			RuleFor(x => x.DeletedDate)
				.NotEqual(x => null)
				.WithErrorCode(Response.AccountIsDeleted.ToString());
		}
		private bool DebugModeOn(bool isTesterAccount)
		{
			if (!isTesterAccount) return false;
			var option = OptionMgr.This.Cache.Get();
			return option.IsDebug;
		}

		
	}
}
