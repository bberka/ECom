using AutoMapper;
using ECom.Domain.DTOs.AdminDto;
using ECom.Domain.DTOs.UserDto;

namespace ECom.Application.Services;

public class DebugService : IDebugService
{
  private readonly IMapper _mapper;
  private readonly IUnitOfWork _unitOfWork;

  public DebugService(
    IUnitOfWork unitOfWork,
    IMapper mapper) {
    _unitOfWork = unitOfWork;
    _mapper = mapper;
  }

  public void CheckAndThrowDebug() {
    if (!ConstantMgr.IsDevelopment()) throw new Exception("Only available when debugging");
  }

  public User GetUser() {
    CheckAndThrowDebug();
    return _unitOfWork.UserRepository.GetFirstOrDefault();
  }

  public Admin GetAdmin() {
    CheckAndThrowDebug();
    return _unitOfWork.AdminRepository
      .Get(x => x.RoleId == 1)
      .Include(x => x.Role)
      .ThenInclude(x => x.PermissionRoles)
      .Single();
  }

  public AdminDto GetAdminDto() {
    var admin = GetAdmin();
    var dto = _mapper.Map<AdminDto>(admin);
    return dto;
  }

  public UserDto GetUserDto() {
    var user = GetUser();
    var dto = _mapper.Map<UserDto>(user);
    return dto;
  }
}