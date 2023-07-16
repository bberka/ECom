﻿using ECom.Domain;
using ECom.Domain.DTOs.UserDTOs;

namespace ECom.Application.Services;

public class UserService : IUserService
{
  private readonly IOptionService _optionService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IValidationService _validationService;

  public UserService(
    IUnitOfWork unitOfWork,
    IOptionService optionService,
    IValidationService validationService) {
    _unitOfWork = unitOfWork;
    _optionService = optionService;
    _validationService = validationService;
  }

  public CustomResult Register(RegisterUserRequest model) {
    var user = model.ToUserEntity();
    _unitOfWork.UserRepository.Insert(user);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(Register));
    return DomainResult.OkUpdated(nameof(User));
  }

  public CustomResult<UserDto> Login(LoginRequest model) {
    var userResult = GetUser(model.EmailAddress);
    if (!userResult.Status) return userResult.ToResult();
    var user = userResult.Data;
    if (user?.Password != model.EncryptedPassword) return DomainResult.NotFound(nameof(User));
    if (user.TwoFactorType != 0) {
      //TODO: implement two factor
    }

    var userNecessary = new UserDto {
      TwoFactorType = user.TwoFactorType,
      Culture = user.Culture,
      EmailAddress = user.EmailAddress,
      FirstName = user.FirstName,
      LastName = user.LastName,
      Id = user.Id,
      PhoneNumber = user.PhoneNumber,
      IsEmailVerified = user.IsEmailVerified,
      TaxNumber = user.TaxNumber
    };
    return userNecessary;
  }

  public CustomResult<User> GetUser(string email) {
    var user = _unitOfWork.UserRepository.GetFirstOrDefault(x => x.EmailAddress == email);
    if (user is null) return DomainResult.NotFound(nameof(User));
    if (!user.IsValid) return DomainResult.Invalid(nameof(User));
    if (user.DeletedDate.HasValue) return DomainResult.Deleted(nameof(User));
    return user;
  }

  public CustomResult<User> GetUser(int id) {
    var user = _unitOfWork.UserRepository.GetById(id);
    if (user is null) return DomainResult.NotFound(nameof(User));
    if (!user.IsValid) return DomainResult.Invalid(nameof(User));
    if (user.DeletedDate.HasValue) return DomainResult.Deleted(nameof(User));
    return user;
  }


  public bool Exists(string email) {
    return _unitOfWork.UserRepository.Any(x => x.EmailAddress == email);
  }


  public CustomResult ChangePassword(ChangePasswordRequest model) {
    var userResult = GetUser(model.AuthenticatedUserId);
    if (!userResult.Status) return userResult.ToResult();
    var user = userResult.Data;
    if (user.Password != model.EncryptedOldPassword) return DomainResult.NotFound("User");
    user.Password = Convert.ToBase64String(model.NewPassword.MD5Hash());
    _unitOfWork.UserRepository.Update(user);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(ChangePassword));
    return DomainResult.OkUpdated(nameof(User));
  }

  public CustomResult Update(UpdateUserRequest model) {
    var userId = model.AuthenticatedUserId;
    if (userId < 1) throw new InvalidOperationException("UserNo can not be negative");
    var user = _unitOfWork.UserRepository.GetById(userId);
    if (user is null) return DomainResult.NotFound(nameof(User));
    user.EmailAddress = model.EmailAddress;
    user.CitizenShipNumber = model.CitizenShipNumber;
    user.PhoneNumber = model.PhoneNumber;
    user.TaxNumber = model.TaxNumber;
    user.FirstName = model.FirstName;
    user.LastName = model.LastName;
    _unitOfWork.UserRepository.Update(user);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(Update));
    return DomainResult.OkUpdated(nameof(User));
  }

  public bool Exists(int id) {
    return _unitOfWork.UserRepository.Any(x => x.Id == id);
  }
}