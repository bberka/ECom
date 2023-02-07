using ECom.Domain.ApiModels.Request;
using ECom.Domain.ApiModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface ICollectionService
    {
        public Result CreateCollection(CreateCollectionRequestModel model);
        public ResultData<Collection> GetCollection(int id);
        public ResultData<Collection> GetCollection(int userId,int id);
        public Result UpdateCollection(UpdateCollectionRequestModel model);
        public Result DeleteCollection(int id);
        public List<Collection> GetCollections(int userId);
        public ResultData<ListCollectionProductsResponseModel> GetCollectionProducts(int userId,int id); 
    }
}
