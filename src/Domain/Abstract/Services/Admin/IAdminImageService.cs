using ECom.Domain.Abstract.Services.Base;
using ECom.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECom.Domain.Abstract.Services.Admin;

public interface IAdminImageService : IImageService
{
  CustomResult<Guid> UploadImage(IFormFile file);
  CustomResult<Image> GetImage(Guid id);

}