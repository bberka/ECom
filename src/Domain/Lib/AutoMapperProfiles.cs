using AutoMapper;
using ECom.Domain.DTOs.AdminDTOs;
using ECom.Domain.DTOs.CollectionDTOs;
using ECom.Domain.DTOs.ProductDTOs;
using ECom.Domain.DTOs.StockChangeDTOs;
using ECom.Domain.DTOs.UserDTOs;

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
  }
}