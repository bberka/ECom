using AutoMapper;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services;
using ECom.Shared.Constants;
using ECom.Shared.Entities;

namespace ECom.Application.Services;

public class DebugService : IDebugService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DebugService(
      IUnitOfWork unitOfWork,
      IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public void CheckAndThrowDebug()
    {
        if (!ConstantMgr.IsDevelopment()) throw new Exception("Only available when debugging");
    }

    public User GetUser()
    {
        CheckAndThrowDebug();
        return _unitOfWork.UserRepository.FirstOrDefault();
    }

    public Admin GetAdmin()
    {
        CheckAndThrowDebug();
        return _unitOfWork.AdminRepository.Get(x => x.RoleId == "Owner")
          .Include(x => x.Role)
          .ThenInclude(x => x.PermissionRoles)
          .Single();
    }

    public AdminDto GetAdminDto()
    {
        var admin = GetAdmin();
        var dto = _mapper.Map<AdminDto>(admin);
        return dto;
    }

    public UserDto GetUserDto()
    {
        var user = GetUser();
        var dto = _mapper.Map<UserDto>(user);
        return dto;
    }
}