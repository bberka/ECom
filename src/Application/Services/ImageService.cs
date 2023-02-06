
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Services
{
	public class ImageService : IImageService
	{
        private readonly IEfEntityRepository<Image> _imageRepo;
        private readonly IEfEntityRepository<ImageLanguage> _imageLanguageRepo;

        public ImageService(
			IEfEntityRepository<Image> imageRepo,
			IEfEntityRepository<ImageLanguage> imageLanguageRepo)
		{
            this._imageRepo = imageRepo;
            this._imageLanguageRepo = imageLanguageRepo;
        }

        public Image? GetImage(int id)
        {
            return _imageRepo.Find(id);
        }

        public string GetImageBase64String(int id)
        {
            var image = _imageRepo.Find(id);
            if (image is null) return string.Empty;
            Convert.ToBase64String(image.Data);
            string imageBase64Data = Convert.ToBase64String(image.Data);
            string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
            return imageDataURL;
        }

        public ResultData<int> UploadImage(IFormFile file)
        {
            var img = new Image();
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            img.Data = ms.ToArray();
            img.Name = file.FileName;
            var res = _imageRepo.Add(img);
            if (!res) return ResultData<int>.DbInternal(1);
            return img.Id;
        }
    }
}
