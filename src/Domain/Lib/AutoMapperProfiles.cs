using AutoMapper;
using ECom.Domain.DTOs.AdminDto;
using ECom.Domain.DTOs.CategoryDto;
using ECom.Domain.DTOs.CollectionDto;
using ECom.Domain.DTOs.ProductDto;
using ECom.Domain.DTOs.RoleDto;
using ECom.Domain.DTOs.StockChangeDto;
using ECom.Domain.DTOs.UserDto;

namespace ECom.Domain.Lib;

public class AutoMapperProfiles : Profile
{
  public AutoMapperProfiles() {
    CreateMap<User, UserDto>().ReverseMap();
    CreateMap<Admin, AdminDto>().ReverseMap();


    CreateMap<RegisterUserRequest, User>();
    CreateMap<AddCollectionRequest, Collection>();
    CreateMap<AddOrUpdateCategoryRequest, Category>();
    //CreateMap<AddSubCategoryRequest, SubCategory>();
    CreateMap<AddAdminRequest, Admin>();
    CreateMap<AddProductCommentRequest, ProductComment>();
    CreateMap<AddStockChangeRequest, StockChange>();
    CreateMap<RoleDto, Role>();
    CreateMap<PermissionDto, PermissionRole>();
    CreateMap<PermissionDto, Permission>();
  }
}