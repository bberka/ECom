using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface IImageService
    {
        ResultData<int> UploadImage(IFormFile file);

        string GetImageBase64String(int id);

        ResultData<Image> GetImage(int id);
    }
}
