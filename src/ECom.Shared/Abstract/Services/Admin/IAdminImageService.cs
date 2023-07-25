using ECom.Shared.Abstract.Services.Base;
using ECom.Shared.Entities;
using Microsoft.AspNetCore.Http;

namespace ECom.Shared.Abstract.Services.Admin;

public interface IAdminImageService : IImageService
{
  CustomResult<Guid> UploadImage(IFormFile file);
  CustomResult<Image> GetImage(Guid id);

}