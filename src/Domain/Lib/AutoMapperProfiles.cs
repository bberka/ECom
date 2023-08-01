using AutoMapper;
using ECom.Shared.Entities;

namespace ECom.Domain.Lib;

public class AutoMapperProfiles : Profile
{
  public AutoMapperProfiles() {
    CreateMap<User, UserDto>().ReverseMap();
    CreateMap<Admin, AdminDto>().ReverseMap();


    CreateMap<RegisterUserRequestDto, User>();
    CreateMap<CollectionAddRequestDto, Collection>();
    CreateMap<CategoryAddOrUpdateRequestDto, Category>();
    //CreateMap<AddSubCategoryRequest, SubCategory>();
    CreateMap<AdminAddRequestDto, Admin>();
    CreateMap<ProductCommentAddRequestDto, ProductComment>();
    CreateMap<StockChangeAddRequestDto, StockChange>();

  }
}