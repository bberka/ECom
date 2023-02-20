
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Domain.Results;

namespace ECom.Application.Services
{
	public class ImageService : IImageService
	{
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private const string DefaultImageBase64String = "";
        public ResultData<Image> GetImage(int id)
        {
            var image= _unitOfWork.ImageRepository.GetById(id);
            if (image is null) return DomainResult.Image.NotFoundResult(1);
            return image;
        }

        public string GetImageBase64String(int id)
        {
            var imageData = _unitOfWork.ImageRepository
                .Get(x => x.Id == id)
                .Select(x => x.Data)
                .FirstOrDefault();
            if (imageData is null)
            {
                return $"data:image/jpg;base64,{DefaultImageBase64String}";
            }
            var imageBase64Data = Convert.ToBase64String(imageData);
            return $"data:image/jpg;base64,{imageBase64Data}";
        }

        public ResultData<int> UploadImage(IFormFile file)
        {
            var img = new Image();
            var ms = new MemoryStream();
            file.CopyTo(ms);
            img.Data = ms.ToArray();
            img.Name = file.FileName;
            _unitOfWork.ImageRepository.Insert(img);
            var res = _unitOfWork.Save();
            if (!res)
            {
                return DomainResult.DbInternalErrorResult(1);
            }
            return img.Id;
        }
    }
}
