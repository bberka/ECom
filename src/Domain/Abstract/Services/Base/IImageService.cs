using ECom.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ECom.Domain.Abstract.Services.Base;

public interface IImageService
{
    string GetImageBase64String(Guid id);

}