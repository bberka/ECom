using AutoMapper;
using ECom.Domain.Entities;

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